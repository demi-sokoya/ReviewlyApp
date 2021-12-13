using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReviewlyApp.Data;
using ReviewlyApp.Data.Context;

namespace ReviewlyApp.Pages.ReviwlyPages
{
    public class CreateModel : PageModel
    {
        private readonly ReviewlyApp.Data.Context.ReviewlyContext _context;

        public List<Genre> Genres { get; } = new List<Genre>
        {
            new Genre()
            {
                GenreId = 1,
                GenreName = "Action"
            },

            new Genre()
            {
                GenreId = 2,
                GenreName = "Comedy"
            }
        };

        public List<SelectListItem> Genre { get; set; }  

        public CreateModel(ReviewlyApp.Data.Context.ReviewlyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Genre = Genres.Select(n =>
            new SelectListItem
            {
                Value = n.GenreId.ToString(),
                Text = n.GenreName
            }).ToList();
            return Page();
        }

        [BindProperty]
        public Films Films { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Films.Add(Films);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
