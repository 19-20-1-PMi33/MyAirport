using System.Data.Entity;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System.Windows;
using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас AddAirportViewModel.
    /// Клас добавляє нові аеропорти у базу даних.
    /// </summary>
    class AddAirportViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        /// <summary>
        /// Конструктор в якому метод (db.Airport.Load()) загружає дані в  ApplicationContext.
        /// </summary>
        public AddAirportViewModel()
        {
            db = new ApplicationContext();
            db.Airport.Load();
            db.Flight.Load();
            Airports = db.Airport.Select(x => x.CIty)
                .Distinct()
                .ToList();
        }
        private List<string> _Airports;
        private string _City, _Country, _IATA, _SelectedAirport;

        public string SelectedAirport
        {
            get => _SelectedAirport;
            set
            {
                _SelectedAirport = value;
                OnPropertyChanged("SelectedAirport");
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

        public string City
        {
            get => _City;
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        public string Country
        {
            get => _Country;
            set
            {
                _Country = value;
                OnPropertyChanged("Country");
            }
        }

        public string IATA
        {
            get => _IATA;
            set
            {
                _IATA = value;
                OnPropertyChanged("IATA");
            }
        }

        /// <summary>
        /// AddAirportCommand команда, що створює дані про нові аеропорти.
        /// </summary>
        /// <remarks>
        /// Сворює дані про новий аеропорт в базі даних, попередньо перевіряючи його відсутність в ній.
        /// </remarks>
        public RelayCommand AddAirportCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (db.Airport.Find(City) != null)
                    {
                        MessageBox.Show("The airport of this city is already in the database");
                    }
                    else
                    {
                        try
                        {
                            Airport airport = new Airport();
                            airport.CIty = City;
                            airport.Country = Country;
                            airport.IATA = IATA;
                            db.Airport.Add(airport);
                            db.SaveChanges();
                            City = Country = IATA = string.Empty;
                            Airports = db.Airport.Select(x => x.CIty)
                                        .Distinct()
                                        .ToList();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Сheck fields for correctness");
                        }
                    }
                });
            }
        }
        /// <summary>
        /// DeleteAirportCommand команда, що видаляє дані про вибраний аеропорт.
        /// </summary>
        public RelayCommand DeleteAirportCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    Airport airport = db.Airport.Find(SelectedAirport);
                    var query = db.Flight.Where(x => x.DepartCity == SelectedAirport || x.ArriveCity == SelectedAirport);

                    foreach (var item in query)
                    {
                        db.Flight.Remove(item);
                    }
                    db.SaveChanges();
                    db.Airport.Remove(airport);
                    db.SaveChanges();
                    Airports = db.Airport.Select(x => x.CIty)
                                .Distinct()
                                .ToList();
                    SelectedAirport = Airports[0];
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
