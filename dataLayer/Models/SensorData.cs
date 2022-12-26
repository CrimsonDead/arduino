using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dataLayer.Models
{
    public class SensorData
    {
        [Key]
        public int Id { get; set; }
        public int SensorId { get; set; }
        [ForeignKey("SensorId")]
        public Sensor Sensor { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
    }
}