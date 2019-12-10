using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;


namespace PI.ViewModel
{
    /// <summary>
    /// Клас ScheduleViewModel призначений перегляду всіх наявних рейсів чи рейсів на конкретну дату.
    /// </summary>
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        List<Flight> _Flights;

        /// <summary>
        /// Конструктор в якому за допомогою методів типу (db.****.Load()) загружають дані в  ApplicationContext.
        /// _Flights витягує та оперує даними наявних  польотів.
        /// </summary>
        public ScheduleViewModel()
        {
            db = new ApplicationContext();
            db.Flight.Load();
            _Flights = db.Flight.Local.ToBindingList()
                .Where(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) <=
                 new DateTime(x.DepartDate.Year, x.DepartDate.Month, x.DepartDate.Day, x.DepartTime.Hours, x.DepartTime.Minutes, 00))
                .OrderBy(x => x.DepartDate)
                .ThenBy(x => x.DepartTime).ToList();
            SelectedDate = DateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
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

        public DateTime SelectedDate { get; set; }

        public DateTime DateStart { get; set; }

        /// <summary>
        /// FindFlightsCommand команда, яка витягує дані бази даних про всі наявні польоти задоної дати.
        /// </summary>
        public RelayCommand FindFlightsCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    Flights = db.Flight.Local.ToBindingList()
                            .Where(x => x.DepartDate == SelectedDate)
                            .OrderBy(x => x.DepartTime)
                            .ToList();
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
