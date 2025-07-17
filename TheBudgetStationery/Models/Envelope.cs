using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBudgetStationery.Models;
public class Envelope : INotifyPropertyChanged
{
    private string _name = "New Unnamed Budget";
    private decimal _balance = 0;
    private decimal _countdownAmount;
    private int _countdownDays;
    private bool _countdownCheck;

    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }

    public decimal Balance
    {
        get => _balance;
        set { _balance = value; OnPropertyChanged(nameof(Balance)); }
    }

    public decimal CountdownAmount
    {
        get => _countdownAmount;
        set { _countdownAmount = value; OnPropertyChanged(nameof(CountdownAmount)); }
    }

    public int CountdownDays
    {
        get => _countdownDays;
        set { _countdownDays = value; OnPropertyChanged(nameof(CountdownDays)); }
    }

    public bool CountdownCheck
    {
        get => _countdownCheck;
        set { _countdownCheck = value; OnPropertyChanged(nameof(CountdownDays)); }
    }

    public string CountdownText => CountdownCheck
        ? $"${CountdownAmount} in {CountdownDays} day{(CountdownDays == 1 ? "" : "s")}"
        : "Auto-add not set";

    public event PropertyChangedEventHandler? PropertyChanged = null;

    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
