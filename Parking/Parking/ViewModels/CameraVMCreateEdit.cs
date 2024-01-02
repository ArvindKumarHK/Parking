using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Parking.Models;

namespace Parking.ViewModels
{
    public class CameraVMCreateEdit
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The Number of Letters must be greater than 4 and less than 50")]
        public string? Name { get; set; }

        [DisplayName("Index")]
        [Range(1, 16)]
        public int Index { get; set; }

        [Required]
        [DisplayName("Device Attached To")]
        public int DeviceId { get; set; }

        public Device Device { get; set; }

        [Required]
        [DisplayName("Resolution")]
        public int Resolution { get; set; }

        public List<Zone>? Zones { get; set; }
    }
}