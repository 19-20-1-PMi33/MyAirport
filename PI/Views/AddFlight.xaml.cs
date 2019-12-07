using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System.Windows.Controls;

namespace PI.Views
{
    public partial class AddFlight : Page
    {
        public AddFlight()
        {
            DataContext = new ViewModel.AddFlightViewModel();
            InitializeComponent();
        }
    }
}
