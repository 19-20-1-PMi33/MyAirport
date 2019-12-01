using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAirplane.xaml
    /// </summary>
    public partial class AddAirplane : Page
    {
        public AddAirplane()
        {
            DataContext = new ViewModel.AddAirplaneViewModel();
            InitializeComponent();
        }
    }
}
