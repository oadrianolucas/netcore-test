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
        string msgNotFoundMedical = "Error na ação: Infelizmente não localizamos o médico selecionado.";
        string msgMedicalNotAppointment = "O médico selecionado não tem consultas agendadas.";

        private IMedicalsServices _imedicals;
        private IAppointmentsServices _iappointments;
        
        public MedicalsController(IAppointmentsServices iappointments, IMedicalsServices imedicals)
        {
            _imedicals = imedicals;
            _iappointments = iappointments;
        }

        // GET: api/Medicals/appointments/list/2
        [HttpGet("appointments/list/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsMedical(int id)
        {
            var medical = _iappointments.GetAppointmentsMedical(id);
            if (medical.Count > 0)
            {                   
                return medical;
            } else
            {
                if (!_imedicals.MedicalExists(id))
                    return Ok(msgNotFoundMedical);
                return Ok(msgMedicalNotAppointment);
            }            
        }
    }
}