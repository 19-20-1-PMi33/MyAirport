using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між AddAirplane.xaml та AddAirplaneViewModel.
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
