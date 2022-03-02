#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Einstein.Data;
using Einstein.Models;

namespace Einstein.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalsController : ControllerBase
    {
        private readonly EinsteinContext _context;

        private string msgNotFoundMedical = "Error na ação: Infelizmente não localizamos o médico selecionado.";
        private string msgMedicalNotAppointment = "O médico selecionado não tem consultas agendadas.";

        public MedicalsController(EinsteinContext context)
        {
            _context = context;
        }
        // GET: api/Medicals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medical>>> GetMedicals()
        {
            return await _context.Medicals.ToListAsync();
        }
        // GET: api/Medicals/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Medical>> GetMedical(int id)
        {
            var medical = await _context.Medicals.FindAsync(id);

            if (medical == null)
            {
                return NotFound();
            }

            return medical;
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
        // PUT: api/Medicals/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedical(int id, Medical medical)
        {
            if (id != medical.Id)
            {
                return BadRequest();
            }

            _context.Entry(medical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalExists(id))
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
        // POST: api/Medicals
        [HttpPost]
        public async Task<ActionResult<Medical>> PostMedical(Medical medical)
        {
            _context.Medicals.Add(medical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedical", new { id = medical.Id }, medical);
        }
        // DELETE: api/Medicals/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedical(int id)
        {
            var medical = await _context.Medicals.FindAsync(id);
            if (medical == null)
            {
                return NotFound();
            }

            _context.Medicals.Remove(medical);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalExists(int id)
        {
            return _context.Medicals.Any(e => e.Id == id);
        }
    }
}