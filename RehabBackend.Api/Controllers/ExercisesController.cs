using RehabBackend.Core.Entities;
using RehabBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RehabBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IRepository<Exercise> _exerciseRepository;

        public ExercisesController(IRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        private Exercise MapDto(ExerciseCreateDto exerciseCreateDto)
        {
            return new Exercise
            {
                Name = exerciseCreateDto.Name,
                Plans = exerciseCreateDto.Plans
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            return Ok(await _exerciseRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var Exercise = await _exerciseRepository.GetById(id);
            if (Exercise == null) return NotFound();
            return Ok(Exercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(ExerciseCreateDto exerciseCreateDto)
        {
            var exercise = MapDto(exerciseCreateDto);

            await _exerciseRepository.Add(exercise);

            return CreatedAtAction(nameof(GetExercise), new { id = exercise.ExerciseId }, exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(ExerciseCreateDto exerciseCreateDto)
        {
            var exercise = MapDto(exerciseCreateDto);
            await _exerciseRepository.Update(exercise);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var success = await _exerciseRepository.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

// Similarly, create controllers for Patient, Plan, and Exercise
