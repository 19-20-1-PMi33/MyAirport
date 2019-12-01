using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PI.Helpers;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для Personal_Information.xaml
    /// </summary>
    public partial class Personal_Information : Window
    {
        public Personal_Information(string Login, int IdFlight)
        {
            this.IdFlight = IdFlight;
            this.Login = Login;
            DataContext = new ViewModel.PersonalInformationViewModel(Login,IdFlight);
            InitializeComponent();
        }
        public string Login { get; set; }
        public int IdFlight { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
