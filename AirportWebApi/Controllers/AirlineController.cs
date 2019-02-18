using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirportWebApi.Models;
using System;

namespace AirportWebApi.Controllers
{
    [Route("api/Airline")]
    public class AirlineController : Controller
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("alias")]

        public async Task<IActionResult> Alias()
        {
            try
            {
                var airlines = db.Airlines.ToList();
                return Ok(airlines);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("find/{alias}")]

        public async Task<IActionResult> Find(string alias)
        {
            try
            {
                var airline = db.Airlines.SingleOrDefault(x => x.Alias == alias);
                return Ok(airline);
            }
            catch             {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]

        public async Task<IActionResult> Create([FromBody] Airline airline)
        {
            try
            {
                db.Airlines.Add(airline);
                db.SaveChanges();
                return Ok(airline);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]

        public async Task<IActionResult> Update([FromBody] Airline airline)
        {
            try
            {
                db.Entry(airline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(airline);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                db.Remove(db.Airlines.Find(id));
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}