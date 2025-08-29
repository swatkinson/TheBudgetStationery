using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace TheBudgetStationery.View.UserControls
{
    public partial class NewTransactionWindow : Window
    {
        public NewTransactionWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The signed amount to apply to the envelope.
        /// Positive = add money, Negative = remove money.
        /// </summary>
        public decimal AmountDelta { get; private set; }

        // Try a few common names for your amount TextBox so this works
        // even if you rename controls later.
        private static readonly string[] AmountFieldCandidates = new[]
        {
            "AmountBox", "AmountTextBox", "txtAmount", "AmountInput"
        };

        private decimal ReadAmountOrZero()
        {
            foreach (var name in AmountFieldCandidates)
            {
                if (this.FindName(name) is TextBox tb)
                {
                    // Accept plain numbers or currency-formatted text
                    if (decimal.TryParse(tb.Text,
                        NumberStyles.Currency | NumberStyles.AllowThousands,
                        CultureInfo.CurrentCulture, out var value))
                    {
                        return value;
                    }
                }
            }
            return 0m;
        }

        private void btnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            var amount = ReadAmountOrZero();
            AmountDelta = Math.Abs(amount);  // ensure positive
            DialogResult = true;             // closes the window and returns true
        }

        private void btnRemoveMoney_Click(object sender, RoutedEventArgs e)
        {
            var amount = ReadAmountOrZero();
            AmountDelta = -Math.Abs(amount); // ensure negative
            DialogResult = true;             // closes the window and returns true
        }
    }
}
