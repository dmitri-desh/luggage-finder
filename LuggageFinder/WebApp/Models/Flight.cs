using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DestinationAddress { get; set; }
        public string TrackNumber { get; set; }
        public Status Status { get; set; }        
        public int ArrivalAirportId { get; set; }
        public int DepartureAirportId { get; set; }

        [ForeignKey("ArrivalAirportId")]
        public virtual Airport ArrivalAirport { get; set; }

        [ForeignKey("DepartureAirportId")]
        public virtual Airport DepartureAirport { get; set; }
    }
}
