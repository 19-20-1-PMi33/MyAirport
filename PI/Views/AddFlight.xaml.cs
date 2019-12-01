using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Page
    {
        public AddFlight()
        {
            InitializeComponent();
            DataContext = new PI.ViewModel.AddFlightViewModel();
        }
    }
}
