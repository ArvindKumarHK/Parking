using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Devices
{
    public class EditModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public EditModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeviceVMCreateEdit Devices { get; set; }

        public IActionResult OnGet(int id)
        {
            var device = _context.Devices.FirstOrDefault(e => e.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            // Create an instance of DeviceVM and populate it
            Devices = new DeviceVMCreateEdit
            {
                Id = device.Id,
                Name = device.Name,
                Location = device.Location,
                Network = device.Network,
                Node = device.Node,
                PowerInputType = device.PowerInputType,
                PowerState = device.PowerState,
                LastValue = device.LastValue,
                LastAlivePing = device.LastAlivePing
            };

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingDevice = _context.Devices.FirstOrDefault(e => e.Id == Devices.Id);
            if (existingDevice == null)
            {
                return NotFound();
            }
            existingDevice.Name = Devices.Name;
            existingDevice.Location = Devices.Location;
            existingDevice.Network = Devices.Network;
            existingDevice.Node = Devices.Node;
            existingDevice.PowerInputType = Devices.PowerInputType;
            existingDevice.PowerState = Devices.PowerState;
            existingDevice.LastValue = Devices.LastValue;
            existingDevice.LastAlivePing = Devices.LastAlivePing;


            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
