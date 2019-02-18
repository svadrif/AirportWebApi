using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirportWebApi.Models;
using System;

namespace AirportWebApi.Controllers
{
    [Route("api/Airport")]

    public class AirportController : Controller
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("search/{search}")]

        public async Task<IActionResult> Search(string search)
        {
            try
            {
                var airports = db.Airports.Where(x => x.Alias == search || x.Name == search || x.City == search || x.Country == search).ToList();
                return Ok(airports);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]

        public async Task<IActionResult> Create([FromBody] Airport airport)
        {
            try
            {
                db.Airports.Add(airport);
                db.SaveChanges();
                return Ok(airport);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]

        public async Task<IActionResult> Update([FromBody] Airport airport)
        {
            try
            {
                db.Entry(airport).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(airport);
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
                db.Remove(db.Airports.Find(name));
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