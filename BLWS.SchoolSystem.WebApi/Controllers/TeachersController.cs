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

namespace BLWS.SchoolSystem.WebApi.Controllers
{
    public class TeachersController : ApiController
    {
        private SystemDbContext db = new SystemDbContext();

        /// <summary>
        /// 获取所有教师信息
        /// </summary>
        /// <returns></returns>
        // GET: api/Teachers
        public IQueryable<Teacher> GetTeachers()
        {
            return db.Teahers;
        }

        /// <summary>
        /// 通过ID获取单个教师信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Teachers/5
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult GetTeacher(int id)
        {
            Teacher teacher = db.Teahers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        public IQueryable<Teacher> GetTeachersByCourse(string course)
        {
            return db.Teahers.Where(u=>u.CourseName==course);
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        // PUT: api/Teachers/5
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeacher(int id, Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.ID)
            {
                return BadRequest();
            }

            db.Entry(teacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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
        /// 新增教师
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        // POST: api/Teachers
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult PostTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teahers.Add(teacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacher.ID }, teacher);
        }
        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Teachers/5
        [HttpPost]
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult DeleteTeacher(int id)
        {
            Teacher teacher = db.Teahers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            db.Teahers.Remove(teacher);
            db.SaveChanges();

            return Ok(teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherExists(int id)
        {
            return db.Teahers.Count(e => e.ID == id) > 0;
        }
    }
}