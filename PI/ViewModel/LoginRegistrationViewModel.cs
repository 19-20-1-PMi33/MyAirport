﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Linq;
using PI.Models;
using PI.Helpers;
using PI.Commands;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows;
using System;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас LoginRegistrationViewModel призначений для проведення процедури реєстрації.
    /// </summary>
    public class LoginRegistrationViewModel :  INotifyPropertyChanged
    {
        ApplicationContext db;

        private string _Login;
        private string _Password;
        private string _Email;

        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        
        public LoginRegistrationViewModel()
        {
            db = new ApplicationContext();
            db.Customer.Load();
        }
        /// <summary>
        /// Визначає параметри входу для простого користувача та адміністратора.
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (Login == "1" && Password == "1")
                    {
                        ShowAdminWindow();
                    }
                    else
                    {
                        var query = db.Customer.Count(x => x.Login == Login && x.Password == Password);
                        if (query == 1)
                        {
                            ShowMenuWindow();
                        }

                        else
                        {
                            MessageBox.Show("Wrong login or password");
                        }
                    }
                });
            }
        }
        /// <summary>
        /// OpenRegistrationWindowCommand команда, що відкриває вікно реєстрації.
        /// </summary>
        public RelayCommand OpenRegistrationWindowCommand
        {
            get
            {
                return new RelayCommand((obj) => ShowRegistrationWindow());
            }
        }

        /// <summary>
        /// AddNewCustomer команда, що створює дані про нового користувача.
        /// </summary>
        /// <remarks>
        /// Попередньо перевіряючи співпадіння логіну даного користувача з уже наявними в базі даних.
        /// </remarks>
        public RelayCommand AddNewCustomer
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var query = db.Customer.Count(x => x.Login == Login);
                    if(query == 1)
                    {
                        MessageBox.Show("Login is already reserved");
                    }
                    else
                    {
                        Customer customer = new Customer();
                        customer.Login = Login;
                        customer.Email = Email;
                        customer.Password = Password;
                        db.Customer.Add(customer);
                        db.SaveChanges();
                        ShowMainWindow();
                    }
                });
            }
        }
        /// <summary>
        /// CloseCommand команда, що закриває наявне вікно.
        /// </summary>
        public RelayCommand CloseCommand
        {
            get
            {
                return new RelayCommand((obj) => CloseWindow());
            }
        }
        
        private void ShowAdminWindow()
        {
            Views.Admin menu = new Views.Admin();
            menu.Show();
            CloseWindow();
        }
        private void ShowMainWindow()
        {
            Views.MainWindow menu = new Views.MainWindow();
            menu.Show();
            CloseWindow();
        }
        private void ShowMenuWindow()
        {
            Views.Menu menu = new Views.Menu(Login);
            menu.Show();
            CloseWindow();
        }
        private void ShowRegistrationWindow()
        {
            Views.Registration menu = new Views.Registration();
            menu.Show();
            CloseWindow();
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
