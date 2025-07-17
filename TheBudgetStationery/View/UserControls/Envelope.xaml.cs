using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TheBudgetStationery.Models;

namespace TheBudgetStationery.View.UserControls;

public partial class Envelope : UserControl
{

    public Models.Envelope MyEnvelope { get; set; }

    public Envelope()
    {
        InitializeComponent();

        if (!DesignerProperties.GetIsInDesignMode(this))
        {
            // Only set real data at runtime
            this.DataContext = new Models.Envelope();
        }
        else
        {
            // Set sample data for preview
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

    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {

    }
}
