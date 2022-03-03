using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Einstein.Services;

namespace Einstein.Interfaces
{
    public interface IMedicalsServices
    {
        public bool MedicalExists(int id);
    }
}
