using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Call
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid LocalPointId { get; set; }
        public LocalPoint LocalPoint { get; set; }
        public string Number { get; set; }
        public string CallDecryption { get; set; }
    }
}