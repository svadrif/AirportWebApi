using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportWebApi.Models
{
    [Table("airport")]
    public class Airport
    {
        [Key]
        public int AirportId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Altitude { get; set; }
    }
}
