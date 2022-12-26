using System.ComponentModel.DataAnnotations;

namespace dataLayer.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}