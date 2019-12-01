﻿using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
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

        public string Id { get; set; }
        public string Model { get; set; }
        public string Econom { get; set; }
        public string Business { get; set; }
        public string First { get; set; }

        public RelayCommand AddAirplaneCommand
        {
            get
            {
                return new RelayCommand((obj) =>
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
                        Id = Model = Econom = Business = First = "";
                    }
                    catch(FormatException)
                    {
                        MessageBox.Show("Сheck fields for correctness");
                    }
                });
            }
        }
    }
}