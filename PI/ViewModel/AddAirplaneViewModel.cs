using System.Data.Entity;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System;
using System.Windows;

namespace PI.ViewModel
{
    public class AddAirplaneViewModel 
    {
        ApplicationContext db;

        public AddAirplaneViewModel()
        {
            db = new ApplicationContext();
            db.Airplane.Load();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public int Econom { get; set; }
        public int Business { get; set; }
        public int First { get; set; }

        public RelayCommand AddAirplaneCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    try
                    {
                        Airplane airplane = new Airplane();
                        airplane.Id = Id;
                        airplane.Model = Model;
                        airplane.Econom = Econom;
                        airplane.Business = Business;
                        airplane.First = First;
                        db.Airplane.Add(airplane);
                        db.SaveChanges();
                        Id = Econom = Business = First = 0;
                        Model = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Сheck fields for correctness");
                    }
                });
            }
        }
    }
}
