using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    public class CabinetViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;

        public CabinetViewModel(string Login)
        {
            db = new ApplicationContext();
            db.Customer.Load();
            this.Login = Login;
        }

        private string _OldPassword;
        private string _NewPassword;
        private string _RepeatNewPassword;

        private string _OldEmail;
        private string _NewEmail;
        private string _RepeatNewEmail;

        public string Login { get; private set; }

        public string OldPassword
        {
            get => _OldPassword;
            set
            {
                _OldPassword = value;
                OnPropertyChanged("OldPassword");
            }
        }
        public string NewPassword
        {
            get => _NewPassword;
            set
            {
                _NewPassword = value;
                OnPropertyChanged("NewPassword");
            }
        }
        public string RepeatNewPassword
        {
            get => _RepeatNewPassword;
            set
            {
                _RepeatNewPassword = value;
                OnPropertyChanged("RepeatNewPassword");
            }
        }

        public string OldEmail
        {
            get => _OldEmail;
            set
            {
                _OldEmail = value;
                OnPropertyChanged("OldEmail");
            }
        }
        public string NewEmail
        {
            get => _NewEmail;
            set
            {
                _NewEmail = value;
                OnPropertyChanged("NewEmail");
            }
        }
        public string RepeatNewEmail
        {
            get => _RepeatNewEmail;
            set
            {
                _RepeatNewEmail = value;
                OnPropertyChanged("RepeatNewEmail");
            }
        }

        public RelayCommand ChangePasswordCommand
        {
            get
            {
                return new RelayCommand((obj) => 
                {
                    var customer = db.Customer.Find(Login);
                    if (customer.Password == OldPassword)
                    {
                        if (NewPassword == RepeatNewPassword)
                        {
                            customer.Password = NewPassword;
                            db.SaveChanges();
                            RepeatNewPassword = "";
                            NewPassword = "";
                            OldPassword = "";
                        }
                        else
                        {
                            MessageBox.Show("The value in the fields must be the same");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                });
            }
        }
        public RelayCommand ChangeEmailCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var customer = db.Customer.Find(Login);
                    if (customer.Email == OldEmail)
                    {
                        if (NewEmail == RepeatNewEmail)
                        {
                            customer.Email = NewEmail;
                            db.SaveChanges();
                            OldEmail = "";
                            NewEmail = "";
                            RepeatNewEmail = "";
                        }
                        else
                        {
                            MessageBox.Show("The value in the fields must be the same");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Email");
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
