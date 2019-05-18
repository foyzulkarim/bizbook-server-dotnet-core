using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using B2BCoreApi.Auth;
using B2BCoreApi.Helpers;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model;
using Model.Shops;
using Newtonsoft.Json;
using Serilog;

namespace B2BCoreApi.Controllers
{
    // reference : https://fullstackmark.com/post/13/jwt-authentication-with-aspnet-core-2-web-api-angular-5-net-core-identity-and-facebook-login

    [Route("api")]
    public class AppTokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly BizBookInventoryContext _db;
        private readonly SecurityDbContext _securityDb;

        public AppTokenController(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions, BizBookInventoryContext db, SecurityDbContext securityDb)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _db = db;
            _securityDb = securityDb;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> Post([FromBody] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClaimsIdentity identity = await GetClaimsIdentity(loginViewModel.Username, loginViewModel.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.",
                    ModelState));
            }

            Claim claim = identity.Claims.First(x => x.Type == Helpers.Constants.Strings.JwtClaimIdentifiers.Id);
            var id = claim.Value.ToString();
            ApplicationUser user = _securityDb.Users.First(x => x.Id == id);
            Shop shop = _db.Shops.First(x => x.Id == user.ShopId);
            if (shop.ExpiryDate.Date < DateTime.UtcNow.Date)
            {
                Log.Logger.Error("Invalid login attempt for shop {Name}", shop.Name);
                string s = "Shop " + shop.Name + " registration is expired.";
                return BadRequest(s);
            }

            if (user == null)
            {
                Log.Logger.Error("Invalid login attempt for {UserName}", user.UserName);
                return BadRequest("The user name or password is incorrect.");
            }

            if (user.IsActive == false)
            {
                Log.Logger.Error("Invalid login attempt for {UserName}", user.UserName);
                return BadRequest("User is Deactivated");
            }

            var employeeInfo = _db.Employees.FirstOrDefault(x => x.Email == user.Email && x.ShopId == shop.Id);

            List<dynamic> roles = new List<dynamic> { };
            foreach (var r in _securityDb.ApplicationRoles.Select(x => new { x.Id, x.Name }).ToList())
            {
                roles.Add(r);
            }

            string jwt = await Tokens.GenerateJwt(
                identity,
                _jwtFactory,
                _jwtOptions,
                user,
                employeeInfo,
                roles,
                shop,
                new JsonSerializerSettings { Formatting = Formatting.Indented },
                _securityDb);
            return Ok(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            var userToVerify = _userManager.Users.FirstOrDefault(x => x.UserName == userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                ClaimsIdentity identity =
                    _jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id, userToVerify.ShopId);
                ClaimsIdentity claimsIdentity = await Task.FromResult(identity);

                return claimsIdentity;
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }

    public class LoginViewModel
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}