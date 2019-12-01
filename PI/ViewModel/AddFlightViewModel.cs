using System;
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
    public class AddFlightViewModel:INotifyPropertyChanged
    {
        ApplicationContext db;
        List<string> _Airports;
        List<int> _Airplanes;

        string _DepartTown, _ArriveTown, _Airline;
        DateTime _DepartDate, _ArriveDate;
        DateTime _ArriveTime, _DepartTime;
        int _AirplaneId;

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
        
        public string DepartTown
        {
            get => _DepartTown;
            set
            {
                _DepartTown = value;
                OnPropertyChanged("DepartTown");
            }
        }
        public string ArriveTown
        {
            get => _ArriveTown;
            set
            {
                _ArriveTown = value;
                OnPropertyChanged("ArriveTown");
            }
        }
        public string Airline
        {
            get => _Airline;
            set
            {
                _Airline = value;
                OnPropertyChanged("Airline");
            }
        }
        public int AirplaneId
        {
            get => _AirplaneId;
            set
            {
                _AirplaneId = value;
                OnPropertyChanged("AirplaneId");
            }
        }
        public DateTime DepartDate
        {
            get => _DepartDate;
            set
            {
                _DepartDate = value;
                OnPropertyChanged("DepartDate");
            }
        }
        public DateTime ArriveDate
        {
            get => _ArriveDate;
            set
            {
                _ArriveDate = value;
                OnPropertyChanged("ArriveDate");
            }
        }
        public DateTime DepartTime
        {
            get => _DepartTime;
            set
            {
                _DepartTime = value;
                OnPropertyChanged("DepartTime");
            }
        }
        public DateTime ArriveTime
        {
            get => _ArriveTime;
            set
            {
                _ArriveTime = value;
                OnPropertyChanged("ArriveTime");
            }
        }

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
                    Flight flight = new Flight();
                    var dt = DepartTime.ToString().Split(' ')[1];
                    var at = ArriveTime.ToString().Split(' ')[1];
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
