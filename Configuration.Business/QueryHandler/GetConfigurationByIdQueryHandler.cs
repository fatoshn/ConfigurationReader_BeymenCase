using Configuration.Business.Query;
using Configuration.Data.Model;
using Configuration.Data.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Configuration.Business.QueryHandler
{
    public class GetConfigurationByIdQueryHandler : IRequestHandler<GetConfigurationByIdQuery, ConfigurationModel>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public GetConfigurationByIdQueryHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<ConfigurationModel> Handle(GetConfigurationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _configurationRepository.GetById(request.Id);
        }
    }
}
