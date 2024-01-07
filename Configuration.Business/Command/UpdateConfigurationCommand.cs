using Configuration.Data.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Business.Command
{
    public class UpdateConfigurationCommand : IRequest<ConfigurationModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public byte IsActive { get; set; }
        public string ApplicationName { get; set; }
        public string RowVersion { get; set; }

    }
}
