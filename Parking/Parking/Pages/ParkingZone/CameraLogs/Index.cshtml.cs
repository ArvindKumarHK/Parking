using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.ParkingZone.CameraLogs
{
    public class IndexModel : PageModel
    {
        private readonly ParkingContext _context;

        public IndexModel(ParkingContext context)
        {
            _context = context;
        }
        public List<CameraLog> CameraLogs { get; set; }
        public void OnGet()
        {
            // Retrieve camera logs from the database and assign to CameraLogs property
            CameraLogs = _context.CameraLogs.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var cameralog = _context.CameraLogs.Find(id);

            if (cameralog == null)
            {
                return NotFound();
            }

            _context.CameraLogs.Remove(cameralog);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
