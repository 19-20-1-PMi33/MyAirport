using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    class AddAirportViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;

        private string _City,_Country,_IATA;

        public AddAirportViewModel()
        {
            db = new ApplicationContext();
            db.Airport.Load();
        }

        public string City { get; set; }
        

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
