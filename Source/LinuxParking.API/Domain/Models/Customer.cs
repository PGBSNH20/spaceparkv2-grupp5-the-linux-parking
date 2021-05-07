using System.ComponentModel.DataAnnotations;

namespace LinuxParking.API.Domain.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer() { }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}