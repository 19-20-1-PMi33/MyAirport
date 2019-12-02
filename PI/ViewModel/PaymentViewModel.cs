using System;
using System.Linq;
using System.Data.Entity;
using System.Windows;
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
                    if (CardNumber != null && CardType != null && CardOwner != null && CVC != null) 
                    {
                        try
                        {
                            Payment payment = new Payment();
                            payment.CardNumber = double.Parse(CardNumber);
                            payment.CardType = CardType;
                            payment.CardOwner = CardOwner;
                            payment.ExpirationDate = ExpirationDate;
                            payment.CVC = int.Parse(CVC);
                            payment.Sum = Class1.Sum;
                            payment.Login = Login;
                            db.Payment.Add(payment);
                            db.SaveChanges();

                            foreach (var item in Class1.ListOfQueries)
                            {
                                db.PersonalInformation.Add(item);
                                db.SaveChanges();
                            }
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
