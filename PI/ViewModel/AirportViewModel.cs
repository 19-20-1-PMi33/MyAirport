﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    public class AirportViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        IEnumerable<string> _Airports;
        List<Flight> _Flights;
        DateTime _SelectedDate;
        DateTime _DateStart;
        Flight _SelectedFlight;

        public AirportViewModel(string Login)
        {
            db = new ApplicationContext();
            db.Airport.Load();
            db.Flight.Load();
            _Airports = db.Airport.OrderBy(x => x.CIty)
                .Select(x=>x.CIty)
                .Distinct().ToList();
            _Flights = db.Flight.Local.ToBindingList()
                .OrderBy(x=>x.DepartDate)
                .ThenBy(x=>x.DepartTime).ToList();
            SelectedDate = DateStart = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            this.Login = Login;
        }
        public string Login { get; set; }
        public string DepartCity { get; set; }
        public string ArriveCity { get; set; }

        public DateTime SelectedDate
        {
            get => _SelectedDate;
            set
            {
                _SelectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }
        public DateTime DateStart
        {
            get => _DateStart;
            set
            {
                _DateStart = DateTime.Now;
                OnPropertyChanged("DateStart");
            }
        }
        public Flight SelectedFlight
        {
            get => _SelectedFlight;
            set
            {
                _SelectedFlight = value;
                OnPropertyChanged("SelectedFlight");
            }
        }
        public RelayCommand ReserveTicketCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (SelectedFlight != null)
                    {
                        MessageBox.Show(SelectedFlight.DepartDate.ToString());
                        Views.Personal_Information menu = new Views.Personal_Information(Login, SelectedFlight.Id);
                        menu.Show();
                    }
                });
            }
        }
        public List<Flight> Flights
        {
            get => _Flights;
            set
            {
                _Flights = value;
                OnPropertyChanged("Flights");
            }
        }

        public IEnumerable<string> Airports
        {
            get => _Airports;
            set
            {
                _Airports = value;
                OnPropertyChanged("Airports");
            }
        }

        public RelayCommand FindFlightsCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    MessageBox.Show(DepartCity);
                    MessageBox.Show(ArriveCity);
                    MessageBox.Show(SelectedDate.ToString());
                    if (DepartCity != "" && ArriveCity != "")
                    {
                        Flights = db.Flight.Local.ToBindingList()
                                .Where(x => x.DepartDate == SelectedDate && x.DepartCity == DepartCity && x.ArriveCity == ArriveCity)
                                .OrderBy(x => x.DepartDate)
                                .ThenBy(x => x.DepartTime)
                                .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Fill in all the fields");
                    }
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
