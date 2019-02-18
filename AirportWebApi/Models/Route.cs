using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportWebApi.Models
{
    [Table("route")]
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        [StringLength(3, MinimumLength = 2)]
        public string Airline { get; set; }
        [StringLength(4, MinimumLength = 3)]
        public string srcAirport { get; set; }
        [StringLength(4, MinimumLength = 3)]
        public string destAirport { get; set; }
    }
}
