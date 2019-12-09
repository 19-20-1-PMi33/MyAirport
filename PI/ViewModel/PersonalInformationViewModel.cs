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
    /// <summary>
    /// Клас PersonalInformationViewModel призначений для вибору критеріїв польоту та формування даних про авіаквиток.
    /// </summary>
    public class PersonalInformationViewModel
    {
        public PersonalInformationViewModel(string Login,int FlightId,int CountTickets)
        {
            this.Login = Login;
            this.CountTickets = CountTickets;
            this.FlightId = FlightId;
            BirthDate = DateTime.Now;
            GenderList = new List<string>()
            {
                "Male",
                "Female"
            };
            SeatingList = new List<string>()
            {
                "First Class ($180)",
                "Bussines Class ($145)",
                "Economic Class ($100)"
            }; 

        }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Document { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Seating { get; set; }
        public string Login { get; set; }
        public int FlightId { get; set; }
        public int CountTickets { get; set; }
        public List<string> GenderList { get; set; }
        public List<string> SeatingList { get; set; }

        /// <summary>
        /// AddPassenger команда, яка створює дані про користувача, що бронює авіаквиток.
        /// </summary>
        /// <remarks>
        /// Попередньо перевіряючи логіку заповнень полів.
        /// </remarks>
        public RelayCommand AddPassenger
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (FirstName != "" && SecondName != "" && Document != "" && Gender != null && Seating != null) 
                    {
                        string personalSeating = string.Join(" ", Seating.Split(' ').ToList().GetRange(0, 2)).ToString(); 
                        if (personalSeating == "First Class")
                        {
                            if(Clients.FirstClass != 0)
                            {
                                AddNewPerson();
                                Clients.FirstClass -= 1;
                            }
                            else
                            {
                                MessageBox.Show("No places in this class.");
                            }
                        }
                        if(personalSeating == "Bussines Class")
                        {
                            if (Clients.BusinessClass != 0)
                            {
                                AddNewPerson();
                                Clients.BusinessClass -= 1;
                            }
                            else
                            {
                                MessageBox.Show("No places in this class.");
                            }
                        }
                        if (personalSeating == "Economic Class")
                        {
                            if (Clients.EconomicClass != 0)
                            {
                                AddNewPerson();
                                Clients.EconomicClass -= 1;
                            }
                            else
                            {
                                MessageBox.Show("No places in this class.");
                            }
                        }

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

        /// <summary>
        /// AddNewPerson функція, що вносить дані про користувача який забронював авіаквиток. 
        /// </summary>
        public void AddNewPerson()
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
            CountTickets -= 1;

            Clients.Add(personalInformation, sum);

            if (CountTickets == 0)
            {
                Views.Payment menu = new Views.Payment(Login);
                menu.Show();
                CloseWindow();
            }
            else
            {
                Views.Personal_Information personal_Information = new Views.Personal_Information(Login, FlightId, CountTickets);
                personal_Information.Show();
                CloseWindow();
            }
        }
    }
}
