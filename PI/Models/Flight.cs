namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Table("Flight")]
    public partial class Flight : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            PersonalInformation = new HashSet<PersonalInformation>();
        }

        //private DateTime _DepartDate;
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ArriveCity { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ArriveDate { get; set; }

        public TimeSpan DepartTime { get; set; }

        public TimeSpan ArriveTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Airline { get; set; }

        public int AirplaneID { get; set; }

        public virtual Airplane Airplane { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport Airport1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalInformation> PersonalInformation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
