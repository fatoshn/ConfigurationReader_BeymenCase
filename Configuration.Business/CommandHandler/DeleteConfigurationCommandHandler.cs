using Configuration.Business.Command;
using Configuration.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Configuration.Business.CommandHandler
{
    public class DeleteConfigurationCommandHandler : IRequestHandler<DeleteConfigurationCommand, int>
    {
        private readonly IConfigurationRepository _configurationRepository;


        public DeleteConfigurationCommandHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }


        public async Task<int> Handle(DeleteConfigurationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var c = Convert.FromBase64String(request.RowVersion);
                await _configurationRepository.Delete(request.Id, Convert.FromBase64String(request.RowVersion));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ArgumentException("The record has been updated. Please check and try again. \n\n\n");
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }
            return default(int);
        }

    }
}
