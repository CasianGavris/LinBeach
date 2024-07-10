using LinBeach.Data;
using LinBeach.Models.Domain;
using LinBeach.Models.ViewModels;
using LinBeach.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LinBeach.Pages.Admin.Events
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        
        private readonly IEventPostRep eventPostRep;

        [BindProperty]
        public EventPost eventPost { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public EditModel(IEventPostRep eventPostRep)
        {
            
            this.eventPostRep = eventPostRep;
        }
        public async Task OnGet(Guid Id)
        {
            eventPost = await eventPostRep.GetAsync(Id);
           
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                
                await eventPostRep.UpdateAsync(eventPost);
                ViewData["Alert"] = new Alerts
                {
                    Message = "Event updated succesfully",
                    Type = Enums.AlertType.Succes
                };
            }
            catch (Exception e)
            {
                ViewData["Alert"] = new Alerts
                {
                    Message = "Something went wrong(" + e + ")",
                    Type = Enums.AlertType.Error
                };
                
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await eventPostRep.DeleteAsync(eventPost.Id);
            if (deleted)
            {
                var alert = new Alerts
                {
                    Type = Enums.AlertType.Succes,
                    Message = "Event deleted succesfully"
                };

                TempData["Alert"] = JsonSerializer.Serialize(alert);
                return RedirectToPage("/Admin/Events/List");
            }else return Page();
            
            
        }
    }
}
