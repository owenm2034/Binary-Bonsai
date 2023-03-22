using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BonsaiTrees;

namespace Binary_Bonsai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonsaiTreeController : ControllerBase
    {
        private readonly BonsaiTreeContext _context;

        public BonsaiTreeController(BonsaiTreeContext context)
        {
            _context = context;
        }

        // GET: api/BonsaiTree
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BonsaiTree>>> GetBonsaiTree()
        {
          if (_context.BonsaiTree == null)
          {
              return NotFound();
          }
            return await _context.BonsaiTree.ToListAsync();
        }

        // GET: api/BonsaiTree/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BonsaiTree>> GetBonsaiTree(Guid id)
        {
          if (_context.BonsaiTree == null)
          {
              return NotFound();
          }
            var bonsaiTree = await _context.BonsaiTree.FindAsync(id);

            if (bonsaiTree == null)
            {
                return NotFound();
            }

            return bonsaiTree;
        }

        // PUT: api/BonsaiTree/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBonsaiTree(Guid id, BonsaiTree bonsaiTree)
        {
            if (id != bonsaiTree.Id)
            {
                return BadRequest();
            }

            _context.Entry(bonsaiTree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BonsaiTreeExists(id))
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

        // POST: api/BonsaiTree
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BonsaiTree>> PostBonsaiTree(BonsaiTree bonsaiTree)
        {
          if (_context.BonsaiTree == null)
          {
              return Problem("Entity set 'BonsaiTreeContext.BonsaiTree'  is null.");
          }
            _context.BonsaiTree.Add(bonsaiTree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBonsaiTree", new { id = bonsaiTree.Id }, bonsaiTree);
        }

        // DELETE: api/BonsaiTree/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBonsaiTree(Guid id)
        {
            if (_context.BonsaiTree == null)
            {
                return NotFound();
            }
            var bonsaiTree = await _context.BonsaiTree.FindAsync(id);
            if (bonsaiTree == null)
            {
                return NotFound();
            }

            _context.BonsaiTree.Remove(bonsaiTree);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BonsaiTreeExists(Guid id)
        {
            return (_context.BonsaiTree?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
