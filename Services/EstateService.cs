using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data;
using RealEstateApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateApp.Services
{
    public class EstateService
    {
        private readonly ApplicationDbContext _context;

        public EstateService(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE
        public void Create(Estate estate)
        {
            _context.Estate.Add(estate);
            _context.SaveChanges();
        }

        // READ
        public IEnumerable<Estate> GetAll()
        {
            return _context.Estate.Include(e => e.EstateType).Include(i => i.Images).ToList();
        }

        public Estate GetById(int id)
        {
            return _context.Estate
                          .Include(e => e.EstateType)
                          .Include(i => i.Images)
                          .FirstOrDefault(e => e.EstateId == id);
        }

        // UPDATE
        public void Update(Estate estate)
        {
            _context.Entry(estate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE
        public void Delete(int id)
        {
            var estate = _context.Estate.Find(id);
            if (estate != null)
            {
                _context.Estate.Remove(estate);
                _context.SaveChanges();
            }
        }
    }
}
