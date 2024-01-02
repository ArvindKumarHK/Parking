using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Users
{
    public class EditModel : PageModel
    {
        private readonly Parking.Data.ParkingContext _context;

        public EditModel(Parking.Data.ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserVMCreateEdit Users { get; set; }

        public IActionResult OnGet(int id)
        {
            var user = _context.Users.FirstOrDefault(e => e.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            // Create an instance of DeviceVM and populate it
            Users = new UserVMCreateEdit
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Enterprise = user.Enterprise,
                UserName = user.UserName,
                Password = user.Password,
                EmailId = user.EmailId,
                PhoneNumber = user.PhoneNumber,
            };

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingUser = _context.Users.FirstOrDefault(e => e.Id == Users.Id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.FirstName = Users.FirstName;
            existingUser.LastName = Users.LastName;
            existingUser.Enterprise = Users.Enterprise;
            existingUser.UserName = Users.UserName;
            existingUser.Password = Users.Password;
            existingUser.EmailId = Users.EmailId;
            existingUser.PhoneNumber = Users.PhoneNumber;


            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
