using Fav.FinancialManager.Repositories;

namespace Fav.FinancialManager.Views;

public partial class TransactionEdit : ContentPage
{
    private readonly ITransactionRepository _repository;
	public TransactionEdit(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }
    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}