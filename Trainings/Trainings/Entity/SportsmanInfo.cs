using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Entity
{
    public class SportsmanInfo 
    {
        [Key]
        [ForeignKey("Sportsman")]
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public string Height { get; set; }
        [Required]
        [MaxLength(3)]
        public string Weight { get; set; }
        [Required]
        [MaxLength(11)]
        public string Body_Parametrs { get; set; }
        
        public virtual Sportsman Sportsman { get; set; }
    }
}
