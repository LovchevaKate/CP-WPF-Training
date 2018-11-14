using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainings.Entity
{
    public class Trener 
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string FIO { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Training> Training { get; set; }
    }
}
