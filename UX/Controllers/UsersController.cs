using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataModel;
using DataModel.Models;
using System.Web;
using System.Web.Script.Serialization;

namespace UX.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private Entities db = new Entities();

        [HttpGet]
        [Route("GetUsers")]
        // GET: api/GetUsers
        //public IQueryable<ApplicationUser> GetUsers()
        public List<string> GetUsers()
        {
            return db.Users.Select(a => a.DisplayName).ToList();

            //IQueryable<ApplicationUser> list = db.Users.ToList;
            //return list;
        }

        [HttpGet]
        [Route("GetCurrent")]
        // GET: api/GetCurrentUser
        public IHttpActionResult GetCurrentUser()
        {
            var current = HttpContext.Current.User.Identity.Name;
            //ApplicationUser user = db.ApplicationUsers.Find(current);
            var user = db.Users.FirstOrDefault(a => a.UserName == current);
            if (user == null)
            {
                return NotFound();
            }
            //return Ok(new JavaScriptSerializer().Serialize(user.DisplayName));
            return Ok(user.DisplayName);
        }

        // GET: api/Users/5
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetApplicationUser(string id)
        {
            //ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
            var applicationUser = db.Users.FirstOrDefault(a => a.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        [HttpPut]
        [Route("PutUser")]
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicationUser(string id, ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            db.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult PostApplicationUser(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(applicationUser);
            //db.ApplicationUsers.Add(applicationUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApplicationUserExists(applicationUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult DeleteApplicationUser(string id)
        {
            //ApplicationUser applicationUser = db.A  pplicationUsers.Find(id);
            var applicationUser = db.Users.FirstOrDefault(a => a.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            //db.ApplicationUsers.Remove(applicationUser);
            db.Users.Remove(applicationUser);
            db.SaveChanges();

            return Ok(applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(string id)
        {
            return db.Users.Count(a => a.Id == id) > 0;
            //return db.ApplicationUsers.Count(e => e.Id == id) > 0;
        }
    }
}