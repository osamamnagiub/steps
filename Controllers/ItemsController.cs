using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreWebApplication.Data;
using ASP.NETCoreWebApplication.DTOs;
using ASP.NETCoreWebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.Controllers
{
    public class ItemsController : BaseApiController
    {
        private readonly DataContext _context;

        public ItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{stepId:int}")]
        public async Task<List<Item>> GetStepItems(int stepId)
        {
            return await _context.Items
                .Where(s => s.StepId == stepId).ToListAsync();
        }


        [HttpPut("{itemId:int}")]
        public async Task<ActionResult<Item>> UpdateItem(int itemId, ItemDto itemDto)
        {
            var item = await _context.Items.FindAsync(itemId);
            if (item == null) return NotFound();

            item.Title = itemDto.Title;
            item.Description = itemDto.Description;

            await _context.SaveChangesAsync();

            return item;
        }


        [HttpDelete("{stepId:int}/{itemId:int}")]
        public async Task<ActionResult<Item>> DeleteItem(int stepId, int itemId)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId && i.StepId == stepId);
            if (item == null) return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}