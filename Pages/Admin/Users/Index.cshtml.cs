using LinBeach.Data;
using LinBeach.Models.ViewModels;
using LinBeach.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LinBeach.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserRep userRep;
        public List<User> Users { get; set; }

        [BindProperty]
        public AddUser addUser { get; set; }

        [BindProperty]
        public Guid UserId { get; set; }

        public IndexModel(IUserRep userRep)
        {
            this.userRep = userRep;
        }
        public async Task<IActionResult> OnGet()
        {
            var users = await userRep.GetAll();

            Users = new List<User>();
            foreach(var user in users) 
            {
                Users.Add(new Models.ViewModels.User()
                {
                    Id = Guid.Parse(user.Id),
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email
                });
                
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = new ApplicationUser
            {
                UserName = addUser.UserName,
                Email = addUser.Email,
                FullName = addUser.FullName,
            };
            var roles = new List<string>{ "User"};
            if (addUser.AdminRole)
            {
                roles.Add("Admin");
            }
            var result = await userRep.Add(user, addUser.Password, roles);
            if (result)
            {
                return RedirectToPage("/Admin/Users/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await userRep.Delete(UserId); 
            return RedirectToPage("/Admin/Users/Index");
        }

        public async Task<JsonResult> OnGetCheckUsername(string username)
        {
            // Directly check the database for the username
            var usernameExists = await userRep.UserNameExists(username);
            return new JsonResult(new { exists = usernameExists });
        }


        public async Task<JsonResult> OnGetCheckEmail(string email)
        {
            bool emailExists = await userRep.EmailExists(email);
            return new JsonResult(new { exists = emailExists });
        }

    }
}
