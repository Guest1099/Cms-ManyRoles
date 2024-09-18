using Data.Repos.Abs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class RejestratorLogowaniaController : ControllerBase
    {
        private readonly IModelRepository <RejestratorLogowania> _rejestratorLogowaniaRepository;

        public RejestratorLogowaniaController(IModelRepository<RejestratorLogowania> rejestratorLogowaniaRepository)
        {
            _rejestratorLogowaniaRepository = rejestratorLogowaniaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<TaskResult<List<RejestratorLogowania>>>> GetRejestratorLogowanias()
        {
            try
            {
                var taskResult = await _rejestratorLogowaniaRepository.GetAll();
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResult<RejestratorLogowania>>> GetRejestratorLogowania(string id)
        {
            try
            {
                var taskResult = await _rejestratorLogowaniaRepository.Get(id);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPost]
        public async Task<ActionResult<TaskResult<RejestratorLogowania>>> PostRejestratorLogowania(RejestratorLogowania model)
        {
            try
            {
                var taskResult = await _rejestratorLogowaniaRepository.Create(model);
                return CreatedAtAction(nameof(GetRejestratorLogowania), new { id = model.RejestratorLogowaniaId }, taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<TaskResult<RejestratorLogowania>>> PutRejestratorLogowania(string id, RejestratorLogowania model)
        {
            try
            {
                if (id != model.RejestratorLogowaniaId)
                    return BadRequest("RejestratorLogowaniaId mismatch");

                var taskResult = await _rejestratorLogowaniaRepository.Update(model);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }





        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskResult<RejestratorLogowania>>> DeleteMovie(string id)
        {
            try
            {
                var taskResult = await _rejestratorLogowaniaRepository.Delete(id);
                return Ok(taskResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
