using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReviewlyApp.Data
{
    public class Films
    {
        [Key]
        [Required]
        public int FilmId { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Not a valid title.")]
        public string FilmTitle { get; set; }
      
        public ICollection<Genre> Genres { get; set; }

        [RegularExpression("[0-9]*", ErrorMessage ="Enter a valid year")]
        public int Year { get; set; }
        public string Summary { get; set; }
        public float Rating { get; set; }
        
        public List<Reviews> Reviews { get; set; }

    }
}
