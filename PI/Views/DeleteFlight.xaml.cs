using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між DeleteFlight.xaml та  ChangeDeleteFlightViewModel.
    /// </summary>
    public partial class DeleteFlight : Page
    {
        public DeleteFlight()
        {
            DataContext = new ViewModel.ChangeDeleteFlightViewModel();
            InitializeComponent();
        }
    }
}
