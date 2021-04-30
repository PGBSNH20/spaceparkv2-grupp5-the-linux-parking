using System.ComponentModel.DataAnnotations;

namespace api.db.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public Customer() { }
        public Customer(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public Customer(string name)
        {
            Name = name;
        }
    }
}