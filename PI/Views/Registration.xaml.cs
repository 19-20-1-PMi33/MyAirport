using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між   Registration.xaml та   LoginRegistrationViewModel.
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            DataContext = new ViewModel.LoginRegistrationViewModel();
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
