﻿using Entity.Model;
using Entity.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface ICostsRepository
    {
        Task<List<Costs>> GetCostsAsync(int userId, WasteType type);
        Task UpdateCostsAsync(List<Costs> items);
        Task AddCostsAsync(List<Costs> items);
    }
}