using Lab3_Presentation.Authentication.SignIn;
using Lab3_Presentation.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3_Presentation.Authentication;

[Route("api/auth")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly Database.Context _context;
    private readonly JWT _jwt;
    public Controller(Database.Context context, IConfiguration configuration)
    {
        _context = context;
        _jwt = new JWT(configuration);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SignIn.Payload payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var account = await _context.SystemAccounts
            .FirstOrDefaultAsync(a => a.Email == payload.Email && a.Password == payload.Password);
        if (account == null)
        {
            return Unauthorized();
        }
        var roleName = Enum.GetName(typeof(Role), account.Role);
        if(roleName is null)
        {
            return BadRequest("Invalid role.");
        }
        var token= _jwt.GenerateToken(payload.Email,roleName);
        var result = new SignIn.Result
        {
            Token = token, // Replace with actual token generation logic
            Role = roleName
        };
        return Ok(result);
    }
}
