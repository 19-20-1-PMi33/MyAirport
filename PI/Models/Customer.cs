namespace PI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    /// <summary>
    /// Клас Customer.
    /// Клас для комунікування з таблицею Customer у базі даних.
    /// </summary>
    public partial class Customer
    {
        public Customer()
        { }

        [Key]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

    }
}
