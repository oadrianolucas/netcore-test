#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Einstein.Data;
using Einstein.Models;
using Einstein.Interfaces;

namespace Einstein.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private string msgNotFoundPatient = "Error na ação: Infelizmente não localizamos o paciente selecionado.";
        private string msgPatientNotAppointment = "O paciente selecionado não tem consultas agendadas.";

        private EinsteinContext _context;
        private IPatientsServices _iapatients;

        public PatientsController(EinsteinContext context)
        {
            _context = context;
        }

        // GET: api/Patients/appointments/list/2
        [HttpGet("appointments/list/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsPatient(int id)
        {
            var appointment = await _context.Appointments.Where(x => x.IdPatient == id).ToListAsync();
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return Ok(msgNotFoundPatient);
            }
            else
            {
                if (appointment.Count == 0)
                {
                    return Ok(msgPatientNotAppointment);
                }
                return appointment;
            }
        }

        private bool PatientExists(int id)
        {
            return _iapatients.PatientExists(id);
        }
    }
}
