using System;
using System.Linq;
using System.Data.Entity;
using System.Windows;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас PaymentViewModel призначений для оформлення купівлі авіаквитка.
    /// </summary>
    public class PaymentViewModel
    {
        ApplicationContext db;
        /// <summary>
        /// Конструктор в якому за допомогою методів типу (db.****.Load()) загружають дані в  ApplicationContext.
        /// <param name="Login">Параметр який передає дані про поточного користувача, для відслідковування операцій зроблених ним</param>
        /// </summary>
        public PaymentViewModel(string Login)
        {
            db = new ApplicationContext();
            db.Payment.Load();
            db.Flight.Load();
            db.PersonalInformation.Load();
            this.Login = Login;
            Sum = "$"+Clients.Sum.ToString();
            ExpirationDate = DateStart = DateTime.Now;
        }

        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardOwner { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVC { get; set; }
        public string Sum { get; set; }
        public string Login { get; set; }
        public DateTime DateStart { get; set; }

        public RelayCommand PayCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (CardNumber != null && CardType != null && CardOwner != null && CVC != null && CVC.Length!=3) 
                    {
                        try
                        {
                            Payment payment = new Payment();
                            payment.CardNumber = double.Parse(CardNumber);
                            payment.CardType = CardType;
                            payment.CardOwner = CardOwner;
                            payment.ExpirationDate = ExpirationDate;
                            payment.CVC = int.Parse(CVC);
                            payment.Sum = Clients.Sum;
                            payment.Login = Login;
                            db.Payment.Add(payment);
                            db.SaveChanges();
                            foreach (var item in Clients.ListOfClients)
                            {
                                db.PersonalInformation.Add(item);
                                db.SaveChanges();
                            }
                            Flight flight = db.Flight.Find(Clients.ListOfClients[0].FlightId);
                            flight.BusinessClass = Clients.BusinessClass;
                            flight.FirstClass = Clients.FirstClass;
                            flight.EconomicClass = Clients.EconomicClass;
                            db.SaveChanges();
                            CloseWindow();
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Сheck fields for correctness");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Сheck fields for correctness");
                    }
                });
            }
        }
        private void CloseWindow()
        {
            Application.Current.Windows
                    .Cast<Window>()
                    .Single(w => w.DataContext == this)
                    .Close();
        }
    }
}
