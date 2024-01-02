using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Users
{
    public class IndexModel : PageModel
    {
        private readonly ParkingContext _context;

        public IndexModel(ParkingContext context)
        {
            _context = context;
        }


        public List<UserVMCreateEdit> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _context.Users
                .Select(d => new UserVMCreateEdit
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Enterprise = d.Enterprise,
                    UserName = d.UserName,
                    Password = d.Password,
                    EmailId = d.EmailId,
                    PhoneNumber = d.PhoneNumber,
                })
                .ToListAsync();

            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}
