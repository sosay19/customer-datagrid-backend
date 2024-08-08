using customer_datagrid_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace customer_datagrid_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-db-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // Try to get the Corporations table to test the connection
                var corporations = await _context.Corporations.ToListAsync();
                return Ok(corporations);
            }
            catch (Exception ex)
            {
                // Log the exception (you can also use a logger here)
                return StatusCode(500, new { message = "Database connection failed.", error = ex.Message });
            }
        }
    }
}
