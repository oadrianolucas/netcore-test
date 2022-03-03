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
    public class MedicalsController : ControllerBase
    {
        private string msgNotFoundMedical = "Error na ação: Infelizmente não localizamos o médico selecionado.";
        private string msgMedicalNotAppointment = "O médico selecionado não tem consultas agendadas.";

        private IMedicalsServices _imedicals;
        private EinsteinContext _context;
        
        public MedicalsController(EinsteinContext context)
        {
            _context = context;
        }

        // GET: api/Medicals/appointments/list/2
        [HttpGet("appointments/list/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsPatient(int id)
        {
            var appointment = await _context.Appointments.Where(x => x.IdMedical == id).ToListAsync();
            var medical = await _context.Medicals.FindAsync(id);
            if (medical == null)
            {
               return Ok(msgNotFoundMedical);
            }
            else
            {
                if (appointment.Count == 0)
                {                   
                    return Ok(msgMedicalNotAppointment);
                }
                return appointment;
            }
        }
   
        private bool MedicalExists(int id)
        {
            return _imedicals.MedicalExists(id);
        }
    }
}