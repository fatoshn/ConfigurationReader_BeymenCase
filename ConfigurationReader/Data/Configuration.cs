using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationReader.Data
{
    [Table("Configuration")]
    public class Configuration
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Type")]
        public string Type { get; set; }
        [Column("Value")]
        public string Value { get; set; }
        [Column("IsActive")]
        public byte IsActive { get; set; }
        [Column("ApplicationName")]
        public string ApplicationName { get; set; }
    }
}
