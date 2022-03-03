using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Einstein.Services;

namespace Einstein.Interfaces
{
    public interface IPatientsServices
    {
        public bool PatientExists(int id);
    }
}
