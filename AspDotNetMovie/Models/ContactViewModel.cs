using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetMovie.Models
{
    public class ContactViewModel
    {
        // tells that all this properties are required for sending us data 
        [Required]
        [MinLength(5)]      // to make sure is a real name
        public string Name { get; set; }

        [Required]
        [EmailAddress]      // need to fill a valid email address
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Too Long")]    // max 250 char
        public string Message { get; set; }
    }
}
