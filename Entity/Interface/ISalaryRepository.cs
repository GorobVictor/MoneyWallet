using Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface ISalaryRepository : IBaseRepository<Salary>
    {
        Task<List<Salary>> GetSalaryAsync(int userId, bool includeUser = false);
        Task<List<Salary>> GetSalaryByDateAsync(int userId, DateTime? from = null, DateTime? to = null);
    }
}
