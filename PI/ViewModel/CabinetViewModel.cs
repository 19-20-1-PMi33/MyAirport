using System.Windows;
using System.Data.Entity;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    public class CabinetViewModel
    {
        ApplicationContext db;

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
    }
}
