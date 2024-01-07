using Configuration.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Data.Repositories
{
    public interface IConfigurationRepository
    {
        Task<ICollection<ConfigurationModel>> GetAllList();
        Task<ConfigurationModel> Add(ConfigurationModel model);
        Task<ConfigurationModel> GetById(int Id);
        Task<ConfigurationModel> Update(ConfigurationModel model);
        Task Delete(int Id, byte[] rowVersion);
    }
}
