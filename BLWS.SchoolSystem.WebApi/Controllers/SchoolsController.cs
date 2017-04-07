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
using BLWS.SchoolSystem.EF.Entity;
using BLWS.SchoolSystem.EF.SystemDbContext;
using Newtonsoft.Json;

namespace BLWS.SchoolSystem.WebApi.Controllers
{
    public class SchoolsController : ApiController
    {
        private SystemDbContext db = new SystemDbContext();

        /// <summary>
        /// 获取所有学校的信息
        /// </summary>
        /// <returns></returns>
        // GET: api/Schools
        public IQueryable<School> GetSchools()
        {
            return db.Schools;
        }

        /// <summary>
        /// 通过ID获取一所学校
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 修改学校的信息
        /// </summary>
        /// <param name="id">学校的ID</param>
        /// <param name="school">学校对象</param>
        /// <returns></returns>
        // PUT: api/Schools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult SchoolUpdate(int id, School school)
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

        /// <summary>
        /// 新增学校
        /// </summary>
        /// <param name="school">学校的对象</param>
        /// <returns></returns>
        // POST: api/Schools
        [HttpPost]
        [ResponseType(typeof(School))]
        public IHttpActionResult SchoolPost(School school)
        {
            //school = JsonConvert.DeserializeObject<School>(thx);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Schools.Add(school);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school.ID }, school);
        }

        /// <summary>
        /// 删除学校
        /// </summary>
        /// <param name="id">学校ID</param>
        /// <returns></returns>
        // DELETE: api/Schools/5
        [HttpPost]
        [ResponseType(typeof(School))]
        public IHttpActionResult SchoolDelete(int id)
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