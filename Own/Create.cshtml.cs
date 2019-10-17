using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.Own
{
    public class CreateModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public CreateModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CID"] = new SelectList(_context.Candy, "CID", "CID");
        ViewData["CSID"] = new SelectList(_context.Candystore, "CSID", "CSID");
            return Page();
        }

        [BindProperty]
        public Owners Owners { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Owners.Add(Owners);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}