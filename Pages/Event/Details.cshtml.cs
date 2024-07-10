using LinBeach.Models.Domain;
using LinBeach.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinBeach.Pages.Event
{
    public class DetailsModel : PageModel
    {
        private readonly IEventPostRep eventPostRep;

        public EventPost EventPost { get; set; }

        public DetailsModel(IEventPostRep eventPostRep)
        {
            this.eventPostRep = eventPostRep;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            EventPost = await eventPostRep.GetAsync(urlHandle);
            return Page();
        }
    }
}
