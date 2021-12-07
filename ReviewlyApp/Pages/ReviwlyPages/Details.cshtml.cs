using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReviewlyApp.Data;
using ReviewlyApp.Data.Context;

namespace ReviewlyApp.Pages.ReviwlyPages
{
    public class DetailsModel : PageModel
    {
        private readonly ReviewlyApp.Data.Context.ReviewlyContext _context;

        public DetailsModel(ReviewlyApp.Data.Context.ReviewlyContext context)
        {
            _context = context;
        }

        public Films Films { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Films = await _context.Films.FirstOrDefaultAsync(m => m.FilmId == id);

            if (Films == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
