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
    public class DeleteModel : PageModel
    {
        private readonly ReviewlyApp.Data.Context.ReviewlyContext _context;

        public DeleteModel(ReviewlyApp.Data.Context.ReviewlyContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Films = await _context.Films.FindAsync(id);

            if (Films != null)
            {
                _context.Films.Remove(Films);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
