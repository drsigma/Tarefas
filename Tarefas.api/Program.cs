using System.Diagnostics.CodeAnalysis;
using Tarefa.Domain.Repository;
using Tarefa.Infrastructure.Configuration;
using Tarefa.Infrastructure.Repository;

namespace Tarefas.api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ITaskRepository, TasksRepository>();
            builder.Services.Configure<TasksConfig>
                (builder.Configuration.GetSection("TarefasDatabase"));

            builder.Services.AddSingleton<TasksConfig>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}