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
    /// <summary>
    /// Клас AddFlightViewModel.
    /// Клас добавляє нові польоти у базу даних.
    /// </summary>
    public class AddFlightViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        List<string> _Airports;
        List<int> _Airplanes;


        // <summary>
        /// Конструктор в якому методи типу (db.****.Load()) загружають дані в  ApplicationContext.
        /// </summary>
        /// <remarks>
        /// __Airports, _Airplanes витягує та оперує даними наявних аеропортів та літаків,відповідно.
        /// </remarks>
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
        private string _DepartTown, _ArriveTown, _Airline;
        private int _AirplaneId;
        private DateTime _DepartDate, _ArriveDate, _DepartTime, _ArriveTime;
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

        /// <summary>
        /// AddFlightCommand команда, що створює дані про нові польоти.
        /// </summary>
        /// <remarks>
        /// Сворює дані про новий політ в базі даних, попередньо перевіряючи валідність дат.
        /// </remarks>
        public RelayCommand AddFlightCommand
        {
            get
            {

                return new RelayCommand((obj) =>
                {
                    var dt = DepartTime.ToString().Split(' ')[1];
                    var at = ArriveTime.ToString().Split(' ')[1];
                    if (DepartTown != ArriveTown)
                    {
                        if (new DateTime(DepartDate.Year, DepartDate.Month, DepartDate.Day, Int32.Parse(dt.Split(':')[0]), Int32.Parse(dt.Split(':')[1]), 00) < new DateTime(ArriveDate.Year, ArriveDate.Month, ArriveDate.Day, Int32.Parse(at.Split(':')[0]), Int32.Parse(at.Split(':')[1]), 00))
                        {
                            Flight flight = new Flight();
                            Airplane airplane = db.Airplane.Find(AirplaneId);
                            flight.DepartCity = DepartTown;
                            flight.ArriveCity = ArriveTown;
                            flight.DepartDate = DepartDate;
                            flight.ArriveDate = ArriveDate;
                            flight.DepartTime = new TimeSpan(Int32.Parse(dt.Split(':')[0]), Int32.Parse(dt.Split(':')[1]), 00);
                            flight.ArriveTime = new TimeSpan(Int32.Parse(at.Split(':')[0]), Int32.Parse(at.Split(':')[1]), 00);
                            flight.AirplaneID = AirplaneId;
                            flight.Airline = Airline;
                            flight.FirstClass = airplane.First;
                            flight.BusinessClass = airplane.Business;
                            flight.EconomicClass = airplane.Econom;
                            db.Flight.Add(flight);
                            db.SaveChanges();
                            DepartTown = ArriveTown = Airports[0];
                            AirplaneId = Airplanes[0];
                            DepartDate = ArriveDate = DateTime.Now;
                            ArriveTime = DepartTime = DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("Wrong date or time selected");
                        }
                    }
                    MessageBox.Show("Wrong sites");
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
