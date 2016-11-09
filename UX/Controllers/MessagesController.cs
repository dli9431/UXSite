using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DataModel;
using DataModel.Models;
using Microsoft.AspNet.Identity;

namespace UX.Controllers
{
    [RoutePrefix("api/Messages")]
    public class MessagesController : ApiController
    {
        private Entities db = new Entities();
                
        // GET: api/Messages
        public IQueryable<Message> GetMessages()
        {
            return db.Messages;
        }

        // GET: api/Messages/GetMsgs
        // Gets all of a user's messages
        [HttpGet]
        [Route("GetMsgs")]
        public IHttpActionResult GetMsgs(string id)
        {
            var current = HttpContext.Current.User.Identity.GetUserName();
            if (current == id)
            {
                var user = db.Users.FirstOrDefault(a => a.Email == id);
                var msgs = db.Messages.Where(a => a.ToDisplay == user.DisplayName).ToList();
                if (msgs.Count <= 0)
                {
                    return NotFound();
                }
                return Ok(msgs);
            }
            return NotFound();
        }

        //PUT: api/Messages/PutMsg
        //[HttpPut]
        [HttpPost]
        [Route("PutMsg")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMsg(string id = null, string to = null, string title = null, string body = null)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (id != null)
            {
                var fromUser = db.Users.FirstOrDefault(a => a.Email == id);
                if (to != null && title != null && body != null)
                {
                    Message msg = new Message
                    {
                        ToDisplay = to,
                        FromDisplay = fromUser.DisplayName,
                        Created = DateTime.Now,
                        Title = title,
                        Body = body
                    };
                    try
                    {
                        db.Messages.Add(msg);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
            }
                                   
            //db.Entry(message).State = EntityState.Modified;
            
            return StatusCode(HttpStatusCode.NoContent);
        }


        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.MessageID)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        [HttpPost]
        //[AcceptVerbs("GET", "POST")]
        [Route("SendMsg")]
        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messages.Add(message);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);

            //return CreatedAtRoute("DefaultApi", new { id = message.MessageID }, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        public IHttpActionResult DeleteMessage(int id)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Messages.Remove(message);
            db.SaveChanges();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return db.Messages.Count(e => e.MessageID == id) > 0;
        }
    }
}