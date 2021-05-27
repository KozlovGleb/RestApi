using RestApi.DataAccess.Entities;
using System.Threading.Tasks;

namespace RestApi.Service.Interfaces
{
    public interface ITaskService
    {
        Task<Entity> GetTaskAsync(int TaskId);
        Task<Entity> UpdateTaskAsync(int id, Entity Task);
        Task<Entity> PostTaskAsync(Entity Task);
        Task DeleteTaskAsync(int id);
    }
}
