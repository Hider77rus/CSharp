using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TuiWebService.Common.Models;

namespace TuiWebService.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TourPriceOffer, Tour>();
        }
    }
}
