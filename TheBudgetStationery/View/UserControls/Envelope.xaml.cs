using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

using TheBudgetStationery.Models;

namespace TheBudgetStationery.View.UserControls;

public partial class Envelope
{
    public Models.Envelope MyEnvelope { get; set; }

    public Envelope()
    {
        InitializeComponent();

        if (!DesignerProperties.GetIsInDesignMode(this))
        {
            this.DataContext = new Models.Envelope();
        }
        else
        {
            this.DataContext = new Models.Envelope
            {
                Name = "New Unnamed Envelope",
                Balance = 49.73m,
                CountdownAmount = 22,
                CountdownDays = 2,
                CountdownCheck = true,
            };
        }
    }

    private void btnNewTransaction_Click(object sender, RoutedEventArgs e)
    {
        // Get the owner window for proper modal behavior & centering
        var owner = Window.GetWindow(this);

        var dlg = new NewTransactionWindow
        {
            Owner = owner,
            ShowInTaskbar = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        bool? ok = dlg.ShowDialog();
        if (ok == true)
        {
            // Pull the result from the dialog
            var delta = dlg.AmountDelta;

            // Apply to the current envelope model
            var env = MyEnvelope ?? (this.DataContext as Models.Envelope);
            if (env is not null)
            {
                env.Balance += delta;
            }
        }
        // else: user cancelled or closed the dialog
    }

    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {
        // left as-is for now
    }
}
