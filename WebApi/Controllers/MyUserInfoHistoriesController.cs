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
    [RoutePrefix("api/MyUserInfoHistories")]
    public class MyUserInfoHistoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MyUserInfoHistories
        public IQueryable<MyUserInfoHistory> GetMyUserInfoHistories()
        {
            return db.MyUserInfoHistories;
        }
        [HttpGet()]
        [Route("byTeamName3/{UserId}")]
        public IQueryable<MyUserInfoHistory> GetMyUserInfoHistories2(string UserId)
        {
            foreach(var item in db.MyUserInfoHistories.Where(o => o.UserId == UserId))
            {
                item.Date= item.Date.ToUniversalTime();
            }
            return db.MyUserInfoHistories.Where(o=>o.UserId==UserId);
        }
        // GET: api/MyUserInfoHistories/5
        [ResponseType(typeof(MyUserInfoHistory))]
        public IHttpActionResult GetMyUserInfoHistory(int id)
        {
            MyUserInfoHistory myUserInfoHistory = db.MyUserInfoHistories.Find(id);
            if (myUserInfoHistory == null)
            {
                return NotFound();
            }

            return Ok(myUserInfoHistory);
        }

        // PUT: api/MyUserInfoHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyUserInfoHistory(int id, MyUserInfoHistory myUserInfoHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myUserInfoHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(myUserInfoHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserInfoHistoryExists(id))
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

        // POST: api/MyUserInfoHistories
        [ResponseType(typeof(MyUserInfoHistory))]
        public IHttpActionResult PostMyUserInfoHistory(MyUserInfoHistory myUserInfoHistory)
        {
            myUserInfoHistory.Date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyUserInfoHistories.Add(myUserInfoHistory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myUserInfoHistory.Id }, myUserInfoHistory);
        }

        // DELETE: api/MyUserInfoHistories/5
        [ResponseType(typeof(MyUserInfoHistory))]
        public IHttpActionResult DeleteMyUserInfoHistory(int id)
        {
            MyUserInfoHistory myUserInfoHistory = db.MyUserInfoHistories.Find(id);
            if (myUserInfoHistory == null)
            {
                return NotFound();
            }

            db.MyUserInfoHistories.Remove(myUserInfoHistory);
            db.SaveChanges();

            return Ok(myUserInfoHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyUserInfoHistoryExists(int id)
        {
            return db.MyUserInfoHistories.Count(e => e.Id == id) > 0;
        }
    }
}