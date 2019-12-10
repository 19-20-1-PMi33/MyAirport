namespace PI.ViewModel
{
    using System.Data.Entity;
    using PI.Models;
    using PI.Helpers;
    using PI.Commands;
    using System;
    using System.Windows;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;

    /// <summary>
    /// Клас AddAirplaneViewModel.
    /// Клас добавляє нові літаки у базу даних.
    /// </summary>
    public class AddAirplaneViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        /// <summary>
        /// Конструктор в якому метод (db.Airplane.Load()) загружає дані в  ApplicationContext.
        /// </summary>
        public AddAirplaneViewModel()
        {
            db = new ApplicationContext();
            db.Airplane.Load();
            Airplanes = db.Airplane.Select(x => x.Id)
                            .Distinct()
                            .ToList();
            db.Flight.Load();
            db.PersonalInformation.Load();
        }

        private string _Id, _Model, _Econom, _Business, _First;

        private int _SelectedAirplane;

        private List<int> _Airplanes;

        public List<int> Airplanes
        {
            get => _Airplanes;
            set
            {
                _Airplanes = value;
                OnPropertyChanged("Airplanes");
            }
        }

        public int SelectedAirplane
        {
            get => _SelectedAirplane;
            set
            {
                _SelectedAirplane = value;
                OnPropertyChanged("SelectedAirplane");
            }
        }

        public string Id
        {
            get => _Id;
            set
            {
                _Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Model
        {
            get => _Model;
            set
            {
                _Model = value;
                OnPropertyChanged("Model");
            }
        }

        public string Econom
        {
            get => _Econom;
            set
            {
                _Econom = value;
                OnPropertyChanged("Econom");
            }
        }

        public string Business
        {
            get => _Business;
            set
            {
                _Business = value;
                OnPropertyChanged("Business");
            }
        }

        public string First
        {
            get => _First;
            set
            {
                _First = value;
                OnPropertyChanged("First");
            }
        }

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

                    if (db.Airplane.Find(int.Parse(Id)) != null)
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
                            Model = Id = Econom = Business = First = string.Empty;
                            Airplanes = db.Airplane.Select(x => x.Id)
                                    .Distinct()
                                    .ToList();

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
                    try
                    {

                        Airplane airplane = db.Airplane.Find(SelectedAirplane);
                        db.Flight.RemoveRange(db.Flight.Where(x => x.AirplaneID == SelectedAirplane));
                        db.SaveChanges();
                        db.Airplane.Remove(airplane);
                        db.SaveChanges();
                        Airplanes = db.Airplane.Select(x => x.Id)
                                .Distinct()
                                .ToList();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Delete all flight with this airplane");
                    }

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
