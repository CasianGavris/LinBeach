using System;
using System.ComponentModel.DataAnnotations;

namespace LinBeach.Models.Domain
{
    public class EventPost
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        

        public string ImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime EventDate { get; set; }

        

        
    }
}

