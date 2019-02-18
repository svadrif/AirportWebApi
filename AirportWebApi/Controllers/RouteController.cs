using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirportWebApi.Models;

namespace AirportWebApi.Controllers
{
    [Route("api/Route")]

    public class RouteController : ControllerBase
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("search/{outgoing}")]

        public async Task<IActionResult> Search(string outgoing)
        {
            try
            {
                var routes = db.Routes.Where(x => x.srcAirport == outgoing).ToList();
                return Ok(routes);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]

        public async Task<IActionResult> Create([FromBody] Route route)
        {
            try
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return Ok(route);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]

        public async Task<IActionResult> Update([FromBody] Route route)
        {
            try
            {
                db.Entry(route).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(route);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete/{name}")]

        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                db.Remove(db.Routes.Find(name));
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