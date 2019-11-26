using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Configuration;

namespace PI
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RegistationButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBlock.Text != "" && EmailBlock.Text != "" && PasswordBox.Password != "")
            {
                if (PasswordBox.Password.Length > 6)
                {

                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                        string second_query = $"INSERT INTO Customer (Login,Password,Email) VALUES ('{LoginBlock.Text}', '{PasswordBox.Password}', '{EmailBlock.Text}');";
                        string first_query = $"SELECT CAST(CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS BIT) FROM Customer WHERE Login = '{LoginBlock.Text}'";
                        object count = "";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(first_query, connection);
                            count = command.ExecuteScalar();
                            if (count.ToString() == "True")
                            {
                                MessageBox.Show("This login is already used by another user");
                            }
                            else
                            {
                                command = new SqlCommand(second_query, connection);
                                command.ExecuteNonQuery();
                                count = "False";
                            }
                            connection.Close();
                        }
                        if (count.ToString() == "False")
                        {
                            MainWindow mainWindow = new MainWindow();
                            this.Visibility = Visibility.Hidden;
                            mainWindow.Show();
                        }

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Password is too short");
                }
            }
            else
            {
                MessageBox.Show("Fill in all the fields");
            }
        }
    }
}
