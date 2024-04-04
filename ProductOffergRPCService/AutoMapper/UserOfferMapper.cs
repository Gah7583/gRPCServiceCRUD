using AutoMapper;
using ProductOffergRPCService.Entities;
using ProductOffergRPCService.Protos;

namespace ProductOffergRPCService.AutoMapper
{
    public class UserOfferMapper : Profile
    {
        public UserOfferMapper() 
        {
            CreateMap<Offer, UserOfferDetail>().ReverseMap();
        }
    }
}
