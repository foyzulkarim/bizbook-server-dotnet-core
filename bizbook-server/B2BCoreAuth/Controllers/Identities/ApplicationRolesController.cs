using System;
using System.Linq;
using System.Threading.Tasks;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B2BCoreApi.Controllers.Identities
{
    [Route("api/ApplicationRoles")]
    [Authorize(Roles = "SuperAdmin")]
    public class ApplicationRolesController : Controller
    {
        private SecurityDbContext db;

        public ApplicationRolesController(SecurityDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetApplicationRole/{id}")]
        [ActionName("GetApplicationRole")]        
        public async Task<ActionResult> GetApplicationRole(string id)
        {
            ApplicationRole applicationRole = await db.ApplicationRoles.FindAsync(id);
            if (applicationRole == null)
            {
                return NotFound();
            }

            return Ok(applicationRole);
        }

        [HttpPut]
        [Route("PutApplicationRole")]
        [ActionName("PutApplicationRole")]        
        public async Task<ActionResult> PutApplicationRole(ApplicationRole applicationRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.Entry(applicationRole).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationRoleExists(applicationRole.Id))
                {
                    return NotFound();
                }
                throw;
            }

           return Ok(applicationRole);
        }

        [HttpPost]
        [Route("PostApplicationRole")]
        [ActionName("PostApplicationRole")]        
        public async Task<ActionResult> PostApplicationRole(ApplicationRole applicationRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            applicationRole.Id = Guid.NewGuid().ToString();
            db.ApplicationRoles.Add(applicationRole);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationRoleExists(applicationRole.Id))
                {
                    return Conflict();
                }
                throw;
            }
            return Ok(applicationRole.Id);
          //  return CreatedAtRoute("DefaultApi", new { id = applicationRole.Id }, applicationRole);
        }

        [HttpDelete]
        [Route("DeleteApplicationRole")]
        [ActionName("DeleteApplicationRole")]        
        public async Task<ActionResult> DeleteApplicationRole(string id)
        {
            ApplicationRole applicationRole = await db.ApplicationRoles.FindAsync(id);
            if (applicationRole == null)
            {
                return NotFound();
            }

            db.ApplicationRoles.Remove(applicationRole);
            await db.SaveChangesAsync();

            return Ok(applicationRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ApplicationRoleExists(string id)
        {            
            return db.ApplicationRoles.Count(e => e.Id == id) > 0;
        }
    }
}