using Core.Model;
using Core.Model.Dto;
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
                return await Context.Salary.Where(x => x.UserId == userId).Include(x => x.User).AsNoTracking().ToListAsync();
            else
                return await GetAsync(x => x.UserId == userId);
        }

        public async Task<List<Salary>> GetSalaryByDateAsync(int userId, DateTime? from = null, DateTime? to = null, bool includeUser = false)
        {
            if (!from.HasValue || !to.HasValue)
            {
                var now = DateTime.Now;
                from = new DateTime(now.Year, now.Month, 1);
                to = new DateTime(now.Year, now.Month + 1, 1).AddDays(-1);
            }

            if (includeUser)
                return await Context.Salary.Where(x =>
                    x.UserId == userId &&
                    x.CreatedWhen > from.Value &&
                    x.CreatedWhen < to.Value
                    ).Include(x => x.User).AsNoTracking().ToListAsync();
            else
                return await GetAsync(x =>
                    x.UserId == userId &&
                    x.CreatedWhen > from.Value &&
                    x.CreatedWhen < to.Value
                    );
        }

        public async Task UpdateSalaryAsync(List<GetSetSalary> objects, int userId)
        {
            await UpdateAsync(objects.Select(x => new Salary(GetFirst(y => y.Id == x.Id), x, userId)).ToList());
        }
    }
}
