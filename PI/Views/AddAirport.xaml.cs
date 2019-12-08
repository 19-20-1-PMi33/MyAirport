using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;


namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між AddAirport.xaml та AddAirportViewModel.
    /// </summary>
    public partial class AddAirport : Page
    {
        public AddAirport()
        {
            DataContext = new ViewModel.AddAirportViewModel();
            InitializeComponent();
        }
    }
}
