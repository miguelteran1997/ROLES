﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sweets.practice.Data;

namespace Sweets.practice.Pages.Can
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
            return Page();
        }

        [BindProperty]
        public Candy Candy { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candy.Add(Candy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}