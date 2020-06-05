using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Sensor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid LocalPointId { get; set; }
        public LocalPoint LocalPoint { get; set; }
        public ICollection<SensorData> SensorData { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long CreationDate { get; set; }
    }
}
