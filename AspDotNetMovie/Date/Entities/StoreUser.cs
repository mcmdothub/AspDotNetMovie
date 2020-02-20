using Microsoft.AspNetCore.Identity;

namespace AspDotNetMovie.Models
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}