using LinBeach.Data;
using LinBeach.Models.Domain;
using LinBeach.Models.ViewModels;
using LinBeach.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LinBeach.Pages.Admin.Events
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        
        private readonly IEventPostRep eventPostRep;

        public List<EventPost> EventPosts { get; set; }

        public ListModel(IEventPostRep eventPostRep)
        {
            this.eventPostRep = eventPostRep;
        }
        public async Task OnGet()
        {
            var alert = (string)TempData["Alert"];


            if (alert != null)
            {
                ViewData["Alert"] = JsonSerializer.Deserialize<Alerts>(alert);
            }
            EventPosts = (await eventPostRep.GetAllAsync())?.ToList();
        }
    }
}
