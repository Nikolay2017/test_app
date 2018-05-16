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
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/MyUserInfoes")]
    public class MyUserInfoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MyUserInfoes
        public IQueryable<MyUserInfo> GetMyUserInfoes()
        {
            return db.MyUserInfoes;
        }

        // GET: api/MyUserInfoes/5
        [ResponseType(typeof(MyUserInfo))]
        public IHttpActionResult GetMyUserInfo(int id)
        {
            MyUserInfo myUserInfo = db.MyUserInfoes.Find(id);
            if (myUserInfo == null)
            {
                return NotFound();
            }

            return Ok(myUserInfo);
        }

        [HttpGet()]
        [Route("byTeamName/{UserId}")]
        public IHttpActionResult GetMyUserInfo2(string UserId)
        {
            MyUserInfo myUserInfo2 = db.MyUserInfoes.Where(o => o.UserId == UserId).FirstOrDefault();
            if (myUserInfo2 == null)
            {
                return NotFound();
            }

            return Ok(myUserInfo2);
        }
        [HttpGet()]
        [Route("byTeamName2/{Name}")]
        public IHttpActionResult GetMyUserInfo3(string Name)
        {
            MyUserInfo myUserInfo2 = db.MyUserInfoes.Where(o => o.Name == Name).FirstOrDefault();
            if (myUserInfo2 == null)
            {
                return NotFound();
            }

            return Ok(myUserInfo2);
        }

        // PUT: api/MyUserInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyUserInfo(int id, MyUserInfo myUserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myUserInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(myUserInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(id);
        }

        // POST: api/MyUserInfoes
        [ResponseType(typeof(MyUserInfo))]
        public IHttpActionResult PostMyUserInfo(MyUserInfo myUserInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyUserInfoes.Add(myUserInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myUserInfo.Id }, myUserInfo);
        }

        // DELETE: api/MyUserInfoes/5
        [ResponseType(typeof(MyUserInfo))]
        public IHttpActionResult DeleteMyUserInfo(int id)
        {
            MyUserInfo myUserInfo = db.MyUserInfoes.Find(id);
            if (myUserInfo == null)
            {
                return NotFound();
            }

            db.MyUserInfoes.Remove(myUserInfo);
            db.SaveChanges();

            return Ok(myUserInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyUserInfoExists(int id)
        {
            return db.MyUserInfoes.Count(e => e.Id == id) > 0;
        }
    }
}