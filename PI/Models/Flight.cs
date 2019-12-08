namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Flight")]
    /// <summary>
    /// Клас Flight.
    /// Клас для комунікування з таблицею Flight у базі даних.
    /// </summary>
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            PersonalInformation = new HashSet<PersonalInformation>();
        }

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

        public int BusinessClass { get; set; }

        public int FirstClass { get; set; }

        public int EconomicClass { get; set; }

        [Required]
        [StringLength(50)]
        public string Airline { get; set; }

        public int AirplaneID { get; set; }

        public virtual Airplane Airplane { get; set; }

        public virtual Airport Airport { get; set; }

        public virtual Airport Airport1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalInformation> PersonalInformation { get; set; }
    }
}
