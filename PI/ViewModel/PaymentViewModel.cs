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
    public class PaymentViewModel
    {
        ApplicationContext db;
        public PaymentViewModel(string Login)
        {
            db = new ApplicationContext();
            db.Payment.Load();
            db.PersonalInformation.Load();
            this.Login = Login;
            Sum = "$"+Class1.Sum.ToString();
        }

        public double CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardOwner { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVC { get; set; }
        public string Sum { get; set; }
        public string Login { get; set; }

        public RelayCommand PayCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    foreach (var item in Class1.ListOfQueries)
                    {
                        db.PersonalInformation.Add(item);
                        db.SaveChanges();
                    }
                    
                    Payment payment = new Payment();
                    payment.CardNumber = CardNumber;
                    payment.CardType = CardType;
                    payment.CardOwner = CardOwner;
                    payment.ExpirationDate = ExpirationDate;
                    payment.CVC = CVC;
                    payment.Sum = Class1.Sum;
                    payment.Login = Login;
                    db.Payment.Add(payment);
                    db.SaveChanges();

                    CloseWindow();
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
