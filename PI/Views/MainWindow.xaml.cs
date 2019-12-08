using System.Windows;
using System.Windows.Input;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        /// <summary>
        /// Створює зв'язок між  MainWindow.xaml та LoginRegistrationViewModel.
        /// </summary>
        public MainWindow()
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
