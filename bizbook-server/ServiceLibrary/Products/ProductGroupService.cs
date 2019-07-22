using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Model.Products;
using RequestModel.Products;
using RequestModel.Shops;
using ViewModel.Products;
using ViewModel.Shops;

namespace ServiceLibrary.Products
{
    public class ProductGroupService : BaseService<ProductGroup, ProductGroupRequestModel, ProductGroupViewModel>
    {
        public ProductGroupService(IBaseRepository<ProductGroup> repository) : base(repository)
        {
        }
    }
}
