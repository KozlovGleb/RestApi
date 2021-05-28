using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess;
using RestApi.DataAccess.Entities;
using RestApi.Service.Interfaces;
using RestApi.Services.Helpers;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITaskService _taskService;

        public EntitiesController(DataContext context, ITaskService taskService)
        {
            _context = context;
            _taskService = taskService;
        }


        // GET: api/Entities/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(int id)
        {
            var entity = await _taskService.GetTaskAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(int id, Entity entity)
        {
            var task = await _taskService.UpdateTaskAsync(id, entity);
            return Ok(task);
        }

        // POST: api/Entities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity entity)
        {
            return await _taskService.PostTaskAsync(entity);
        }

        // DELETE: api/Entities/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return NoContent();
        }

    }
}
