using login_backend.Db;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace login_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testConectDb : ControllerBase
    {
        private readonly AppDbContext _context;
        public testConectDb(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection(CancellationToken cancellation) { 
            bool testConnection=await _context.Database.CanConnectAsync(cancellation);
            if (testConnection)
            {
                return Ok(new { status = "success", message = "conexion is sucefull" });

            }
            else
            {
                return StatusCode(500,new { status = "error", message = "conexion is down" });
            }
        
        }


    }
}
