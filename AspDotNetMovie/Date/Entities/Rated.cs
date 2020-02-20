using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetMovie.Models
{
    public class Rated
    {
        [Key]
        public int RatedId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Movie> Movies { get; set; }

        /*
        G – General Audiences
            All ages admitted.Nothing that would offend parents for viewing by children.

        PG – Parental Guidance Suggested
            Some material may not be suitable for children.Parents urged to give "parental guidance". May contain some material parents might not like for their young children.
            
        PG-13 – Parents Strongly Cautioned
            Some material may be inappropriate for children under 13. Parents are urged to be cautious. Some material may be inappropriate for pre-teenagers.

        R – Restricted
            Under 17 requires accompanying parent or adult guardian. Contains some adult material. Parents are urged to learn more about the film before taking their young children with them.

        NC-17 – Adults Only
            No One 17 and Under Admitted. Clearly adult. Children are not admitted.
        */
    }
}
