using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.BonsaiTrees;

namespace Binary_Bonsai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonsaiTreeController : ControllerBase
    {
        private readonly BonsaiTreeRepository _repo;

        public BonsaiTreeController(BonsaiTreeRepository context)
        {
            _repo = context;
        }

        // GET: api/BonsaiTree
        [HttpGet]
        public Task<ActionResult<IEnumerable<BonsaiTree>>> GetBonsaiTree()
        {
            throw new NotImplementedException();
        }

        // GET: api/BonsaiTree/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BonsaiTree>> GetBonsaiTree(Guid id)
        {
          if (_repo.BonsaiTree == null)
          {
              return NotFound();
          }
            var bonsaiTree = await _repo.BonsaiTree.FindAsync(id);

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

            _repo.Entry(bonsaiTree).State = EntityState.Modified;

            try
            {
                await _repo.SaveChangesAsync();
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
          if (_repo.BonsaiTree == null)
          {
              return Problem("Entity set 'BonsaiTreeContext.BonsaiTree'  is null.");
          }
            _repo.BonsaiTree.Add(bonsaiTree);
            await _repo.SaveChangesAsync();

            return CreatedAtAction("GetBonsaiTree", new { id = bonsaiTree.Id }, bonsaiTree);
        }

        // DELETE: api/BonsaiTree/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBonsaiTree(Guid id)
        {
            if (_repo.BonsaiTree == null)
            {
                return NotFound();
            }
            var bonsaiTree = await _repo.BonsaiTree.FindAsync(id);
            if (bonsaiTree == null)
            {
                return NotFound();
            }

            _repo.BonsaiTree.Remove(bonsaiTree);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        private bool BonsaiTreeExists(Guid id)
        {
            return (_repo.BonsaiTree?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
