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
    /// Клас ReserveTicketViewModel призначений для бронювання авіаквитків.
    /// </summary>
    public class ReserveTicketViewModel
    {
        ApplicationContext db;

        /// <summary>
        /// Конструктор в якому за допомогою методів типу (db.****.Load()) загружають дані в  ApplicationContext.
        /// <param name="Login">Параметр який передає дані про поточного користувача, для відслідковування операцій зроблених ним</param>
        ///  _Airports,_Flights витягує та оперує даними наявних для бронювання аеропортів та польотів із них,відповідно.
        /// </summary>
        public ReserveTicketViewModel(string Login)
        {
            db = new ApplicationContext();
            db.Airport.Load();
            db.Flight.Load();
            Airports = db.Airport.OrderBy(x => x.CIty)
                .Select(x=>x.CIty)
                .Distinct().ToList();
            Flights = db.Flight.Local.ToBindingList()
                 .Where(x => new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second) <= 
                 new DateTime(x.DepartDate.Year,x.DepartDate.Month, x.DepartDate.Day, x.DepartTime.Hours,x.DepartTime.Minutes,00))
                .OrderBy(x=>x.DepartDate)
                .ThenBy(x=>x.DepartTime).ToList();
            
            SelectedDate = DateStart = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            this.Login = Login;
        }
        public string Login { get; set; }
        public string DepartCity { get; set; }
        public string ArriveCity { get; set; }

        public int CountAdult { get; set; }
        public int CountInfant { get; set; }
        public int CountChild { get; set; }

        public DateTime SelectedDate { get; set; }

        public DateTime DateStart { get; set; }
        public Flight SelectedFlight { get; set; }

        public RelayCommand ReserveTicketCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (SelectedFlight != null)
                    {
                        if (SelectedFlight.FirstClass + SelectedFlight.EconomicClass + SelectedFlight.BusinessClass >= CountAdult + CountChild + CountInfant)
                        {
                            if (CountAdult >= CountInfant && CountAdult != 0)
                            {
                                Views.Personal_Information menu = new Views.Personal_Information(Login, SelectedFlight.Id,CountAdult+CountChild+CountInfant);
                                Clients.Clear();
                                Clients.FirstClass = SelectedFlight.FirstClass;
                                Clients.BusinessClass = SelectedFlight.BusinessClass;
                                Clients.EconomicClass = SelectedFlight.EconomicClass;
                                menu.Show();
                            }
                            else
                            {
                                MessageBox.Show("The number of adults must exceed the number of infants and not equal to zero");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not so many tickets for this flight");
                        }
                    }
                });
            }
        }
        public List<Flight> Flights { get; set; }

        public IEnumerable<string> Airports { get; set; }

        public RelayCommand FindFlightsCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
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
    }
}
