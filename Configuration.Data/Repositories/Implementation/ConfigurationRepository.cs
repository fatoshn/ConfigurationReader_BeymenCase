using Configuration.Data.Context;
using Configuration.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Data.Repositories.Implementation
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ConfigurationDbContext _context;

        public ConfigurationRepository(ConfigurationDbContext context)
        {
            _context = context;
        }
        public async Task<ConfigurationModel> Add(ConfigurationModel model)
        {
            _context.ConfigurationModels.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(int Id, byte[] rowVersion)
        {
            var configurationModel = _context.ConfigurationModels
            .FirstOrDefault(p => p.ID == Id && p.RowVersion == rowVersion);

            if (configurationModel is null) throw new DbUpdateConcurrencyException();

            configurationModel.RowVersion = rowVersion;
            _context.ConfigurationModels.Remove(configurationModel);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ConfigurationModel>> GetAllList()
        {
            return await _context.ConfigurationModels.ToListAsync();
        }

        public async Task<ConfigurationModel> GetById(int Id)
        {
            return await _context.ConfigurationModels.FirstOrDefaultAsync(p => p.ID == Id);
        }

        public async Task<ConfigurationModel> Update(ConfigurationModel model)
        {
            _context.ConfigurationModels.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
