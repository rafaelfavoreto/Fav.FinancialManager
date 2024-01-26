using Fav.FinancialManager.Views;

namespace Fav.FinancialManager
{
    public partial class App : Application
    {
        private readonly TransactionList _transactionList;
        public App(TransactionList transactionList)
        {
            _transactionList = transactionList;
            InitializeComponent();

            MainPage = new NavigationPage(_transactionList);
        }
    }
}
