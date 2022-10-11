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
using MyApi.Entities;
using MyApi.Models;

namespace MyApi.Controllers
{
    public class Personal_InfController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/Personal_Inf
        [ResponseType(typeof(List<ProfileModel>))]
        public IHttpActionResult GetProfiles()
        {
            return Ok(db.Personal_Inf.ToList().ConvertAll(x => new ProfileModel(x)));
        }

        // GET: api/Personal_Inf/5
        [ResponseType(typeof(Personal_Inf))]
        public IHttpActionResult GetPersonal_Inf(int id)
        {
            Personal_Inf personal_Inf = db.Personal_Inf.Find(id);
            if (personal_Inf == null)
            {
                return NotFound();
            }

            return Ok(personal_Inf);
        }

        // PUT: api/Personal_Inf/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonal_Inf(int id, Personal_Inf personal_Inf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personal_Inf.id)
            {
                return BadRequest();
            }

            db.Entry(personal_Inf).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Personal_InfExists(id))
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

        // POST: api/Personal_Inf
        [ResponseType(typeof(Personal_Inf))]
        public IHttpActionResult PostPersonal_Inf(Personal_Inf personal_Inf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personal_Inf.Add(personal_Inf);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personal_Inf.id }, personal_Inf);
        }

        // DELETE: api/Personal_Inf/5
        [ResponseType(typeof(Personal_Inf))]
        public IHttpActionResult DeletePersonal_Inf(int id)
        {
            Personal_Inf personal_Inf = db.Personal_Inf.Find(id);
            if (personal_Inf == null)
            {
                return NotFound();
            }

            db.Personal_Inf.Remove(personal_Inf);
            db.SaveChanges();

            return Ok(personal_Inf);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Personal_InfExists(int id)
        {
            return db.Personal_Inf.Count(e => e.id == id) > 0;
        }
    }
}