using System.ComponentModel.DataAnnotations;

namespace DogApp.Models
{
    public class Dog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public Category Category { get; set; }
        public Owner Owner { get; set; }
    }
}
