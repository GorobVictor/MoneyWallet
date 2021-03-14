using Core.Model;
using Core.Model.Dto;
using Core.Model.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface ICostsRepository : IBaseRepository<Costs>
    {
        Task<List<Costs>> GetCostsAsync(int userId, WasteType type = 0);
        Task UpdateCostsAsync(List<GetSetCosts> items, int userUpdated);
        Task UpdateCostsAsync(List<Costs> items);
        Task AddCostsAsync(List<GetSetCosts> items, int userUpdated);
    }
}
