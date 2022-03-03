using Einstein.Data;
using Einstein.Interfaces;
using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Services
{
    public class MedicalsServices : IMedicalsServices
    {
        private readonly EinsteinContext _context;
        public MedicalsServices(EinsteinContext context)
        {
            _context = context;
        }
        public bool MedicalExists(int id)
        {
            return _context.Medicals.Any(e => e.Id == id);
        }
    }
}
