using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Data.Model
{
    [Table("Configuration")]
    public class ConfigurationModel
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
        public byte[] RowVersion { get; set; }
    }
}
