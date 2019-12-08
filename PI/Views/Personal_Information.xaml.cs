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

        public Personal_Information(string Login, int IdFlight,int CountTickets)
        {
            this.IdFlight = IdFlight;
            this.Login = Login;
            this.CountTickets = CountTickets;
            DataContext = new ViewModel.PersonalInformationViewModel(Login,IdFlight,CountTickets);
            InitializeComponent();
        }
        /// <value>Логін поточного користувача.</value>
        public string Login { get; set; }
        /// <value>Номер рейсу на який купляють квиток.</value>
        public int IdFlight { get; set; }
        /// <value>Кількість квитків</value>
        public int CountTickets { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
