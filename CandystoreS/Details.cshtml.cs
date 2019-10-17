using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.CandystoreS
{
    public class DetailsModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public DetailsModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Candystore Candystore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candystore = await _context.Candystore.FirstOrDefaultAsync(m => m.CSID == id);

            if (Candystore == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
