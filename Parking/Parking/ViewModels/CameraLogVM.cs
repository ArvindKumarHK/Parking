using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Parking.ViewModels
{
    public class CameraLogVM
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int CameraId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
