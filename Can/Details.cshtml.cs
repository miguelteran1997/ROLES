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
    public class DetailsModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public DetailsModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
