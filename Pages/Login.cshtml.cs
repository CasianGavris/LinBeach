using LinBeach.Data;
using LinBeach.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinBeach.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }
        public bool IsLoginSuccessful { get; set; }


        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(
                LoginViewModel.Username,
                LoginViewModel.Password,
                false ,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                IsLoginSuccessful = true;
                await Task.Delay(1000);
                return RedirectToPage("/Index");  // Redirect to the homepage or user dashboard
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid credentials";
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return Page();
            }
        }
    }
}
