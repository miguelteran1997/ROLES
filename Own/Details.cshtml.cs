using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.Own
{
    public class DetailsModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public DetailsModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
