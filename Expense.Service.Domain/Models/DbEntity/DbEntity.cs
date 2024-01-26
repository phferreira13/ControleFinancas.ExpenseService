using ExpenseService.Domain.Enums;

namespace ExpenseService.Domain.Models
{
    public class DbEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public EEntityStatus Status { get; protected set; }

    }
}
