using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NETCoreWebApplication.Data;
using ASP.NETCoreWebApplication.DTOs;
using ASP.NETCoreWebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Controllers
{
    public class StepsController : BaseApiController
    {
        private readonly DataContext _context;

        public StepsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Step>>> GetSteps()
        {
            var steps = await _context.Steps
                .Include(s => s.Items).ToListAsync();

            return steps;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStep(int id)
        {
            var step = await _context.Steps.FindAsync(id);

            return step;
        }


        [HttpPost]
        public async Task<ActionResult<Step>> AddStep()
        {
            var step = new Step();
            _context.Steps.Add(step);
            await _context.SaveChangesAsync();

            return step;
        }


        [HttpPost("{stepId:int}/items")]
        public async Task<ActionResult<Step>> AddItem(int stepId, ItemDto itemDto)
        {
            var step = await _context.Steps.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == stepId);
            if (step == null) return NotFound();

            step.AddNewItem(itemDto);
            await _context.SaveChangesAsync();

            return step;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Step>> DeleteStep(int id)
        {
            var step = await _context.Steps.FindAsync(id);
            if (step == null) return NotFound();

            _context.Steps.Remove(step);
            await _context.SaveChangesAsync();

            return step;
        }
    }
}