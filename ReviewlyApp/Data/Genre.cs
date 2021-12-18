using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewlyApp.Data
{
    public class Genre
    {
        
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public ICollection<Films> Films  { get; set; }

    }
}
