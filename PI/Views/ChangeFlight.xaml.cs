using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для ChangeFlight.xaml
    /// </summary>
    public partial class ChangeFlight : Page
    {
        public ChangeFlight()
        {
            DataContext = new ViewModel.ChangeDeleteFlightViewModel();
            InitializeComponent();
        }
    }
}
