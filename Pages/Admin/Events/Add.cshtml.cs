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
    public class AddModel : PageModel
    {
        
        private readonly IEventPostRep eventPostRep;

        [BindProperty]
        public AddEvent AddEventRequest { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public AddModel(IEventPostRep eventPostRep)
        {
            
            this.eventPostRep = eventPostRep;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var eventPost = new EventPost()
            {
                Title = AddEventRequest.Title,
                Content = AddEventRequest.Content,
               
                ImageUrl = AddEventRequest.ImageUrl,
                UrlHandle = AddEventRequest.UrlHandle,
                EventDate = AddEventRequest.EventDate,
                
            };
            await eventPostRep.AddAsync(eventPost);

            var alert = new Alerts
            {
                Type = Enums.AlertType.Succes,
                Message = "New event added!"
            };

            TempData["Alert"] = JsonSerializer.Serialize(alert);
            return RedirectToPage("/Admin/Events/List");
        }
    }
}
