﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using PI.Helpers;

namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між  FindPage.xaml та  ReserveTicketViewModel.
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
            DataContext = new ViewModel.ReserveTicketViewModel(Login);
            InitializeComponent();
        }

        public string Login { get; set; }
    }
}
