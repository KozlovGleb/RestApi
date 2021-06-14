using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess;
using RestApi.DataAccess.Entities;
using RestApi.Service.Interfaces;
//using RestApi.Services.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [HttpGet]
        public async Task<IEnumerable<Entity>> GetEntity()
        {

            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var entity = await _taskService.GetAllTasksByUser(userId);

            if (entity == null)
            {
                return null;
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
        public async Task<ActionResult> PostEntity(Entity entity)
        {
            var userId = GetUserId(); //не знаю насколько это хорошая практика
            await _taskService.PostTaskAsync(entity, userId);
            return Ok();
        }

        // DELETE: api/Entities/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return NoContent();
        }
        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.First().Value);
        }

    }
}
