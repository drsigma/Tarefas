using Microsoft.AspNetCore.Mvc;
using Moq;
using Tarefa.Domain.Model.Aggregates.Tasks.Entities;
using Tarefa.Domain.Repository;
using Tarefas.Api.Controllers.V1;
using Xunit;

public class TasksControllerTests
{
    [Fact]
    public async Task GetTasks_ReturnsListOfTasks()
    {
        var fakeTasksList = new List<Tasks>
        {
            new Tasks
            {
                TaskId = "1",
                User = new User { UserId = "user1", Name = "John Doe" },
                Title = "Task 1",
                Description = "Description 1",
                ExpiresAt = DateTime.Now.AddDays(7),
                CreatedAt = DateTime.Now.AddHours(-2)
            },
            new Tasks
            {
                TaskId = "2",
                User = new User { UserId = "user2", Name = "Jane Doe" },
                Title = "Task 2",
                Description = "Description 2",
                ExpiresAt = DateTime.Now.AddDays(14),
                CreatedAt = DateTime.Now.AddHours(-5)
            },
            new Tasks
            {
                TaskId = "3",
                User = new User { UserId = "user3", Name = "Bob Smith" },
                Title = "Task 3",
                Description = "Description 3",
                ExpiresAt = DateTime.Now.AddDays(30),
                CreatedAt = DateTime.Now.AddHours(-10)
            }
        };

        var tasksRepositoryMock = new Mock<ITaskRepository>();
        tasksRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(fakeTasksList) ; 

        var controller = new TasksController(tasksRepositoryMock.Object);

        var result = await controller.GetTasks();

        Assert.NotNull(result);
        Assert.IsType<List<Tasks>>(result); 
    }

    [Fact]
    public async Task GetTaskById_ReturnsTask()
    {
        var taskId = "taskId";
        var tasksRepositoryMock = new Mock<ITaskRepository>();
        tasksRepositoryMock.Setup(repo => repo.GetAsync(taskId)).ReturnsAsync(new Tasks());

        var controller = new TasksController(tasksRepositoryMock.Object);

        var result = await controller.GetTaskById(taskId);

        Assert.IsType<Tasks>(result);
    }

    [Fact]
    public async Task PostTask_ReturnsTask()
    {
        var tasksRepositoryMock = new Mock<ITaskRepository>();
        var controller = new TasksController(tasksRepositoryMock.Object);
        var newTask = new Tasks();

        var result = await controller.PostTask(newTask);

        Assert.IsType<Tasks>(result);
    }

    [Fact]
    public async Task PutTask_ReturnsTask()
    {
        var taskId = "taskId";
        var tasksRepositoryMock = new Mock<ITaskRepository>();
        tasksRepositoryMock.Setup(repo => repo.UpdateAsync(taskId, It.IsAny<Tasks>()))
            .Returns(Task.CompletedTask);

        var controller = new TasksController(tasksRepositoryMock.Object);
        var updatedTask = new Tasks();

        var result = await controller.PutTask(updatedTask, taskId);

        Assert.IsType<Tasks>(result);
    }

    [Fact]
    public async Task RemoveTask_ReturnsOkResult()
    {
        var taskId = "taskId";
        var tasksRepositoryMock = new Mock<ITaskRepository>();
        tasksRepositoryMock.Setup(repo => repo.RemoveAsync(taskId))
            .Returns(Task.CompletedTask);

        var controller = new TasksController(tasksRepositoryMock.Object);

        var result = await controller.RemoveTask(taskId);

        Assert.IsType<OkResult>(result);
    }
}
