namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Table("Customer")]
    public partial class Customer : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Payment = new HashSet<Payment>();
        }
        //private string _Login;
        //private string _Password;
        //private string _Email;

        [Key]
        [StringLength(50)]
        public string Login { get; set; }
        //{
        //    get
        //    {
        //        return _Login;
        //    }
        //    set
        //    {
        //        _Login = value;
        //        OnPropertyChanged("Login");
        //    }
        //}

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        //{
        //    get
        //    {
        //        return _Password;
        //    }
        //    set
        //    {
        //        _Password = value;
        //        OnPropertyChanged("Password");
        //    }
        //}

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        //{
        //    get
        //    {
        //        return _Email;
        //    }
        //    set
        //    {
        //        _Email = value;
        //        OnPropertyChanged("Email");
        //    }
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
