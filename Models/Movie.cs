using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicScaffold.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stocks")]
        [Range(1, 50)]
        public int NumberInStocks { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [NotMapped]
        [Display(Name = "Movie Certificate")]
        [Required]
        public HttpPostedFileBase File { get; set; }

        public byte[] byteFile { get; set; }

        public string FileExtension { get; set; }

        ////public Movie()
        ////{
        ////    Files = new List<HttpPostedFileBase>();
        ////}

        ////[NotMapped]
        ////[Display(Name = "Choose File(s)")]
        ////public List<HttpPostedFileBase> Files { get; set; }
    }
}