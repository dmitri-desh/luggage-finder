using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuggageFinder.Domain
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string DestinationAddress { get; set; }

        [Required(ErrorMessage = "The Track Number field is required.")]
        public string TrackNumber { get; set; }

        public Status? Status { get; set; }

        [Required(ErrorMessage = "The CreationDate field is required.")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModificationDate { get; set; }

        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public long? ArrivalAirportId { get; set; }

        [ForeignKey("ArrivalAirportId")]
        public virtual Airport ArrivalAirport { get; set; }

        public long? DepartureAirportId { get; set; }

        [ForeignKey("DepartureAirportId")]
        public virtual Airport DepartureAirport { get; set; }
    }
}