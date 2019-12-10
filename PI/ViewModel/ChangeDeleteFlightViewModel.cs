using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System;
using System.Windows;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас ChangeDeleteFlightViewModel призначений для зміни та видалення польотів.
    /// </summary>
    public class ChangeDeleteFlightViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        /// <summary>
        /// Конструктор в якому за допомогою методів типу (db.****.Load()) загружають дані в  ApplicationContext.
        ///  _Flights витягує та оперує даними наявних польотів, для подальшої їх зміни.
        /// </summary>
        public ChangeDeleteFlightViewModel()
        {
            db = new ApplicationContext();
            db.Flight.Load();
            db.PersonalInformation.Load();
            Flights = db.Flight.Local.ToBindingList()
                .OrderBy(x => x.DepartDate)
                .ThenBy(x => x.DepartTime).ToList();
        }

        private List<Flight> _Flights;

        private Flight _SelectedFlight;

        public List<Flight> Flights
        {
            get => _Flights;
            set
            {
                _Flights = value;
                OnPropertyChanged("Flights");
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

        /// <summary>
        /// ChangeFlightCommand команда, що змінює дані про вибраний політ.
        /// </summary>
        /// <remarks>
        /// Попередньо перевіряючи валідність дат.
        /// </remarks>
        public RelayCommand ChangeFlightCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    MessageBox.Show(SelectedFlight.ArriveTime.ToString());
                    var dt = SelectedFlight.DepartTime.ToString();
                    var at = SelectedFlight.ArriveTime.ToString();

                    if (new DateTime(SelectedFlight.DepartDate.Year, SelectedFlight.DepartDate.Month, SelectedFlight.DepartDate.Day, Int32.Parse(dt.Split(':')[0]), Int32.Parse(dt.Split(':')[1]), 00)
                    < new DateTime(SelectedFlight.ArriveDate.Year, SelectedFlight.ArriveDate.Month, SelectedFlight.ArriveDate.Day, Int32.Parse(at.Split(':')[0]), Int32.Parse(at.Split(':')[1]), 00))
                    {
                        Flight flight = db.Flight.Find(SelectedFlight.Id);
                        flight.DepartDate = SelectedFlight.DepartDate;
                        flight.ArriveDate = SelectedFlight.ArriveDate;
                        flight.ArriveTime = SelectedFlight.ArriveTime;
                        flight.DepartTime = SelectedFlight.DepartTime;
                        db.SaveChanges();
                        Flights = db.Flight
                            .OrderBy(x => x.DepartDate)
                            .ThenBy(x => x.DepartTime).ToList();
                        SelectedFlight = null;
                    }
                    else
                    {
                        MessageBox.Show("Wrong date or time");
                    }
                });
            }
        }
        /// <summary>
        /// DeleteFlightCommand команда, що видаляє дані про вибраний політ.
        /// </summary>
        /// <remarks>
        /// Попередньо перевіряючи валідність дат.
        /// </remarks>
        public RelayCommand DeleteFlightCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var flight = db.Flight.Find(SelectedFlight.Id);
                    db.PersonalInformation.RemoveRange(db.PersonalInformation.Where(x => x.FlightId == SelectedFlight.Id));
                    db.SaveChanges();
                    db.Flight.Remove(flight);
                    db.SaveChanges();
                    Flights = db.Flight.Local.ToBindingList()
                        .OrderBy(x => x.DepartDate)
                        .ThenBy(x => x.DepartTime).ToList();
                    SelectedFlight = null;
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
