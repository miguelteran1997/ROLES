using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.Can
{
    public class DeleteModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public DeleteModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candy Candy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candy = await _context.Candy.FirstOrDefaultAsync(m => m.CID == id);

            if (Candy == null)
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

            Candy = await _context.Candy.FindAsync(id);

            if (Candy != null)
            {
                _context.Candy.Remove(Candy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
