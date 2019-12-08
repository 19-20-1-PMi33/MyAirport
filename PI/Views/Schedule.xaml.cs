using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між  Schedule.xaml та   ScheduleViewModel.
    /// </summary>
    public partial class Schedule : Page
    {
        public Schedule()
        {
            DataContext = new ViewModel.ScheduleViewModel();
            InitializeComponent();
        }
    }
}
