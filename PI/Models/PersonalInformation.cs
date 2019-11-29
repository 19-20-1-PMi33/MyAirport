namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonalInformation")]
    public partial class PersonalInformation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightId { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Document { get; set; }

        [Required]
        [StringLength(50)]
        public string Seating { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
