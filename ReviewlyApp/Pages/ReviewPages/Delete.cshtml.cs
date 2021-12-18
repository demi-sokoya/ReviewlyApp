using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReviewlyApp.Data;
using ReviewlyApp.Data.Context;

namespace ReviewlyApp.Pages.ReviewPages
{
    public class DeleteModel : PageModel
    {
        private readonly ReviewlyApp.Data.Context.ReviewlyContext _context;

        public DeleteModel(ReviewlyApp.Data.Context.ReviewlyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reviews Reviews { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reviews = await _context.Reviews.FirstOrDefaultAsync(m => m.ReviewId == id);

            if (Reviews == null)
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

            Reviews = await _context.Reviews.FindAsync(id);

            if (Reviews != null)
            {
                _context.Reviews.Remove(Reviews);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
