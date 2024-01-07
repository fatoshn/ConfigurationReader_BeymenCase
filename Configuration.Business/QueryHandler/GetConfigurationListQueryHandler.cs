using Configuration.Business.Query;
using Configuration.Data.Model;
using Configuration.Data.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Configuration.Business.QueryHandler
{
    public class GetConfigurationListQueryHandler : IRequestHandler<GetConfigurationListQuery, ICollection<ConfigurationModel>>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public GetConfigurationListQueryHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<ICollection<ConfigurationModel>> Handle(GetConfigurationListQuery request, CancellationToken cancellationToken)
        {
            return await _configurationRepository.GetAllList();
        }
    }
}
