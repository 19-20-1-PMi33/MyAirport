namespace PI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        public double CardNumber { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(50)]
        public string CardType { get; set; }

        [Required]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CardOwner { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CVC { get; set; }

        [Required]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sum { get; set; }

        [Required]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Login { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
