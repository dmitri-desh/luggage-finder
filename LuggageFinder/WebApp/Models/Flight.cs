using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [Phone(ErrorMessage = "The Phone field is not a valid format.")]
        public string Phone { get; set; }
        public string DestinationAddress { get; set; }

        [Required(ErrorMessage = "The Track Number field is required.")]
        public string TrackNumber { get; set; }
        public Status? Status { get; set; }


        public int? DepartureAirportId { get; set; }

        [ForeignKey("DepartureAirportId")]
        public virtual Airport DepartureAirport { get; set; }


        public int? ArrivalAirportId { get; set; }

        [ForeignKey("ArrivalAirportId")]
        public virtual Airport ArrivalAirport { get; set; }
    }
}
