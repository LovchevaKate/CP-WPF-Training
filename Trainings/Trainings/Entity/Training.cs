using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Entity
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public int Id_Trener { get; set; }
        public int Id_Sportsman { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey ("Id_Sportsman")]
        public virtual Sportsman Sportsman { get; set; }
        [ForeignKey("Id_Trener")]
        public virtual Trener Trener { get; set; }
    }
}
