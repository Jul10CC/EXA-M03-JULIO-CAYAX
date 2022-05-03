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
    public class CatedraticoController : ApiController
    {
        private Context db = new Context();

        // GET: api/Catedratico
        public IQueryable<Catedratico> GetCatedraticoes()
        {
            return db.Catedraticos;
        }

        // GET: api/Catedratico/5
        [ResponseType(typeof(Catedratico))]
        public async Task<IHttpActionResult> GetCatedratico(int id)
        {
            Catedratico catedratico = await db.Catedraticos.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return Ok(catedratico);
        }

        // PUT: api/Catedratico/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCatedratico(int id, Catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catedratico.CatedraticoId)
            {
                return BadRequest();
            }

            db.Entry(catedratico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatedraticoExists(id))
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

        // POST: api/Catedratico
        [ResponseType(typeof(Catedratico))]
        public async Task<IHttpActionResult> PostCatedratico(Catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catedraticos.Add(catedratico);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = catedratico.CatedraticoId }, catedratico);
        }

        // DELETE: api/Catedratico/5
        [ResponseType(typeof(Catedratico))]
        public async Task<IHttpActionResult> DeleteCatedratico(int id)
        {
            Catedratico catedratico = await db.Catedraticos.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            db.Catedraticos.Remove(catedratico);
            await db.SaveChangesAsync();

            return Ok(catedratico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatedraticoExists(int id)
        {
            return db.Catedraticos.Count(e => e.CatedraticoId == id) > 0;
        }
    }
}