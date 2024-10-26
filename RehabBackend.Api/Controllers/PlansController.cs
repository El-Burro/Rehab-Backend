using RehabBackend.Core.Entities;
using RehabBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RehabBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IRepository<Plan> _planRepository;

        public PlansController(IRepository<Plan> planRepository)
        {
            _planRepository = planRepository;
        }

        private Plan MapDto(PlanCreateDto planCreateDto)
        {
            return new Plan
            {
                Name = planCreateDto.Name,
                Description = planCreateDto.Description,
                Patients = planCreateDto.Patients,
                Exercises = planCreateDto.Exercises
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        {
            return Ok(await _planRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var Plan = await _planRepository.GetById(id);
            if (Plan == null) return NotFound();
            return Ok(Plan);
        }

        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(PlanCreateDto planCreateDto)
        {
            var plan = MapDto(planCreateDto);

            await _planRepository.Add(plan);

            return CreatedAtAction(nameof(GetPlan), new { id = plan.PlanId }, plan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(PlanCreateDto planCreateDto)
        {
            var plan = MapDto(planCreateDto);

            await _planRepository.Update(plan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var success = await _planRepository.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

// Similarly, create controllers for Patient, Plan, and Plan
