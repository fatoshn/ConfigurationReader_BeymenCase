using Configuration.Business.Command;
using Configuration.Data.Model;
using Configuration.Data.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Configuration.Business.CommandHandler
{
    public class AddConfigurationCommandHandler : IRequestHandler<AddConfigurationCommand, ConfigurationModel>
    {
        private readonly IConfigurationRepository _configurationRepository;


        public AddConfigurationCommandHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }


        public async Task<ConfigurationModel> Handle(AddConfigurationCommand request, CancellationToken cancellationToken)
        {
            var configurationModel = new ConfigurationModel
            {
                Name = request.Name,
                Type = request.Type,
                Value = request.Value,
                IsActive = request.IsActive,
                ApplicationName = request.ApplicationName
            };
            try
            {
                await _configurationRepository.Add(configurationModel);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }
            return configurationModel;
        }
    }
}
