namespace PI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Клас Airplane.
    /// Клас для комунікування з таблицею Airplane у базі даних.
    /// </summary>

    [Table("Airplane")]
    public partial class Airplane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airplane()
        {
            Flight = new HashSet<Flight>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int Econom { get; set; }

        public int Business { get; set; }

        public int First { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
