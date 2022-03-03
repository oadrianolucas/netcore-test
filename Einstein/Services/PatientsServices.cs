using Einstein.Data;
using Einstein.Interfaces;
using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Services
{
    public class PatientsServices : IPatientsServices
    {
        private readonly EinsteinContext _context;
        public PatientsServices(EinsteinContext context)
        {
            _context = context;
        }
        public bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
