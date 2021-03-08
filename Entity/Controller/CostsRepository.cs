using Entity.Interface;
using Entity.Model;
using Entity.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Controller
{
    public class CostsRepository : BaseRepository<Costs>, ICostsRepository
    {
        public CostsRepository(MoneyWalletContext context)
            : base(context)
        {

        }

        public async Task<List<Costs>> GetCostsAsync(int userId, WasteType type = 0)
        {
            if (type != 0)
            {
                return await GetAsync(x => x.CreatedBy == userId && x.WasteType == type);
            }
            else
            {
                return await GetAsync(x => x.CreatedBy == userId);
            }
        }

        public async Task UpdateCostsAsync(List<Costs> items)
        {
            await UpdateAsync(items);
        }

        public async Task AddCostsAsync(List<Costs> items)
        {
            await AddAsync(items);
        }
    }
}
