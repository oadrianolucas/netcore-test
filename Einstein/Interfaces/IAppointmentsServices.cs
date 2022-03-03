using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Einstein.Services;

namespace Einstein.Interfaces
{
    public interface IAppointmentsServices
    {
        public Task<ActionResult<Appointment>> PostAppointment(Appointment appointment);
        public bool AppointmentExists(int id);
        public bool ValidateMedical(int Id);
        public bool ValidatePatient(int Id);
        public bool ValidateMedicalAppointments(int Id, DateTime Schedule);
        public bool ValidatePatientsAppointments(int Id, DateTime Schedule);
        public List<Appointment> GetAppointmentsMedical(int id);
        public List<Appointment> GetAppointmentsPatient(int id);

    }
}
