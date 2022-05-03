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
using EXA_M03_JULIO_CAYAX.Models.DTO;

namespace EXA_M03_JULIO_CAYAX.Controllers
{
    public class CursoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Curso
        //public IQueryable<Curso> GetCursoes()
        //{
        //    return db.Cursos;
        //}
        public IQueryable<CursoDTO> GetCursos()
        {
            var cursos = from b in db.Cursos
                         select new CursoDTO()
                         {
                             Id = b.CursoId,
                             Nombre = b.Nombre,
                             CatedraticoNombre = b.Catedratico.Nombre
                         };
            return cursos;
        }
        // GET: api/Curso/5
        //[ResponseType(typeof(Curso))]
        //public async Task<IHttpActionResult> GetCurso(int id)
        //{
        //    Curso curso = await db.Cursos.FindAsync(id);
        //    if (curso == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(curso);
        //}
        [ResponseType(typeof(CursoDetalleDTO))]
        public async Task<IHttpActionResult> GetCurso(int id)
        {
            var curso = await db.Cursos.Include(b => b.Catedratico).Select(b => new CursoDetalleDTO()
            {
                Id = b.CursoId,
                Nombre = b.Nombre,
                Categoria = b.Categoria,
                Descripcion = b.Descripcion,
                CatedraticoNombre = b.Catedratico.Nombre
            }).SingleOrDefaultAsync(b => b.Id == id);

            if (curso == null)
                return NotFound();
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
            try
            {
                db.Cursos.Add(curso);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            db.Entry(curso).Reference(b => b.Catedratico).Load();

            var dto = new CursoDTO()
            {
                Id = curso.CursoId,
                Nombre = curso.Nombre,
                CatedraticoNombre = curso.Catedratico.Nombre
            };

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