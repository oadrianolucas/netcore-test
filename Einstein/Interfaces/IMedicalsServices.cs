using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Einstein.Services;

namespace Einstein.Interfaces
{
    public interface IMedicalsServices
    {
        public Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsPatient(int id);
        public bool MedicalExists(int id);
    }
}
