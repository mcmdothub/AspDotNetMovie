using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetMovie.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        public ICollection<Movie> Movies { get; set; }
            

    }
}
