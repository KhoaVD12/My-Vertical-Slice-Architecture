using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_Presentation.Handbag;

[Route("api/Handbag")]
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
        var handbags = await _context.Handbag.ToListAsync();
        return Ok(handbags);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var handbag = await _context.Handbag.FindAsync(id);
        if (handbag == null)
        {
            return NotFound();
        }
        return Ok(handbag);
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] Create.Payload payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var handbag = new Database.Tables.Handbag.Table
        {
            ModelName = payload.ModelName,
            Material = payload.Material,
            Price = payload.Price,
            Stock = payload.Stock,
            BrandID = payload.BrandId
        };
        _context.Handbag.Add(handbag);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = handbag.HandbagID }, handbag);
    }
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(int id, [FromBody] Update.Payload payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var handbag = await _context.Handbag.FindAsync(id);
        if (handbag == null)
        {
            return NotFound();
        }
        var existBrand = await _context.Brand.FindAsync(payload.BrandId);   
        if (payload.ModelName is not null && payload.ModelName is not null)
            handbag.ModelName = payload.ModelName;
        if(payload.Material is not null && payload.Material is not null)
            handbag.Material = payload.Material;
        if (payload.Price.HasValue)
            handbag.Price = (decimal)payload.Price;
        if (payload.Stock.HasValue)
            handbag.Stock = (int)payload.Stock;
        if (payload.BrandId.HasValue&&existBrand is not null)
            handbag.BrandID = (int)payload.BrandId;
        _context.Handbag.Update(handbag);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var handbag = await _context.Handbag.FindAsync(id);
        if (handbag == null)
        {
            return NotFound();
        }
        _context.Handbag.Remove(handbag);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpGet("search")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Search([FromQuery] string modelName)
    {
        if (string.IsNullOrEmpty(modelName))
        {
            return BadRequest("Model name is required.");
        }
        var handbags = await _context.Handbag
            .Where(h => h.ModelName.Contains(modelName, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
        if (!handbags.Any())
        {
            return NotFound("No handbags found with the specified model name.");
        }
        return Ok(handbags);
    }
}
