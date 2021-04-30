using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.db.Models
{
    public class Ship
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Plate { get; set; }
        public int CustomerID { get; set; }
        public int Length { get; set; }

        /*[ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }*/
    }
}