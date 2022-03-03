using Einstein.Data;
using Einstein.Interfaces;
using Einstein.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Services
{
    public class AppointmentsServices : IAppointmentsServices
    {
        private readonly EinsteinContext _context;
        public AppointmentsServices(EinsteinContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
        public bool ValidateMedical(int Id)
        {
            Medical medical = _context.Medicals.Where(e => e.Id == Id).FirstOrDefault(); 
            return medical == null ? false : true;
        }
        public bool ValidatePatient(int Id)
        {
            Patient patient = _context.Patients.Where(e => e.Id == Id).FirstOrDefault();
            return patient == null ? false : true;
        }
        public bool ValidateMedicalAppointments(int Id, DateTime Schedule)
        {
            var IdMedical = _context.Appointments.Where(e => e.Schedule <= Schedule &&
            e.Schedule.AddHours(1) > Schedule &&
            e.IdMedical == Id).FirstOrDefault();
            return IdMedical == null ? true : false;
        }
        public bool ValidatePatientsAppointments(int Id, DateTime Schedule)
        {
            var IdPatient = _context.Appointments.Where(e => e.Schedule <= Schedule &&
            e.Schedule.AddHours(1) > Schedule &&
            e.IdPatient == Id).FirstOrDefault();
            return IdPatient == null ? true : false;
        }
        public List<Appointment> GetAppointmentsMedical(int id)
        {
            return _context.Appointments.Where(x => x.IdMedical == id).ToList();
        }
        public List<Appointment> GetAppointmentsPatients(int id)
        {
            return _context.Appointments.Where(x => x.IdPatient == id).ToList();
        }
    }
}
