using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;


namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAirport.xaml
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
