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
        public string FilmTitle { get; set; }
      
        public ICollection<Genre> Genres { get; set; }
        public int Year { get; set; }
        public string Summary { get; set; }
        public float Rating { get; set; }
        
        public List<Reviews> Reviews { get; set; }

    }
}
