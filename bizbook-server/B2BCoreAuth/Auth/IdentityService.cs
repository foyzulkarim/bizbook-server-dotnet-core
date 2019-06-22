using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Identity;

namespace B2BCoreApi.Auth
{
    public class IdentityService
    {
        private UserManager<ApplicationUser> userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


    }
}
