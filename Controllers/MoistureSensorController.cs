using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.MoistureSensors;

namespace Binary_Bonsai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoistureSensorController : ControllerBase
    {
        private readonly MoistureSensorRepository _repo;

        public MoistureSensorController(MoistureSensorRepository context)
        {
            _repo=context;
        }

        // GET: api/MoistureSensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoistureSensor>>> GetMoistureSensor()
        {
          if (_repo.MoistureSensor == null)
          {
              return NotFound();
          }
            return await _repo.MoistureSensor.ToListAsync();
        }

        // GET: api/MoistureSensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoistureSensor>> GetMoistureSensor(Guid id)
        {
          if (_repo.MoistureSensor == null)
          {
              return NotFound();
          }
            var moistureSensor = await _repo.MoistureSensor.FindAsync(id);

            if (moistureSensor == null)
            {
                return NotFound();
            }

            return moistureSensor;
        }

        // PUT: api/MoistureSensor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoistureSensor(Guid id, MoistureSensor moistureSensor)
        {
            if (id != moistureSensor.Id)
            {
                return BadRequest();
            }

            _repo.Entry(moistureSensor).State = EntityState.Modified;

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoistureSensorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MoistureSensor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MoistureSensor>> PostMoistureSensor(MoistureSensor moistureSensor)
        {
          if (_repo.MoistureSensor == null)
          {
              return Problem("Entity set 'MoistureSensorRecord.MoistureSensor'  is null.");
          }
            _repo.MoistureSensor.Add(moistureSensor);
            await _repo.SaveChangesAsync();

            return CreatedAtAction("GetMoistureSensor", new { id = moistureSensor.Id }, moistureSensor);
        }

        // DELETE: api/MoistureSensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoistureSensor(Guid id)
        {
            if (_repo.MoistureSensor == null)
            {
                return NotFound();
            }
            var moistureSensor = await _repo.MoistureSensor.FindAsync(id);
            if (moistureSensor == null)
            {
                return NotFound();
            }

            _repo.MoistureSensor.Remove(moistureSensor);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        private bool MoistureSensorExists(Guid id)
        {
            return (_repo.MoistureSensor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
