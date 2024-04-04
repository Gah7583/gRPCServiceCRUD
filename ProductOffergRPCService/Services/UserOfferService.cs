using AutoMapper;
using Grpc.Core;
using ProductOffergRPCService.Protos;
using ProductOffergRPCService.Repositories;
using ProductOfferService = ProductOffergRPCService.Protos.UserOfferService;

namespace ProductOffergRPCService.Services
{
    public class UserOfferService(IProductOfferService productOfferService, IMapper mapper) : ProductOfferService.UserOfferServiceBase
    {
        private readonly IProductOfferService _productOfferService = productOfferService;
        private readonly IMapper _mapper = mapper;

        public async override Task<UserOffers> GetUserOfferList(EmptyRequestArg emptyRequestArg, ServerCallContext context)
        {
            var offersData = await _productOfferService.GetOfferListAsync();
            UserOffers response = new UserOffers();
            foreach (var offer in offersData)
            {
                response.Items.Add(_mapper.Map<UserOfferDetail>(offer));
            }
            return response;
        }
    }
}
