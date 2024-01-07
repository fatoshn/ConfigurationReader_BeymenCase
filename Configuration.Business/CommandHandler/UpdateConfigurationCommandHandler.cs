using Configuration.Business.Command;
using Configuration.Data.Model;
using Configuration.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Configuration.Business.CommandHandler
{
    public class UpdateConfigurationCommandHandler : IRequestHandler<UpdateConfigurationCommand, ConfigurationModel>
    {
        private readonly IConfigurationRepository _configurationRepository;


        public UpdateConfigurationCommandHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }


        public async Task<ConfigurationModel> Handle(UpdateConfigurationCommand request, CancellationToken cancellationToken)
        {
            var configurationModel = new ConfigurationModel
            {
                ID = request.Id,
                Name = request.Name,
                Type = request.Type,
                Value = request.Value,
                IsActive = request.IsActive,
                ApplicationName = request.ApplicationName,
                RowVersion = Convert.FromBase64String(request.RowVersion)
            };
            try
            {
                await _configurationRepository.Update(configurationModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApplicationException("The record has already been updated. Please check and try again. \n\n\n");
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }
            return configurationModel;
        }
    }
}
