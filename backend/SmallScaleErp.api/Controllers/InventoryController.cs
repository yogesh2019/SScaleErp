using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallScaleErp.api.Data;
using SmallScaleErp.api.Models;

namespace SmallScaleErp.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/inventory
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context.InventoryItems.ToListAsync();
            return Ok(items);
        }

        // POST: api/inventory
        [HttpPost]
        public async Task<IActionResult> Create(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }
}
