using Fav.FinancialManager.Model;

namespace Fav.FinancialManager.Repositories;

public interface ITransactionRepository
{
    void Add(Transaction  transaction);
    void Delete(Transaction transaction);
    void Update(Transaction transaction);
    List<Transaction> GetAll();
}