using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data;
using RealEstateApp.Models;
using System.Text.Json;

namespace RealEstateApp.Services
{
    public class EstateService
    {
        private readonly ApplicationDbContext _context;

        //DI
        public EstateService( ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all estates.
        public IEnumerable<Estate> GetAll() { return _context.Estate.ToList(); }
    }
}
