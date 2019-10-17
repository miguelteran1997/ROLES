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
    public class IndexModel : PageModel
    {
        private readonly Sweets.practice.Data.ApplicationDbContext _context;

        public IndexModel(Sweets.practice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Candystore> Candystore { get;set; }

        public async Task OnGetAsync()
        {
            Candystore = await _context.Candystore.ToListAsync();
        }
    }
}
