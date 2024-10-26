using RehabBackend.Core.Entities;
using RehabBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RehabBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientsController(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        private Patient MapDto(PatientCreateDto patientCreateDto)
        {
            return new Patient
            {
                Name = patientCreateDto.Name,
                Plans = patientCreateDto.Plans,
                ClientId = patientCreateDto.ClientId
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return Ok(await _patientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var Patient = await _patientRepository.GetById(id);
            if (Patient == null) return NotFound();
            return Ok(Patient);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(PatientCreateDto patientCreateDto)
        {
            var patient = MapDto(patientCreateDto);

            await _patientRepository.Add(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(PatientCreateDto patientCreateDto)
        {
            var patient = MapDto(patientCreateDto);
            await _patientRepository.Update(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var success = await _patientRepository.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

// Similarly, create controllers for Patient, Plan, and Patient
