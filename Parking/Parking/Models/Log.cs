using Parking.Models;
using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string CameraName { get; set; }
        public string Address { get; set; }
        public int ZoneId { get; set; }
        public int Person { get; set; }
        public int Car { get; set; }
        public int Truck { get; set; }
        public int Motorbike { get; set; }
        public int Misc { get; set; }
        public LogType Type { get; set; }
        public string Parameters { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
