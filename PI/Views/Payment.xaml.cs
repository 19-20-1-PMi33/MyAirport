using System;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Configuration;
using PI.Helpers;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
        public Payment(string Login)
        {
            this.Login = Login;
            DataContext = new ViewModel.PaymentViewModel(Login);
            InitializeComponent();
        }
        public string Login { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
