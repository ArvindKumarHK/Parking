using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.CameraLogs
{
    public class CreateModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public CreateModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        [BindProperty]
        public CameraLogVM ViewModel { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || ViewModel == null)
            {
                return Page();
            }

            // Map ViewModel to Device entity
            var newCameraLog = new CameraLog
            {
                // Map ViewModel properties to Device properties
                // For example:
                DeviceId = ViewModel.DeviceId,
                CameraId = ViewModel.CameraId,
                ImagePath = ViewModel.ImagePath,
                //Timestamp = DateTime.Now,
                // Map other properties accordingly
            };

            _context.CameraLogs.Add(newCameraLog);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
