using Microsoft.AspNetCore.Mvc;
using Tarefa.Domain.Model.Aggregates.Tasks.Entities;
using Tarefa.Domain.Repository;

namespace Tarefas.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _tasksRepository;

        public TasksController(ITaskRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        [HttpGet]
        public async Task<List<Tasks>> GetTasks() =>
            await _tasksRepository.GetAsync();

        [HttpGet]
        [Route("/{id}")]
        public async Task<Tasks> GetTaskById([FromRoute] string id) =>
            await _tasksRepository.GetAsync(id);

        [HttpPost]
        public async Task<Tasks> PostTask(Tasks tasks)
        {
            Console.WriteLine("teste");

            await _tasksRepository.CreateAsync(tasks);

            return tasks;
        }

        [HttpPut]
        [Route("/{id}")]
        public async Task<Tasks> PutTask(Tasks tasks, [FromRoute]string id)
        {
            await _tasksRepository.UpdateAsync(id, tasks);

            return tasks;
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<IActionResult> RemoveTask([FromRoute]string id)
        {
            await _tasksRepository.RemoveAsync(id);

            return Ok();
        }
    }
}
