using System;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //if (Login1.Text == "" && Password.Password == "")
            //{
            //    Admin adminWindow = new Admin();
            //    this.Visibility = Visibility.Hidden;
            //    adminWindow.Show();
            //}
            //else
            //{
            //    try
            //    {
            //        string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            //        string second_query = $"SELECT Count(*) from Customer where Login = '{Login1.Text.ToString()}' AND Password = '{Password.Password}'";
            //        string first_query = $"SELECT CAST(CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS BIT) FROM Customer WHERE Login = '{Login1.Text}'";


            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            connection.Open();

            //            SqlCommand command = new SqlCommand(first_query, connection);
            //            object count = command.ExecuteScalar();
            //            if (count.ToString() == "False")
            //            {
            //                MessageBox.Show("Wrong login or password");
            //            }
            //            else
            //            {
            //                command  = new SqlCommand(second_query, connection);
            //                count = command.ExecuteScalar();
            //                if ((int)count == 1)
            //                {
            //                    Menu menuWindow = new Menu(Login1.Text);
            //                    this.Visibility = Visibility.Hidden;
            //                    menuWindow.Show();
                                
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Wrong login or password");
            //                }
            //            }
            //            connection.Close();
            //        }
            //    }
               
            //    catch (Exception ee)
            //    {
            //        MessageBox.Show(ee.Message);
            //    }
            //}
        }

        private void Registation_Click(object sender, RoutedEventArgs e)
        {
            Registration registrationWindow = new Registration();
            this.Visibility = Visibility.Hidden;
            registrationWindow.Show();
        }

        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
