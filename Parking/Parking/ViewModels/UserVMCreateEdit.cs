using Parking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Parking.ViewModels
{
    public class UserVMCreateEdit
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The Number of Letters must be greater than 4 and less than 50")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The Number of Letters must be greater than 4 and less than 50")]
        public string? LastName { get; set; }

        [Required]
        [DisplayName("Enterprise")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The Number of Letters must be greater than 4 and less than 50")]
        public string? Enterprise { get; set; }

        [Required]
        [DisplayName("User Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The Number of Letters must be greater than 4 and less than 50")]
        public string? UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string? Password { get; set; }

        [Required]
        [DisplayName("EmailId")]
        public string? EmailId { get; set; }

        [Required]
        [DisplayName("PhoneNumber")]
        public string? PhoneNumber { get; set; }
    }
}
