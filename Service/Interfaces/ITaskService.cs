using RestApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Service.Interfaces
{
    interface ITaskService
    {
        Task<Entity> GetTaskAsync(int TaskId);
        Task<Entity> UpdateTaskAsync(int id, Entity Task);
        Task<Entity> PostTaskAsync(Entity Task);
        Task DeleteTaskAsync(int id);

    }
}
