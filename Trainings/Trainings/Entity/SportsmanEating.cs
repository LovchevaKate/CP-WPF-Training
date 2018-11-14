using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Entity
{
    public class SportsmanEating 
    {
        [Key]
        public int Id { get; set; }
        public int Id_Sportsman { get; set; }
        
        public DateTime Date { get; set; }        
        public string Breakfast { get; set; }       
        public string Lunch { get; set; }       
        public string Dinner { get; set; }

        [ForeignKey("Id_Sportsman")]
        public virtual Sportsman Sportsman { get; set; }
    }
}
