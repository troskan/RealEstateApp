using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data;
using RealEstateApp.Models;

namespace RealEstateApp.Pages.Control_Panel
{
    public class IndexModel : PageModel
    {
        private readonly RealEstateApp.Data.ApplicationDbContext _context;

        public IndexModel(RealEstateApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Estate> Estate { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Estate != null)
            {
                Estate = await _context.Estate
                .Include(e => e.EstateType).Include(r => r.Images).ToListAsync();
            }
        }
    }
}
