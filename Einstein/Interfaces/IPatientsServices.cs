using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Einstein.Services;

namespace Einstein.Interfaces
{
    public interface IPatientsServices
    {
        public Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsPatient(int id);
        public bool PatientExists(int id);
    }
}
