using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Page
    {
        public Cabinet()
        {
            InitializeComponent();
        }
        public Cabinet(string login)
        {
            InitializeComponent();
            Login = login;
            DataContext = new ViewModel.CabinetViewModel(Login);
        }
        public string Login { get; set; }
    }
}
