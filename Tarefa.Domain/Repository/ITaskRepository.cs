using Tarefa.Domain.Model.Aggregates.Tasks.Entities;

namespace Tarefa.Domain.Repository
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAsync();

        Task<Tasks> GetAsync(string id);

        Task CreateAsync(Tasks tasks);

        Task UpdateAsync(string id, Tasks tasks);

        Task RemoveAsync(string id);
    }
}
