using System.Collections.Generic;
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
        public RelayCommand OpenRegistrationWindowCommand
        {
            get
            {
                return new RelayCommand((obj) => ShowRegistrationWindow());
            }
        }
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
