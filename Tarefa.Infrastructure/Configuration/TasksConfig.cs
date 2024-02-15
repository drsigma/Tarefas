using System.Diagnostics.CodeAnalysis;

namespace Tarefa.Infrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public class TasksConfig
    {
        public string? ConnectionString { get; set; } = null;
        public string? DatabaseName { get; set; } = null;
        public string? BankAccountCollectionName { get; set; } = null;

    }
}