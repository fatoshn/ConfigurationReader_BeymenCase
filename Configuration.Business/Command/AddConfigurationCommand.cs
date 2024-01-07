using Configuration.Data.Model;
using MediatR;

namespace Configuration.Business.Command
{
    public class AddConfigurationCommand : IRequest<ConfigurationModel>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public byte IsActive { get; set; }
        public string ApplicationName { get; set; }
    };
}
