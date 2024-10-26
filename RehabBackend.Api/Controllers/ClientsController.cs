using RehabBackend.Core.Entities;
using RehabBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RehabBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Patient> _patientRepository;

        public ClientsController(IRepository<Client> clientRepository, IRepository<Patient> patientRepository)
        {
            _clientRepository = clientRepository;
            _patientRepository = patientRepository;
        }

        private Client MapDto(ClientCreateDto clientCreateDto)
        {
            return new Client
            {
                Name = clientCreateDto.Name,
                Phone = clientCreateDto.Phone,
                Email = clientCreateDto.Email,
                Patients = clientCreateDto.Patients
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return Ok(await _clientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientRepository.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpGet("clientsWithPatientNames")]
        public async Task<ActionResult<IEnumerable<ClientWithPatientNamesDto>>> GetAllClientsWithPatientNames()
        {
            var clients = await _clientRepository.GetAll();
            var clientDtos = new List<ClientWithPatientNamesDto>();

            foreach (var client in clients)
            {
                var patientIds = client.Patients;

                var patients = await _patientRepository.GetAllByIds(patientIds);

                var patientNames = patients.Select(p => p.Name).ToList();

                clientDtos.Add(new ClientWithPatientNamesDto
                {
                    ClientId = client.ClientId,
                    Name = client.Name,
                    PatientNames = patientNames
                });
            }

            return Ok(clientDtos);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientCreateDto clientCreateDto)
        {

            var client = MapDto(clientCreateDto);

            await _clientRepository.Add(client);

            return CreatedAtAction(nameof(GetClient), new { id = client.ClientId }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientCreateDto clientCreateDto)
        {
            var client = MapDto(clientCreateDto);

            await _clientRepository.Update(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var success = await _clientRepository.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

// Similarly, create controllers for Patient, Plan, and Exercise
