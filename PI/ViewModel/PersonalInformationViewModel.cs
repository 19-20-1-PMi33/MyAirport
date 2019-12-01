using System;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    public class PersonalInformationViewModel : INotifyPropertyChanged
    {
        public PersonalInformationViewModel(string Login,int FlightId)
        {
            this.Login = Login;
            this.FlightId = FlightId;
            BirthDate = DateTime.Now;
            _GenderList = new List<string>()
            {
                "Male",
                "Female"
            };
            _SeatingList = new List<string>()
            {
                "First Class ($180)",
                "Bussines Class ($145)",
                "Economic Class ($100)"
            }; 

        }
        List<string> _GenderList;
        List<string> _SeatingList;

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Document { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Seating { get; set; }
        public string Login { get; set; }
        public int FlightId { get; set; }
        public List<string> GenderList
        {
            get => _GenderList;
            set
            {
                _GenderList = value;
                OnPropertyChanged("GenderList");
            }
        }
        public List<string> SeatingList
        {
            get => _SeatingList;
            set
            {
                _SeatingList = value;
                OnPropertyChanged("SeatingList");
            }
        }

        public RelayCommand AddPassenger
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (FirstName != "" && SecondName != "" && Document != "" && Gender != null && Seating != null) 
                    {
                        var sum = Int32.Parse(new String(string.Join(" ", Seating.Split(' ').ToList()[2]).Where(Char.IsDigit).ToArray()));
                        PersonalInformation personalInformation = new PersonalInformation();
                        personalInformation.FirstName = FirstName;
                        personalInformation.SecondName = SecondName;
                        personalInformation.Document = Document;
                        personalInformation.Gender = Gender.ToString();
                        personalInformation.FlightId = FlightId;
                        personalInformation.BirthDate = BirthDate;
                        personalInformation.Seating = string.Join(" ", Seating.Split(' ').ToList().GetRange(0, 2)).ToString();
                        personalInformation.Login = Login;
                        Class1.Add(personalInformation, sum);

                        Views.Payment menu = new Views.Payment(Login);
                        menu.Show();
                        CloseWindow();
                    }
                    else
                    {
                        MessageBox.Show("Сheck fields for correctness");
                    }
                });
            }
        }
        public RelayCommand CloseCommand
        {
            get
            {
                return new RelayCommand((obj) => CloseWindow());
            }
        }
        private void CloseWindow()
        {
            Application.Current.Windows
                    .Cast<Window>()
                    .Single(w => w.DataContext == this)
                    .Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
