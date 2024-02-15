using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
using Tarefa.Domain.Model.Aggregates.Tasks.Entities;
using Tarefa.Domain.Repository;
using Tarefa.Infrastructure.Configuration;

namespace Tarefa.Infrastructure.Repository
{
    [ExcludeFromCodeCoverage]
    public class TasksRepository : ITaskRepository

    {
        private readonly IMongoCollection<Tasks> _tasksCollection;

        public TasksRepository(IOptions<TasksConfig> tasksRepository)
        {
            var mongoClient = new MongoClient(tasksRepository.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(tasksRepository.Value.DatabaseName);

            _tasksCollection = mongoDatabase.GetCollection<Tasks>(tasksRepository.Value.BankAccountCollectionName);

        }

        public async Task<List<Tasks>> GetAsync() =>
            await _tasksCollection.Find(x => true).ToListAsync();

        public async Task<Tasks> GetAsync(string id) =>
            await _tasksCollection.Find(x => x.TaskId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Tasks tasks) =>
            await _tasksCollection.InsertOneAsync(tasks);

        public async Task UpdateAsync(string id, Tasks tasks) =>
            await _tasksCollection.ReplaceOneAsync(x => x.TaskId == id, tasks);

        public async Task RemoveAsync(string id) =>
            await _tasksCollection.DeleteOneAsync(x => x.TaskId == id);
    }
}

