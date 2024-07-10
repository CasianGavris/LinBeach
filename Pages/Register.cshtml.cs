using LinBeach.Data;
using LinBeach.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace LinBeach.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        [BindProperty]
        public Register Register {  get; set; }
        public bool registerButton {  get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
         {
            if (!ModelState.IsValid)
            {
                registerButton = true;
                return Page();
            }

            var user = new ApplicationUser
            {
                UserName = Register.Username,
                FullName = Register.FullName,
                Email = Register.Email,
                PhoneNumber = Register.Phone,
                Birthdate = Register.Birthdate
            };

            var result = await userManager.CreateAsync(user, Register.Password);


            if (result.Succeeded)
            {
                var addRole = await userManager.AddToRoleAsync(user, "User");
                if(addRole.Succeeded)
                {
                    TempData["AlertMessage"] = "User registered successfully.";
                    await Task.Delay(1000);
                    return RedirectToPage("/Login");
                }

                
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
        public async Task<JsonResult> OnGetCheckUsername(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            return new JsonResult(new { exists = user != null });
        }

        public async Task<JsonResult> OnGetCheckEmail(string email)
        {
            var users = await userManager.Users.ToListAsync();
            var user = users.FirstOrDefault(u => u.Email == email);
            return new JsonResult(new { exists = user != null });
        }

        public async Task<JsonResult> OnGetCheckPhone(string phone)
        {
            var users = await userManager.Users.ToListAsync();
            var user = users.FirstOrDefault(u => u.PhoneNumber == phone);
            return new JsonResult(new { exists = user != null });
        }

    }
}

