using System.Windows;
using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас AddFlightViewModel.
    /// Клас добавляє нові дані про користувача у базу даних.
    /// </summary>
    public class CabinetViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        // <summary>
        /// Конструктор в якому метод (db.Customer.Load()) загружає дані в  ApplicationContext.
        /// </summary>
        public CabinetViewModel(string Login)
        {
            db = new ApplicationContext();
            db.Customer.Load();
            this.Login = Login;
        }
        public string Login { get; private set; }

        public string _OldPassword, _NewPassword, _RepeatNewPassword;
        public string _OldEmail, _NewEmail, _RepeatNewEmail;
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

        /// <summary>
        /// ChangePasswordCommand команда, що змінює пароль користувача.
        /// </summary>
        /// <remarks>
        /// Попередньо перевіряючи його співпадіння зі старим.
        /// </remarks>
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
        /// <summary>
        /// ChangeEmailCommand команда, що змінює електронну пошту користувача.
        /// </summary>
        /// <remarks>
        /// Попередньо перевіряючи її співпадіння зі старою.
        /// </remarks>
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
