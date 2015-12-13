using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Mappers;
using Hyde.Api.Model.RequestModels;
using Hyde.Domain.Model;
using AutoMapper;

namespace Hyde.Api.Config
{
    public class AutoMapperConfig
    {
        public static void InitialAutoMapper()
        {
            Mapper.CreateMap<supplyDto, SupplyAdd>().ForMember(t => t.SupplyID, o => o.MapFrom(s => s.key));
            Mapper.CreateMap<SupplyEdit, supplyDto>().ForMember(t => t.key, o => o.Ignore());
        }
    }
}
