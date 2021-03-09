using Core.Model;
using Core.Model.Enum;
using Entity.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Controller
{
    class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(MoneyWalletContext context)
            : base(context)
        {

        }

        public async Task<List<Salary>> GetSalaryAsync(int userId, bool includeUser = false)
        {
            if (includeUser)
                return await Context.Salary.Where(x => x.UserId == userId).Include(x => x.User).ToListAsync();
            else
                return await GetAsync(x => x.UserId == userId);
        }

        public async Task<List<Salary>> GetSalaryByDateAsync(int userId, DateTime? from = null, DateTime? to = null)
        {
            if (!from.HasValue || !to.HasValue)
            {
                var now = DateTime.Now;
                from = new DateTime(now.Year, now.Month, 1);
                to = new DateTime(now.Year, now.Month + 1, 1).AddDays(-1);
            }

            return await GetAsync(x =>
            x.UserId == userId &&
            x.CreatedWhen > from.Value &&
            x.CreatedWhen < to.Value &&
            x.SalaryType == SalaryType.OnceOnly
            );
        }
    }
}
