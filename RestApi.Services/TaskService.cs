using Microsoft.EntityFrameworkCore;
using RestApi.DataAccess;
using RestApi.DataAccess.Entities;
using RestApi.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Service
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _dataContext;
        public TaskService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #region public CRUD
        public async Task<Entity> GetTaskAsync(int TaskId)
        {
            return await _dataContext.Entities.FindAsync(TaskId);
        }
        public async Task<IEnumerable<Entity>> GetAllTasksByUser(int id)
        {
            return await FindTasksById(id);
        }
        public async Task<Entity> UpdateTaskAsync(int id, Entity Task)
        {
            var task = await _dataContext.Entities.FindAsync(id);

            _dataContext.Entry(task).CurrentValues.SetValues(Task);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Entities.FindAsync(id);//вот тут наверное можно покрасивше
        }
        public async Task<Entity> PostTaskAsync(Entity Task, int userId)
        {
            Task.UserId = userId;
            await _dataContext.Entities.AddAsync(Task);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Entities.FindAsync(Task.Id);
        }
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _dataContext.Entities.FindAsync(id);
            _dataContext.Entities.Remove(task);
            await _dataContext.SaveChangesAsync();
        }

        #endregion
        #region private CRUD
        private async Task<IEnumerable<Entity>> FindTasksById(int Id)
        {
            return await _dataContext.Entities.Where(b => b.UserId == Id).ToListAsync();
        }


        #endregion
    }
}
