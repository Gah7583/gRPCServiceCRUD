using AutoMapper;
using ProductOffergRPCService.Entities;
using ProductOffergRPCService.Protos;

namespace ProductOffergRPCService.AutoMapper
{
    public class OfferMapper : Profile
    {
        public OfferMapper() 
        {
            CreateMap<Offer, OfferDetail>().ReverseMap();
        }
    }
}
