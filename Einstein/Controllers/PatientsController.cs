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

        private IPatientsServices _iapatients;
        private IAppointmentsServices _iappointments;
        public PatientsController(IAppointmentsServices iappointments, IPatientsServices iapatients)
        {
            _iapatients = iapatients;
            _iappointments = iappointments;
        }

        // GET: api/Patients/appointments/list/2
        [HttpGet("appointments/list/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsPatient(int id)
        {
            var patient = _iappointments.GetAppointmentsPatient(id);
            if (patient.Count > 0)
            {
                return patient;
            }
            else
            {
                if (!_iapatients.PatientExists(id))
                    return Ok(msgNotFoundPatient);
                return Ok(msgPatientNotAppointment);
            }
        }
    }
}
