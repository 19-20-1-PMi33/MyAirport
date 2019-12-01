using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using PI.Helpers;

namespace PI.Views
{
    /// <summary>
    /// Логика взаимодействия для FindPage.xaml
    /// </summary>
    public partial class FindPage : Page
    {
        public FindPage()
        {
            InitializeComponent();
            
        }
        public FindPage(string Login)
        {
            this.Login = Login;
            DataContext = new ViewModel.AirportViewModel(Login);
            InitializeComponent();
        }

        public string Login { get; set; }

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    CountAdult.SelectedIndex = 0;
        //    CountChild.SelectedIndex = 0;
        //    CountInfant.SelectedIndex = 0;
        //    DepartAirport.Items.Clear();
        //    ArrivalAirport.Items.Clear();
        //    DatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(2019, 11, 1), DateTime.Today.AddDays(-1)));
        //    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            con.Open();
        //            cmd.Connection = con;
        //            cmd.CommandText = "SELECT DISTINCT City FROM Airport Order by City";
        //            SqlDataReader dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                DepartAirport.Items.Add(dr["City"]);
        //                ArrivalAirport.Items.Add(dr["City"]);
        //            }
        //            dr.Close();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void SearchFlights_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(CountAdult.Text);
        //    if (DepartAirport.Text != "" && ArrivalAirport.Text != "" && DatePicker.Text != "")
        //    {
        //        try
        //        {
        //            string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
        //            string query = $"SELECT Id,DepartCity,ArriveCity,convert(varchar(10),DepartDate,104) as 'DepartDate'," +
        //                $"convert(varchar(10),ArriveDate,104) as 'ArrivalDate',CAST(DepartTime AS CHAR(5)) as 'DepartTime',CAST(ArriveTime AS CHAR(5)) as 'ArriveTime',AirplaneID as 'AirplaneId',Airline FROM FLIGHT " +
        //                $"where DepartCity = '{DepartAirport.Text}' AND ArriveCity = '{ArrivalAirport.Text}' and convert(varchar(10),DepartDate,104) = '{Convert.ToDateTime(DatePicker.Text).ToString("dd.MM.yyyy")}'";
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        //                DataSet ds = new DataSet();
        //                adapter.Fill(ds);
        //                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
        //            }
        //        }
        //        catch (Exception ee)
        //        {
        //            MessageBox.Show(ee.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Заповніть всі поля");
        //    }
        //}

        //private void ReserveTicket_Click(object sender, RoutedEventArgs e)
        //{
        //    if (dataGrid.SelectedItem != null)
        //    {
        //        try
        //        {
        //            DataRowView row = dataGrid.SelectedItem as DataRowView;
        //            Personal_Information personalInformationWindow = new Personal_Information(Login, Convert.ToInt32(row.Row.ItemArray[0].ToString()));
        //            Class1.Clear();
        //            personalInformationWindow.Show();

        //        }
        //        catch (Exception ee)
        //        {
        //            MessageBox.Show(ee.Message);
        //        }
        //    }
        //}
    }
}
