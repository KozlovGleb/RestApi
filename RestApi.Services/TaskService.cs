using RestApi.DataAccess;
using RestApi.DataAccess.Entities;
using RestApi.Service.Interfaces;
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
            return await FindTaskById(TaskId);
        }
        public async Task<Entity> UpdateTaskAsync(int id, Entity Task)
        {
            var task = await FindTaskById(id);
            _dataContext.Entry(task).CurrentValues.SetValues(Task);
            await _dataContext.SaveChangesAsync();
            return await FindTaskById(id);//вот тут наверное можно покрасивше
        }
        public async Task<Entity> PostTaskAsync(Entity Task)
        {
            await _dataContext.Entities.AddAsync(Task);
            await _dataContext.SaveChangesAsync();
            return await FindTaskById(Task.Id);
        }
        public async Task DeleteTaskAsync(int id)
        {
            var task = await FindTaskById(id);
            _dataContext.Entities.Remove(task);
            await _dataContext.SaveChangesAsync();
        }

        #endregion
        #region private CRUD
        private async Task<Entity> FindTaskById(int Id)
        {
            return await _dataContext.Entities.FindAsync(Id);
        }


        #endregion
    }
}
