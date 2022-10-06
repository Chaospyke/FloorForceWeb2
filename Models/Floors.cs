using System.ComponentModel.DataAnnotations;

namespace FloorForce2.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Desc { get; set; }
        public decimal Price { get; set; }
    }
}