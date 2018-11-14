using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainings.Entity
{
    public class Sportsman 
    {
        public Sportsman() { }
        public Sportsman(string login, string password) { }
        [Key]
        
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Login { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Sname { get; set; }
        [Required]
        [MaxLength(12)]
        public string Telephone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(25)]
        public string Password { get; set; }

        public virtual ICollection<Training> Training { get; set; }
        public SportsmanInfo Info { get; set; }
        public virtual ICollection<SportsmanEating> Eating { get; set; }
    }
}
    
