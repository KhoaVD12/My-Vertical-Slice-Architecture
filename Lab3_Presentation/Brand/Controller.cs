using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_Presentation.Brand
{
    [Route("api/Brand")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly Database.Context _context;
        public Controller(Database.Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var parameters = await _context.Brand.ToListAsync();
            return Ok(parameters);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var parameter = await _context.Handbag.FindAsync(id);
            if (parameter == null)
            {
                return NotFound();
            }
            return Ok(parameter);
        }
    }
}
