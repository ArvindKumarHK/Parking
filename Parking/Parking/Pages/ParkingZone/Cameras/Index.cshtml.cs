using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Cameras
{
    public class IndexModel : PageModel
    {
        private readonly ParkingContext _context;

        public IndexModel(ParkingContext context)
        {
            _context = context;
        }


        public List<CameraVMCreateEdit> Cameras { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Cameras = await _context.Cameras
                .Select(d => new CameraVMCreateEdit
                {
                    Id = d.Id,
                    Name = d.Name,
                    Index = d.Index,
                    DeviceId = d.DeviceId,
                    Resolution = d.Resolution,
                })
                .ToListAsync();

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var camera = _context.Cameras.Find(id);

            if (camera == null)
            {
                return NotFound();
            }

            _context.Cameras.Remove(camera);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
