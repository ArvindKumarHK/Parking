using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Logs
{
    public class CreateModel : PageModel
    {
        private readonly ParkingContext _context;

        public CreateModel(ParkingContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LogVM NewLog { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newLog = new Log
            {

                DeviceName = NewLog.DeviceName,
                CameraName = NewLog.CameraName,
                Address = NewLog.Address,
                ZoneId = NewLog.ZoneId,
                Person = NewLog.Person,
                Car = NewLog.Car,
                Truck = NewLog.Truck,
                Motorbike = NewLog.Motorbike,
                Misc = NewLog.Misc,
                Type = NewLog.Type,
                Parameters = NewLog.Parameters,
                Timestamp = DateTime.UtcNow // Use UTC time to avoid time zone issues
            };

            _context.Logs.Add(newLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
