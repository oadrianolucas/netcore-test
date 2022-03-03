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
    public class AppointmentsController : ControllerBase

    {
        string msgNotFoundMedical = "Error na ação: Infelizmente não localizamos o médico selecionado.";
        string msgNotFoundPatient = "Error na ação: Infelizmente não localizamos o paciente selecionado.";
        string msgMedicalHaveAnAppointment = "Que pena, o médico selecionado já tem consulta neste horário.";
        string msgPatientHaveAnAppointment = "O paciente selecionado já tem uma consulta neste horário.";
        string msgSuccess = "Consulta salva com sucesso.";

        private IAppointmentsServices _iappointments;

        public AppointmentsController(IAppointmentsServices iappointments)
        {
            _iappointments = iappointments;
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            var validateNotFound = _iappointments.ValidateMedical(appointment.IdMedical) == false ? msgNotFoundMedical :
                  _iappointments.ValidatePatient(appointment.IdPatient) == false ? msgNotFoundPatient : null;

            var validadeSchedule = _iappointments.ValidateMedicalAppointments(appointment.IdMedical, appointment.Schedule)
                == false ? msgMedicalHaveAnAppointment : _iappointments.ValidatePatientsAppointments(appointment.IdPatient, appointment.Schedule) 
                == false ? msgPatientHaveAnAppointment : null;

            if (validateNotFound != null)
            {
                return Ok(validateNotFound);

            }
            else if (validadeSchedule != null)
            {
                return Ok(validadeSchedule);
            } 
            await _iappointments.PostAppointment(appointment);
            return Ok(msgSuccess);
        }
    }
}