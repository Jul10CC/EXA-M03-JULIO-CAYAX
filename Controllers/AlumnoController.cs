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
    public class AlumnoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Alumno
        //public IQueryable<Alumno> GetAlumnoes()
        //{
        //    return db.Alumnos;
        //}

        public IQueryable<AlumnoDTO> GetAlumnos()
        {
            var alumnos = from b in db.Alumnos
                         select new AlumnoDTO()
                         {
                             Id = b.AlumnoId,
                             Nombre = b.Nombre,
                             Apellido = b.Apellido,
                             CursoNombre = b.Curso.Nombre
                         };
            return alumnos;
        }

        // GET: api/Alumno/5
        //[ResponseType(typeof(Alumno))]
        //public async Task<IHttpActionResult> GetAlumno(int id)
        //{
        //    Alumno alumno = await db.Alumnos.FindAsync(id);
        //    if (alumno == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(alumno);
        //}
        [ResponseType(typeof(AlumnoDetalleDTO))]
        public async Task<IHttpActionResult> GetAlumno(int id)
        {
            var alumno = await db.Alumnos.Include(b => b.Curso).Select(b => new AlumnoDetalleDTO()
            {
                Id = b.AlumnoId,
                Nombre = b.Nombre,
                Apellido = b.Apellido,
                DPI = b.DPI,
                Edad = b.Edad,
                CursoNombre = b.Curso.Nombre,
                CatedraticoNombre = b.Curso.Catedratico.Nombre
            }).SingleOrDefaultAsync(b => b.Id == id);

            if (alumno == null)
                return NotFound();
            return Ok(alumno);
        }
        // PUT: api/Alumno/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumno.AlumnoId)
            {
                return BadRequest();
            }

            db.Entry(alumno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
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

        // POST: api/Alumno
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> PostAlumno(Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.Alumnos.Add(alumno);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            db.Entry(alumno).Reference(b => b.Curso).Load();

            var dto = new AlumnoDTO()
            {
                Id = alumno.AlumnoId,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                CursoNombre = alumno.Curso.Nombre
            };


            return CreatedAtRoute("DefaultApi", new { id = alumno.AlumnoId }, alumno);
        }

        // DELETE: api/Alumno/5
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> DeleteAlumno(int id)
        {
            Alumno alumno = await db.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            db.Alumnos.Remove(alumno);
            await db.SaveChangesAsync();

            return Ok(alumno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlumnoExists(int id)
        {
            return db.Alumnos.Count(e => e.AlumnoId == id) > 0;
        }
    }
}