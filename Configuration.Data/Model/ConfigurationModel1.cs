using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Data.Model
{
    public class ConfigurationModel1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public byte IsActive { get; set; }
        public string ApplicationName { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
