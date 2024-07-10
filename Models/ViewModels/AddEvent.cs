using System.ComponentModel.DataAnnotations;

namespace LinBeach.Models.ViewModels
{
    public class AddEvent
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime EventDate { get; set; }

        public bool IsVisible { get; set; }
    }
}
