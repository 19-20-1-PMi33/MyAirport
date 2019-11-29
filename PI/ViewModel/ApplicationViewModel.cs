using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        //RelayCommand LoginCommand;
        IEnumerable<Customer> customers;
        private string _Login;
        private string _Password;
        private string _Email;

        public IEnumerable<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged("Customers");
            }
        }
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
        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Customer.Load();
            Customers = db.Customer.Local.ToBindingList();
        }
        public RelayCommand LoginCommand
        {
            get;
            //{
            //    var loginCheak = db.Customer.Local.ToBindingList();
            //}
        }
        // команда добавления
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand((o) =>
        //          {
        //              Registration phoneWindow = new Registration(new Customer());
                      
        //                  Customer customer = phoneWindow.Customer;
        //                  customer.Login = phoneWindow.LoginBlock.Text;
        //                  customer.Email = phoneWindow.EmailBlock.Text;
        //                  customer.Password = phoneWindow.PasswordBox.Text;
        //                  db.Customers.Add(customer);
        //                  db.SaveChanges();
        //                  phoneWindow.LoginBlock.Text = "";
                     
        //          }));
        //    }
        //}
        //}
        //// команда редактирования
        //public RelayCommand EditCommand
        //{
        //    get
        //    {
        //        return editCommand ??
        //          (editCommand = new RelayCommand((selectedItem) =>
        //          {
        //              if (selectedItem == null) return;
        //              // получаем выделенный объект
        //              Phone phone = selectedItem as Phone;

            //              Phone vm = new Phone()
            //              {
            //                  Id = phone.Id,
            //                  Company = phone.Company,
            //                  Price = phone.Price,
            //                  Title = phone.Title
            //              };
            //              PhoneWindow phoneWindow = new PhoneWindow(vm);


            //              if (phoneWindow.ShowDialog() == true)
            //              {
            //                  // получаем измененный объект
            //                  phone = db.Phones.Find(phoneWindow.Phone.Id);
            //                  if (phone != null)
            //                  {
            //                      phone.Company = phoneWindow.Phone.Company;
            //                      phone.Title = phoneWindow.Phone.Title;
            //                      phone.Price = phoneWindow.Phone.Price;
            //                      db.Entry(phone).State = EntityState.Modified;
            //                      db.SaveChanges();
            //                  }
            //              }
            //          }));
            //    }
            //}
            //// команда удаления
            //public RelayCommand DeleteCommand
            //{
            //    get
            //    {
            //        return deleteCommand ??
            //          (deleteCommand = new RelayCommand((selectedItem) =>
            //          {
            //              if (selectedItem == null) return;
            //              // получаем выделенный объект
            //              Phone phone = selectedItem as Phone;
            //              db.Phones.Remove(phone);
            //              db.SaveChanges();
            //          }));
            //    }
            //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
