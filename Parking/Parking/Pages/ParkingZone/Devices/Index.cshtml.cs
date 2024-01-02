using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Devices
{
    public class IndexModel : PageModel
    {
        private readonly ParkingContext _context;

        public IndexModel(ParkingContext context)
        {
            _context = context;
        }


        public List<DeviceVMCreateEdit> Devices { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Devices = await _context.Devices
                .Select(d => new DeviceVMCreateEdit
                {
                    Id = d.Id,
                    Name = d.Name,
                    Location = d.Location,
                    Network = d.Network,
                    Node = d.Node,
                    PowerInputType = d.PowerInputType,
                    PowerState = d.PowerState,
                    LastValue = d.LastValue,
                    LastAlivePing = d.LastAlivePing
                })
                .ToListAsync();

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var device = _context.Devices.Find(id);

            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
