using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.Own
{
    public class EditModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public EditModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owners Owners { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owners = await _context.Owners
                .Include(o => o.Can)
                .Include(o => o.candystoreS).FirstOrDefaultAsync(m => m.OID == id);

            if (Owners == null)
            {
                return NotFound();
            }
           ViewData["CID"] = new SelectList(_context.Candy, "CID", "CID");
           ViewData["CSID"] = new SelectList(_context.Candystore, "CSID", "CSID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Owners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnersExists(Owners.OID))
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

        private bool OwnersExists(int id)
        {
            return _context.Owners.Any(e => e.OID == id);
        }
    }
}
