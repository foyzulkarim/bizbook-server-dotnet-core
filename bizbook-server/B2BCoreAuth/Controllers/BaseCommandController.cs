using System;
using System.Threading;
using B2BCoreApi.Attributes;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;
using RequestModel;
//using Serilog;
using ServiceLibrary;
using ViewModel;
using Microsoft.AspNetCore.Http;

namespace B2BCoreApi.Controllers
{
    [BizBookAuthorization]
    public abstract class BaseCommandController<T, TRm, TVm> : ControllerBase where T : Entity where TRm : RequestModel<T> where TVm : BaseViewModel<T>
    {
        public ILogger Logger;
        protected IBaseService<T, TRm, TVm> Service;
        protected string typeName = string.Empty;
        public ApplicationUser AppUser;

        protected BaseCommandController(IBaseService<T, TRm, TVm> service, ILogger logger)
        {
            Service = service;
            typeName = typeof(T).Name;
            this.Logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        [ActionName("Add")]
        [EntitySaveFilter]
        public virtual ActionResult Add([FromBody] T model)
        {
            T data = model;
            if (!ModelState.IsValid)
            {
                //Logger.Warning("User sent Invalid model state {@Data}",  data);
                return BadRequest(ModelState);
            }

            try
            {
                var add = Service.Add(model);
                Logger.LogDebug("User {@UserName} Added entity {TypeName} {@Id}", this.AppUser.UserName, typeName, data.Id);
                return Ok(model.Id);
            }
            catch (Exception exception)
            {
                Logger.LogError(
                    exception,
                    "Exception occurred while saving {@Data} by User {@AppUser}",
                    data,
                    this.AppUser);

                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }

        [HttpPut]
        [Route("Edit")]
        [ActionName("Edit")]
        [EntityEditFilter]
        public virtual ActionResult Put([FromBody]T model)
        {
            T data = model;
            if (!ModelState.IsValid)
            {
                Logger.LogWarning("User {@AppUser} sent Invalid model state {@Data}", this.AppUser, data);
                return BadRequest(ModelState);
            }

            try
            {
                var edit = Service.Edit(model);
                Logger.LogDebug("User {@UserName} ConnectionId {@ConnectionId} edited entity {TypeName} {@Id}", this.AppUser.UserName, this.AppUser.ConnectionId, typeName, data.Id);
                return Ok(edit);
            }
            catch (Exception exception)
            {
                Logger.LogError(
                    exception,
                    "Exception occurred while editing {TypeName} {@Data} by User {@AppUser}",
                    typeName,
                    data,
                    this.AppUser);
                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }

        [Route("Delete")]
        [ActionName("Delete")]
        [HttpDelete]
        public virtual ActionResult Delete(string id)
        {
            try
            {
                var delete = Service.Delete(id);
                Logger.LogDebug("User {@AppUser} Deleted entity {TypeName} {@Id} ", this.AppUser, typeName, id);
                return Ok(delete);
            }
            catch (Exception exception)
            {
                Logger.LogError(
                    exception,
                    "Exception occurred while editing {TypeName} {@Id} by User {@AppUser}",
                    typeName,
                    id,
                    this.AppUser);
                var result = StatusCode(StatusCodes.Status500InternalServerError, exception);
                return result;
            }
        }

        protected Entity AddCommonValues(Entity fromEntity, Entity toEntity)
        {
            toEntity.Id = Guid.NewGuid().ToString();
            toEntity.Created = fromEntity.Created;
            toEntity.CreatedFrom = fromEntity.CreatedFrom;
            toEntity.CreatedBy = fromEntity.CreatedBy;
            toEntity.Modified = fromEntity.Modified;
            toEntity.ModifiedBy = fromEntity.ModifiedBy;
            toEntity.IsActive = true;
            return toEntity;
        }

        protected ShopChild AddCommonValues(ShopChild from, ShopChild to)
        {
            AddCommonValues((Entity)from, (Entity)to);
            to.ShopId = from.ShopId;
            return to;
        }
    }
}
