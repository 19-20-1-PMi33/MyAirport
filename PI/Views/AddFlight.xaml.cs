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

namespace PI.ViewModel
{
    public class AddFlightViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        List<string> _Airports;
        List<int> _Airplanes;



        public AddFlightViewModel()
        {
            db = new ApplicationContext();
            db.Flight.Load();
            db.Airport.Load();
            db.Airplane.Load();
            _Airports = db.Airport.OrderBy(x => x.CIty)
                .Select(x => x.CIty)
                .Distinct().ToList();
            _Airplanes = db.Airplane.OrderBy(x => x.Id)
                .Select(x => x.Id).Distinct().ToList();
            DepartDate = ArriveDate = DateTime.Now;
        }

        public string DepartTown { get; set; }
        public string ArriveTown { get; set; }
        public string Airline { get; set; }
        public int AirplaneId { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArriveTime { get; set; }

        public List<string> Airports
        {
            get => _Airports;
            set
            {
                _Airports = value;
                OnPropertyChanged("Airports");
            }
        }
        public List<int> Airplanes
        {
            get => _Airplanes;
            set
            {
                _Airplanes = value;
                OnPropertyChanged("Airplanes");
            }
        }

        public RelayCommand AddFlightCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var dt = DepartTime.ToString().Split(' ')[1];
                    var at = ArriveTime.ToString().Split(' ')[1];
                    if (new DateTime(DepartDate.Year, DepartDate.Month, DepartDate.Day, Int32.Parse(dt.Split(':')[0]), Int32.Parse(dt.Split(':')[1]), 00) < new DateTime(ArriveDate.Year, ArriveDate.Month, ArriveDate.Day, Int32.Parse(at.Split(':')[0]), Int32.Parse(at.Split(':')[1]), 00))
                    {
                        Flight flight = new Flight();
                        flight.DepartCity = DepartTown;
                        flight.ArriveCity = ArriveTown;
                        flight.DepartDate = DepartDate;
                        flight.ArriveDate = ArriveDate;
                        flight.DepartTime = new TimeSpan(Int32.Parse(dt.Split(':')[0]), Int32.Parse(dt.Split(':')[1]), 00);
                        flight.ArriveTime = new TimeSpan(Int32.Parse(at.Split(':')[0]), Int32.Parse(at.Split(':')[1]), 00);
                        flight.AirplaneID = AirplaneId;
                        flight.Airline = Airline;
                        db.Flight.Add(flight);
                        db.SaveChanges();
                        DepartTown = ArriveTown = Airline = null;
                        DepartDate = ArriveDate = DateTime.Now;
                        ArriveTime = DepartTime = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Wrong date and time selected");
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
