using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using B2BCoreApi.Auth;
using B2BCoreApi.Models;
using Model.Model;
using Model.Shops;
using Newtonsoft.Json;

namespace B2BCoreApi.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory,
            JwtIssuerOptions jwtOptions, ApplicationUser user, Employee employee, List<dynamic> roles, Shop shop,
            JsonSerializerSettings serializerSettings, SecurityDbContext db)
        {
            string roleId = identity.Claims.Single(c => c.Type == "roleId").Value;
            string id = identity.Claims.Single(c => c.Type == "id").Value;
            var name = user.FirstName + " " + user.LastName;
            string token = await jwtFactory.GenerateEncodedToken(user.UserName, identity);
            //string warehouseId = "";
            //if (employee != null)
            //{
            //    warehouseId = !string.IsNullOrWhiteSpace(employee.WarehouseId) ? employee.WarehouseId : "";
            //}

            IQueryable<ApplicationPermission> permissions = db.Permissions.Where(x => x.RoleId == roleId && x.IsAllowed);
            var resources =
                permissions.Select(x => new { name = x.Resource.Name, isAllowed = x.IsAllowed, isDisabled = x.IsDisabled })
                    .ToList();
            string allowedResources = JsonConvert.SerializeObject(resources);

            var response = new
            {
                id = id,
                name = name,
                userName = user.UserName,
                role = user.RoleName,
                roleId = roleId,
                shopId = user.ShopId,
                resources = allowedResources,
                access_token = token,
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds,
                token_type = "bearer"
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}