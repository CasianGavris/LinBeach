namespace LinBeach.Data
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
    }

}
