namespace PI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// ���� Airplane.
    /// ���� ��� ������������ � �������� Airplane � ��� �����.
    /// </summary>

    [Table("Airplane")]
    public partial class Airplane
    {
        public Airplane()
        { }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Model { get; set; }

        public int Econom { get; set; }

        public int Business { get; set; }

        public int First { get; set; }
    }
}
