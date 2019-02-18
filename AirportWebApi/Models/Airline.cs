using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportWebApi.Models
{
    [Table("airline")]
    public class Airline
    {
        [Key]
        public int AirlineId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Alias { get; set; }
        public bool Active { get; set; }
    }
}
