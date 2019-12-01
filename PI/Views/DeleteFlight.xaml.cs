using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для DeleteFlight.xaml
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
