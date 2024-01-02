using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Devices
{
    public class CreateModel : PageModel
    {
        private readonly ParkingContext _context;

        public CreateModel(ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeviceVMCreateEdit Device { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var newDevice = new Device
            {
                Name = Device.Name,
                Location = Device.Location,
                PowerInputType = Device.PowerInputType,
                Network = Device.Network,
                Node = Device.Node,
                LastValue = Device.LastValue,
                LastAlivePing = DateTime.UtcNow,
            };

            _context.Devices.Add(newDevice);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
