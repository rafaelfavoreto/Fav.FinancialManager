using CommunityToolkit.Mvvm.Messaging;
using Fav.FinancialManager.Repositories;

namespace Fav.FinancialManager.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _repository;
    public TransactionList(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
        // Application.Current.UserAppTheme = AppTheme.Light;

        ReloadRecords();
        ExistsNewRecords();
    }

    #region Aux. Methodos
    private void ReloadRecords()
    {
        CollectionViewTransaction.ItemsSource = _repository.GetAll();
    }
    private void ExistsNewRecords()
    {
        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) => { ReloadRecords(); });
    }
    #endregion

    #region Action Buttons
    private void OnButtonClickedToTransactionAdd(object sender, EventArgs e)
    {

        var context = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(context);
    }

    private void OnButtonClickedToTransactionEdit(object? sender, EventArgs e)
    {
        var context = Handler.MauiContext.Services.GetService<TransactionEdit>();
        Navigation.PushModalAsync(context);
    }

    #endregion

}