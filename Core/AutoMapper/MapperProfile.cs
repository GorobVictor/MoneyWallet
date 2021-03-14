using AutoMapper;
using Core.Model;
using Core.Model.Dto;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Costs, GetSetCosts>();
            this.CreateMap<GetSetCosts, Costs>();

            this.CreateMap<Salary, GetSetSalary>().
                ForMember(x=>x.ValueToCurrency, memOpt => memOpt.MapFrom(x=> CurrencyParser.Convert(x.Currency, x.User.Currency, x.Value)));
            this.CreateMap<GetSetSalary, Salary>();
        }
    }
}
