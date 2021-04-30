using System.ComponentModel.DataAnnotations;

namespace api.db.Models
{
    public class Spot
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}