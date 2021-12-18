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
    public class IndexModel : PageModel
    {
        private readonly ReviewlyApp.Data.Context.ReviewlyContext _context;

        public IndexModel(ReviewlyApp.Data.Context.ReviewlyContext context)
        {
            _context = context;
        }

        public IList<Reviews> Reviews { get;set; }

        public async Task OnGetAsync()
        {
            Reviews = await _context.Reviews.ToListAsync();
        }
    }
}
