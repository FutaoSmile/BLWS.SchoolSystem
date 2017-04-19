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
    public class ScoreTablesController : ApiController
    {
        private SystemDbContext db = new SystemDbContext();

        // GET: api/ScoreTables
        public IQueryable<ScoreTable> GetScoreTables()
        {
            return db.ScoreTables;
        }
        /// <summary>
        /// 获取每门课的选课人数
        /// </summary>
        /// <param name="CourseName">课程名称</param>
        /// <returns>已选该门课的人数</returns>
        [HttpGet]
        public int CountByCourseName(string CourseName) {
            return db.ScoreTables.Where(u => u.CourseName == CourseName).Count();
        }


        // GET: api/ScoreTables/5
        [ResponseType(typeof(ScoreTable))]
        public IHttpActionResult GetScoreTable(int id)
        {
            ScoreTable scoreTable = db.ScoreTables.Find(id);
            if (scoreTable == null)
            {
                return NotFound();
            }

            return Ok(scoreTable);
        }

        // PUT: api/ScoreTables/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutScoreTable(int id, ScoreTable scoreTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scoreTable.ID)
            {
                return BadRequest();
            }

            db.Entry(scoreTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreTableExists(id))
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

        // POST: api/ScoreTables
        [ResponseType(typeof(ScoreTable))]
        public IHttpActionResult PostScoreTable(ScoreTable scoreTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScoreTables.Add(scoreTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = scoreTable.ID }, scoreTable);
        }

        // DELETE: api/ScoreTables/5
        [ResponseType(typeof(ScoreTable))]
        public IHttpActionResult DeleteScoreTable(int id)
        {
            ScoreTable scoreTable = db.ScoreTables.Find(id);
            if (scoreTable == null)
            {
                return NotFound();
            }

            db.ScoreTables.Remove(scoreTable);
            db.SaveChanges();

            return Ok(scoreTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScoreTableExists(int id)
        {
            return db.ScoreTables.Count(e => e.ID == id) > 0;
        }
    }
}