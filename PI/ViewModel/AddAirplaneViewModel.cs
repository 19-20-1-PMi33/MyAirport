using System.Data.Entity;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System;
using System.Windows;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас AddAirplaneViewModel.
    /// Клас добавляє нові літаки у базу даних.
    /// </summary>
    public class AddAirplaneViewModel 
    {
        ApplicationContext db;
        /// <summary>
        /// Конструктор в якому метод (db.Airplane.Load()) загружає дані в  ApplicationContext.
        /// </summary>
        public AddAirplaneViewModel()
        {
            db = new ApplicationContext();
            db.Airplane.Load();
        }
       
        public string Id { get; set; }
        public string Model { get; set; }
        public string Econom { get; set; }
        public string Business { get; set; }
        public string First { get; set; }

        /// <summary>
        /// AddAirplaneCommand команда, що створює дані про нові літаки.
        /// </summary>
        /// <remarks>
        /// Сворює дані про новий літак в базі даних, попередньо перевіряючи його відсутність в ній.
        /// </remarks>
        public RelayCommand AddAirplaneCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    
                    if (db.Airplane.Find(Id) != null)
                    {
                        MessageBox.Show("Plane id already reserved");
                    }
                    else
                    {
                        try
                        {
                            Airplane airplane = new Airplane();
                            airplane.Id = int.Parse(Id);
                            airplane.Model = Model;
                            airplane.Econom = int.Parse(Econom);
                            airplane.Business = int.Parse(Business);
                            airplane.First = int.Parse(First);
                            db.Airplane.Add(airplane);
                            db.SaveChanges();
                            Id = Econom = Business = First = "";
                            Model = "";
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
        /// DeleteAirplaneCommand команда, що видаляє дані про вибраний літак.
        /// </summary>
        public RelayCommand DeleteAirplaneCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {

                });
            }
        }
    }
}
