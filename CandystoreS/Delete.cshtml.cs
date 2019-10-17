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
    public class DeleteModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public DeleteModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candystore = await _context.Candystore.FindAsync(id);

            if (Candystore != null)
            {
                _context.Candystore.Remove(Candystore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
