using System.Text;
using CommunityToolkit.Mvvm.Messaging;
using Fav.FinancialManager.Enum;
using Fav.FinancialManager.Model;
using Fav.FinancialManager.Repositories;

namespace Fav.FinancialManager.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _repository;
    public TransactionAdd(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }
    private void ButtonClicked(object? sender, EventArgs e)
    {
        if (!IsValid()) return;
        var transaction = GetDataTransaction();
        Save(transaction);
        WeakReferenceMessenger.Default.Send<string>(string.Empty);

        GetUpdatedRecords();
    }

    #region Aux. Methods

    private Transaction GetDataTransaction()
    {
        return new Transaction(name: EntryName.Text,
            type: RadioExpense.IsChecked ? TransactionTypeEnum.Expenses : TransactionTypeEnum.Income,
            date: DatePickerDate.Date, value: Convert.ToDecimal(EntryValue.Text));
    }

    private bool IsDecimal(string valueString)
    {
        decimal value;
        return decimal.TryParse(EntryValue.Text,out value);
    }
    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    #endregion

    #region Crud
    private void Save(Transaction transaction)
    {
        _repository.Add(transaction);
        Navigation.PopModalAsync();
    }

    private void GetUpdatedRecords()
    {
        var count = _repository.GetAll().Count;
        App.Current.MainPage.DisplayAlert("Message!", $" There are {count} recors in the DataBase", "OK");
    }
       
    #endregion
    
    #region Validations
    private bool IsValid()
    {
        var valid = true;
        var messageNotification = new StringBuilder();
        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            messageNotification.AppendLine("The name was not filled");
            valid = false;
        }

        if (!string.IsNullOrEmpty(EntryValue.Text) && !IsDecimal(EntryValue.Text))
        {
            messageNotification.AppendLine("The 'Value' was not filled or invalid");
            valid = false;
        }

        if (DatePickerDate == null)
        {
            messageNotification.AppendLine("The 'Date' was not filled");
            valid = false;
        }

        if (valid) return valid;
        NameError.Text = messageNotification.ToString();
        NameError.IsVisible = true;

        return valid;
    }

    #endregion
}