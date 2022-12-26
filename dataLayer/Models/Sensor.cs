using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dataLayer.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}