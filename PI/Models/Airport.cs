namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Table("Airport")]
    public partial class Airport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airport()
        {
            Flight = new HashSet<Flight>();
            Flight1 = new HashSet<Flight>();
        }

        //private string _CIty;

        //private string _Country;

        //private string _IATA;

        [Key]
        [StringLength(50)]
        public string CIty { get; set; }
        //{
        //    get => _CIty;
        //    set
        //    {
        //        _CIty = value;
        //        OnPropertyChanged("City");
        //    }
        //}

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        //{
        //    get => _Country;
        //    set
        //    {
        //        _Country = value;
        //        OnPropertyChanged("Country");
        //    }
        //}

        [Required]
        [StringLength(50)]
        public string IATA { get; set; }
        //{
        //    get => _IATA;
        //    set
        //    {
        //        _IATA = value;
        //        OnPropertyChanged("IATA");
        //    }
        //}
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight1 { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName]string prop = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //}
    }
}
