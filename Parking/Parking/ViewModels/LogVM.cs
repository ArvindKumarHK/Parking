using Parking.Models;
using System.ComponentModel;

namespace Parking.ViewModels
{
    public class LogVM
    {
        public int Id { get; set; }

        public string DeviceName { get; set; }
        public string CameraName { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Zone")]
        public int ZoneId { get; set; }
        [DisplayName("Person")]
        public int Person { get; set; }
        [DisplayName("Car")]
        public int Car { get; set; }
        [DisplayName("Truck")]
        public int Truck { get; set; }
        [DisplayName("Motorbike")]
        public int Motorbike { get; set; }
        [DisplayName("Misc")]
        public int Misc { get; set; }
        [DisplayName("Parameters")]

        public LogType Type { get; set; }

        public string Parameters { get; set; } = string.Empty;
        [DisplayName("Timestamp")]

        public DateTime Timestamp { get; set; }
    }
}
