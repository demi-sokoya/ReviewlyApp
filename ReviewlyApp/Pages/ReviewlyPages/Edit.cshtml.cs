using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReviewlyApp.Data;
using ReviewlyApp.Data.Context;

namespace ReviewlyApp.Pages.ReviwlyPages
{
    public class EditModel : PageModel
    {
        private readonly ReviewlyApp.Data.Context.ReviewlyContext _context;

        public EditModel(ReviewlyApp.Data.Context.ReviewlyContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Films).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsExists(Films.FilmId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FilmsExists(int id)
        {
            return _context.Films.Any(e => e.FilmId == id);
        }
    }
}
