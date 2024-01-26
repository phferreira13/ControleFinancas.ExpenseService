﻿using ExpenseService.Domain.Enums;

namespace ExpenseService.Domain.Models
{
    public class Expense : DbEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Value { get; private set; }
        public DateTime ExpenseDate { get; private set; }
        public int ExpenseTypeId { get; private set; }

        public int AccountId { get; private set; }
        public int UserId { get; private set; }

        public ExpenseType? ExpenseType { get; private set; }

        public Expense(string name, decimal value, DateTime expenseDate, int expenseTypeId, int accountId, int userId, string? description = null)
        {
            Name = name;
            Description = description;
            Value = value;
            ExpenseDate = expenseDate;
            ExpenseTypeId = expenseTypeId;
            AccountId = accountId;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            Status = EEntityStatus.Active;
        }
    }
}
