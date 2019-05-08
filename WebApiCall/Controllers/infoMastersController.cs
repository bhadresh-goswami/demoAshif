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
using WebApiCall.Models;
using System.Web.Http.Cors;

namespace WebApiCall.Controllers
{
    [EnableCors("*","*","*")]
    public class infoMastersController : ApiController
    {
        private dbModel db = new dbModel();

        // GET: api/infoMasters
        public IQueryable<infoMaster> GetinfoMasters()
        {
            return db.infoMasters;
        }

        // GET: api/infoMasters/5
        [ResponseType(typeof(infoMaster))]
        public IHttpActionResult GetinfoMaster(int id)
        {
            infoMaster infoMaster = db.infoMasters.Find(id);
            if (infoMaster == null)
            {
                return NotFound();
            }

            return Ok(infoMaster);
        }

        // PUT: api/infoMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutinfoMaster(int id, infoMaster infoMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != infoMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(infoMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!infoMasterExists(id))
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

        // POST: api/infoMasters => Create
        [ResponseType(typeof(infoMaster))]
        public IHttpActionResult PostinfoMaster(infoMaster infoMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.infoMasters.Add(infoMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = infoMaster.Id }, infoMaster);
        }

        // DELETE: api/infoMasters/5
        [ResponseType(typeof(infoMaster))]
        public IHttpActionResult DeleteinfoMaster(int id)
        {
            infoMaster infoMaster = db.infoMasters.Find(id);
            if (infoMaster == null)
            {
                return NotFound();
            }

            db.infoMasters.Remove(infoMaster);
            db.SaveChanges();

            return Ok(infoMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool infoMasterExists(int id)
        {
            return db.infoMasters.Count(e => e.Id == id) > 0;
        }
    }
}