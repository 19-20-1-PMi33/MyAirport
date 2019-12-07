using System.Data.Entity;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System.Windows;
using System;

namespace PI.ViewModel
{
    class AddAirportViewModel 
    {
        ApplicationContext db;

        public AddAirportViewModel()
        {
            db = new ApplicationContext();
            db.Airport.Load();
        }

        public string City { get; set; }
        
        public string Country { get; set; }

        public string IATA { get; set; }

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
                            City = Country = IATA = "";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Сheck fields for correctness");
                        }
                    }
                });
            }
        }
    }
}
