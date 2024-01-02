using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Models
{
    public class CameraLog
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int CameraId { get; set; }
        public string? ImagePath { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Data { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
