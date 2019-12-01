using System.Data.Entity;
using PI.Models;
using PI.Helpers;
using PI.Commands;

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
                    Airport airport = new Airport();
                    airport.CIty = City;
                    airport.Country = Country;
                    airport.IATA = IATA;
                    db.Airport.Add(airport);
                    db.SaveChanges();
                    City = Country = IATA = "";
                });
            }
        }
    }
}
