using Configuration.Data.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Business.Query
{
    public class GetConfigurationByIdQuery : IRequest<ConfigurationModel>
    {
        public int Id { get; set; }
    }
}
        
        
        
        
        
       