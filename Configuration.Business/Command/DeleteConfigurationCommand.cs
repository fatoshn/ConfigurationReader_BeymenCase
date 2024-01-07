using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Business.Command
{
    public class DeleteConfigurationCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string RowVersion { get; set; }
    }
}
