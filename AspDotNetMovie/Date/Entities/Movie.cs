using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetMovie.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Poster_path { get; set; }


        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        // public string GenreId { get; set; }

        public DateTime? Released { get; set; }


        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        // public string LanguageId { get; set; }

        public string Overview { get; set; }

        [ForeignKey("RatedId")]
        public Rated Rated { get; set; }

        public string IMDB_Rating { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string ISBN { get; set; }
    }
}
