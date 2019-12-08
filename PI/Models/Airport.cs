namespace PI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Airport")]
    /// <summary>
    /// ���� Airport.
    /// ���� ��� ������������ � �������� Airport � ��� �����.
    /// </summary>
    public partial class Airport
    {
        public Airport()
        { }

        [Key]
        [StringLength(50)]
        public string CIty { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string IATA { get; set; }
    }
}
