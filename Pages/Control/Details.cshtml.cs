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
    public class DetailsModel : PageModel
    {
        private readonly RealEstateApp.Data.ApplicationDbContext _context;

        public DetailsModel(RealEstateApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Estate Estate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estate == null)
            {
                return NotFound();
            }

            var estate = await _context.Estate.FirstOrDefaultAsync(m => m.EstateId == id);
            if (estate == null)
            {
                return NotFound();
            }
            else 
            {
                Estate = estate;
            }
            return Page();
        }
    }
}
