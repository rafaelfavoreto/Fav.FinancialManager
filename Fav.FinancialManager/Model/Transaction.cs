using Fav.FinancialManager.Enum;
using LiteDB;

namespace Fav.FinancialManager.Model;

public class Transaction
{
    public Transaction(string name, TransactionTypeEnum type, DateTimeOffset date, decimal value)
    {
        Name = name;
        Type = type;
        Date = date;
        Value = value;
    }

    [BsonId]
    public int Id { get; private set; }
    public TransactionTypeEnum Type { get; private set; }
    public string Name { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public decimal Value { get; private set; }

}