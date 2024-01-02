using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Users
{
    public class CreateModel : PageModel
    {
        private readonly ParkingContext _context;

        public CreateModel(ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserVMCreateEdit User { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var newUser = new User
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                Enterprise = User.Enterprise,
                UserName = User.UserName,
                Password = User.Password,
                EmailId = User.EmailId,
                PhoneNumber = User.PhoneNumber,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
