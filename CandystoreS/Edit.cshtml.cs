using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.CandystoreS
{
    public class EditModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public EditModel(Sweets.practice.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candystore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandystoreExists(Candystore.CSID))
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

        private bool CandystoreExists(int id)
        {
            return _context.Candystore.Any(e => e.CSID == id);
        }
    }
}
