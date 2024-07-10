using LinBeach.Models.Domain;
using LinBeach.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinBeach.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEventPostRep eventPostRep;

        public List<EventPost> Events { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IEventPostRep eventPostRep)
        {
            _logger = logger;
            this.eventPostRep = eventPostRep;
        }

        public async Task<IActionResult> OnGet()
        {
            Events = (await eventPostRep.GetAllAsync())?.ToList();
            return Page();
        }
    }
}
