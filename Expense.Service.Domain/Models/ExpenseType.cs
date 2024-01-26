using ExpenseService.Domain.Enums;

namespace ExpenseService.Domain.Models
{
    public class ExpenseType : DbEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int UserId { get; private set; }

        public ExpenseType(string name, int userId, string? description = null)
        {
            Name = name;
            Description = description;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            Status = EEntityStatus.Active;
        }
    }
}
