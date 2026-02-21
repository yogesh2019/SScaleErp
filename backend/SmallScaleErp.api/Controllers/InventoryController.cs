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

        // GET: api/inventory?page=1&pageSize=5
[HttpGet]
public async Task<IActionResult> Get(int page = 1, int pageSize = 5)
{
    var totalRecords = await _context.InventoryItems.CountAsync();

    var items = await _context.InventoryItems
        .OrderBy(i => i.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return Ok(new
    {
        totalRecords,
        page,
        pageSize,
        data = items
    });
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
