#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Einstein.Data;
using Einstein.Models;

namespace Einstein.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly EinsteinContext _context;

        private string msgNotFoundMedical = "Error na ação: Infelizmente não localizamos o médico selecionado.";
        private string msgNotFoundPatient = "Error na ação: Infelizmente não localizamos o paciente selecionado.";
        private string msgMedicalHaveAnAppointment = "Que pena, o médico selecionado já tem consulta neste horário.";
        private string msgPatientHaveAnAppointment = "O paciente selecionado já tem uma consulta neste horário.";

        public AppointmentsController(EinsteinContext context)
        {
            _context = context;
        }
        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }
        // GET: api/Appointments/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }
        // PUT: api/Appointments/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            var validade = await _context.Appointments.Where(x => x.Schedule <= appointment.Schedule &&
            x.Schedule.AddHours(1) > appointment.Schedule &&
            (x.IdMedical == appointment.IdMedical || x.IdPatient == appointment.IdPatient)).FirstOrDefaultAsync();

            var medical = await _context.Medicals.FindAsync(appointment.IdMedical);
            var patient = await _context.Patients.FindAsync(appointment.IdPatient);

            if (medical == null || patient == null)
            {
                var msg = medical == null ? msgNotFoundMedical : 
                    patient == null ? msgNotFoundPatient : null;
                return Ok(msg);
            } 
            else
            {
                if (validade != null)
                {
                    var msg = appointment.IdMedical == validade.IdMedical ? msgMedicalHaveAnAppointment :
                        appointment.IdPatient == validade.IdPatient ? msgPatientHaveAnAppointment : null;
                    return Ok(msg);
                }
                else
                {
                    _context.Appointments.Add(appointment);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
                }
            }       
        }
        // DELETE: api/Appointments/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}