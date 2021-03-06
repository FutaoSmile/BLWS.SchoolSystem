﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLWS.SchoolSystem.EF.Entity;
using BLWS.SchoolSystem.EF.SystemDbContext;

namespace BLWS.SchoolSystem.WebApi.Controllers
{
    public class SchoolsController : ApiController
    {
        private SystemDbContext db = new SystemDbContext();

        // GET: api/Schools
        public IQueryable<School> GetSchools()
        {
            return db.Schools;
        }

        // GET: api/Schools/5
        [ResponseType(typeof(School))]
        public IHttpActionResult GetSchool(int id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT: api/Schools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateSchool(int id, School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.ID)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        [ResponseType(typeof(School))]
        public IHttpActionResult PostSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Schools.Add(school);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school.ID }, school);
        }

        // DELETE: api/Schools/5
        [ResponseType(typeof(School))]
        [HttpPost]
        public IHttpActionResult DeleteSchool(int id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            db.Schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolExists(int id)
        {
            return db.Schools.Count(e => e.ID == id) > 0;
        }
    }
}