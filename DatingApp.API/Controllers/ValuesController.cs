using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
           var values = await _context.Values.ToListAsync();
            return Ok(values);
           // return "Test";
          //  return null;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var values =await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(values);
            //return null;
        }
    }
}