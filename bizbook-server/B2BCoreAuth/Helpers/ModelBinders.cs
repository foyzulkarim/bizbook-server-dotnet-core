using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Model.Model;
using Model.Model.Sales;
using RequestModel;
using RequestModel.Sales;

namespace B2BCoreApi.Helpers
{
    public class AbstractSearchModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(SaleRequestModel))
            {
                var assembly = typeof(SaleRequestModel).Assembly;
                Type[] exportedTypes = assembly.GetExportedTypes();

                var abstractSearchClasses = exportedTypes
                    .Where(t => t.BaseType == typeof(RequestModel<Sale>))
                    .Where(t => !t.IsAbstract)
                    .ToList();

                var modelBuilderByType = new Dictionary<Type, ComplexTypeModelBinder>();

                foreach (var type in abstractSearchClasses)
                {
                    var propertyBinders = new Dictionary<ModelMetadata, IModelBinder>();
                    var metadata = context.MetadataProvider.GetMetadataForType(type);

                    foreach (var property in metadata.Properties)
                    {
                        propertyBinders.Add(property, context.CreateBinder(property));
                    }

                    modelBuilderByType.Add(type, new ComplexTypeModelBinder(propertyBinders));
                }

                return new AbstractSearchModelBinder(modelBuilderByType, context.MetadataProvider);
            }

            return null;
        }
    }

    public class AbstractSearchModelBinder : IModelBinder
    {
        private readonly IDictionary<Type, ComplexTypeModelBinder> modelBuilderByType;

        private readonly IModelMetadataProvider modelMetadataProvider;

        public AbstractSearchModelBinder(IDictionary<Type, ComplexTypeModelBinder> modelBuilderByType, IModelMetadataProvider modelMetadataProvider)
        {
            this.modelBuilderByType = modelBuilderByType ?? throw new ArgumentNullException(nameof(modelBuilderByType));
            this.modelMetadataProvider = modelMetadataProvider ?? throw new ArgumentNullException(nameof(modelMetadataProvider));
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelTypeValue = bindingContext.ValueProvider.GetValue(ModelNames.CreatePropertyModelName(bindingContext.ModelName, "ModelTypeName"));

            if (modelTypeValue != null && modelTypeValue.FirstValue != null)
            {
                Type modelType = Type.GetType(modelTypeValue.FirstValue);
                if (this.modelBuilderByType.TryGetValue(modelType, out var modelBinder))
                {
                    ModelBindingContext innerModelBindingContext = DefaultModelBindingContext.CreateBindingContext(
                        bindingContext.ActionContext,
                        bindingContext.ValueProvider,
                        this.modelMetadataProvider.GetMetadataForType(modelType),
                        null,
                        bindingContext.ModelName);

                    modelBinder.BindModelAsync(innerModelBindingContext);

                    bindingContext.Result = innerModelBindingContext.Result;
                    return Task.CompletedTask;
                }
            }

            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
    }
}
