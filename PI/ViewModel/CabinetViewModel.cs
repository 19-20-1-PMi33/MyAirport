using System.Windows;
using System.Data.Entity;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    /// <summary>
    /// Клас AddFlightViewModel.
    /// Клас добавляє нові дані про користувача у базу даних.
    /// </summary>
    public class CabinetViewModel
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

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }

        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
        public string RepeatNewEmail { get; set; }

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
    }
}
