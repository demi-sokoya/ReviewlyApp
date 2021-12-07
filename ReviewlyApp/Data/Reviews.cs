using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewlyApp.Data
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public ICollection<Films> FilmId { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }
        public float Rating { get; set; }
    }
}
