namespace Tarefa.Domain.Model.Aggregates.Tasks.Entities
{
    public class Tasks
    {
        public string? TaskId { get; set; }
        public virtual User? User { get; set; }
        public virtual string? Title { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime ExpiresAt { get; set; }
        public virtual DateTime CreatedAt { get; set; }

    }
}
