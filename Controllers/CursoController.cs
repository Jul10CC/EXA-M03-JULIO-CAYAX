using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EXA_M03_JULIO_CAYAX.Data;
using EXA_M03_JULIO_CAYAX.Models;

namespace EXA_M03_JULIO_CAYAX.Controllers
{
    public class CursoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Curso
        public IQueryable<Curso> GetCursoes()
        {
            return db.Cursos;
        }

        // GET: api/Curso/5
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> GetCurso(int id)
        {
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/Curso/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurso(int id, Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.CursoId)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Curso
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> PostCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cursos.Add(curso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = curso.CursoId }, curso);
        }

        // DELETE: api/Curso/5
        [ResponseType(typeof(Curso))]
        public async Task<IHttpActionResult> DeleteCurso(int id)
        {
            Curso curso = await db.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.Cursos.Remove(curso);
            await db.SaveChangesAsync();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursoExists(int id)
        {
            return db.Cursos.Count(e => e.CursoId == id) > 0;
        }
    }
}