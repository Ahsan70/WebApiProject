using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FxTradeApi.Models;

namespace FxTradeApi.ParkyMapper
{
    public class ParkyMapping:Profile
    {
        public ParkyMapping()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
        }
    }
}
