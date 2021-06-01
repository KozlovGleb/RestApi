using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess;
using RestApi.DataAccess.Entities;
using RestApi.Service.Interfaces;
using RestApi.Services.Helpers;
using System;
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
        [HttpGet("{id}")]
        public async Task<IEnumerable<Entity>> GetEntity()
        {
            //var ii = ClaimTypes.NameIdentifier;
            var user = (User)HttpContext.Items["User"];
            //var user1 = HttpContext.User.FindFirst("id")?.Value;
            //var userClaims = HttpContext.User;
            //var id = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entity = await _taskService.GetAllTasksByUser(user.Id);

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
