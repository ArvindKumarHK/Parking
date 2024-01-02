using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Cameras 
{
    public class CreateModel : PageModel
    {
        private readonly ParkingContext _context;

        public CreateModel(ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CameraVMCreateEdit Camera { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newCamera = new Camera
            {
                Name = Camera.Name,
                Index = Camera.Index,
                DeviceId = Camera.DeviceId,
                Resolution = Camera.Resolution,
                Zones = Camera.Zones,
            };

            _context.Cameras.Add(newCamera);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
