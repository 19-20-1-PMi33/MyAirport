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
