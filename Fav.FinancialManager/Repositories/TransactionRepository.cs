using Fav.FinancialManager.Model;
using LiteDB;

namespace Fav.FinancialManager.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly LiteDatabase _database;
    private readonly string COLLECTIONNAME = "Transaction";
    public TransactionRepository()
    {
        _database = new LiteDatabase("Filename=C:/Users/Rafael/AppData/database.db;Connection=Shared");
    }

    public List<Transaction> GetAll()
    {
       return _database
           .GetCollection<Transaction>(COLLECTIONNAME)
           .Query()
           .OrderByDescending(a => a.Date)
           .ToList();
    }

    public void Add(Transaction transaction)
    {
        var col = _database.GetCollection<Transaction>(COLLECTIONNAME);
        col.Insert(transaction);
        col.EnsureIndex(a => a.Date);
    }
    public void Update(Transaction transaction)
    {
        var col = _database.GetCollection<Transaction>(COLLECTIONNAME);
        col.Update(transaction);
    }

    public void Delete(Transaction transaction)
    {
        var col = _database.GetCollection<Transaction>(COLLECTIONNAME);
        col.Delete(transaction.Id);
    }

}