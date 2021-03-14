using Entity.Interface;
using Core.Model;
using Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Model.Dto;
using System.Linq;

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
                return await GetAsync(x => x.UserId == userId && x.WasteType == type);
            }
            else
            {
                return await GetAsync(x => x.UserId == userId);
            }
        }

        public async Task UpdateCostsAsync(List<GetSetCosts> items, int userUpdated)
        {
            await UpdateAsync(items.Select(x => new Costs(GetFirst(y => y.Id == x.Id), x, userUpdated)).ToList());
        }

        public async Task UpdateCostsAsync(List<Costs> items)
        {
            await UpdateAsync(items);
        }

        public async Task AddCostsAsync(List<GetSetCosts> items, int userUpdated)
        {
            await AddAsync(items.Select(x => new Costs(x, userUpdated)).ToList());
        }
    }
}
