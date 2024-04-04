using AutoMapper;
using Grpc.Core;
using ProductOffergRPCService.Entities;
using ProductOffergRPCService.Protos;
using ProductOffergRPCService.Repositories;
using ProductOfferService = ProductOffergRPCService.Protos.ProductOfferService;

namespace ProductOffergRPCService.Services
{
    public class OfferService(IProductOfferService productOfferService, IMapper mapper) : ProductOfferService.ProductOfferServiceBase
    {
        private readonly IProductOfferService _productOfferService = productOfferService;
        private readonly IMapper _mapper = mapper;

        public async override Task<Offers> GetOfferList(Empty request, ServerCallContext context)
        {
            var offersData = await _productOfferService.GetOfferListAsync();
            Offers response = new();
            foreach (var offer in offersData)
            {
                response.Items.Add(_mapper.Map<OfferDetail>(offer));
            }
            return response;
        }

        public async override Task<OfferDetail> GetOffer(GetOfferDetailRequest request, ServerCallContext context)
        {
            var offer = await _productOfferService.GetOfferByIdAsync(request.ProductId);
            var offerDetail = _mapper.Map<OfferDetail>(offer);
            return offerDetail;
        }

        public async override Task<OfferDetail> CreateOffer(CreateOfferDetailRequest request, ServerCallContext context)
        {
            var offer = _mapper.Map<Offer>(request.Offer);
            await _productOfferService.AddOfferAsync(offer);
            var offerDetail = _mapper.Map<OfferDetail>(offer);
            return offerDetail;
        }

        public async override Task<OfferDetail> UpdateOffer(UpdateOfferDetailRequest request, ServerCallContext context)
        {
            var offer = _mapper.Map<Offer>(request.Offer);
            await _productOfferService.UpdateOfferAsync(offer);
            var offerDetail = _mapper.Map<OfferDetail>(offer);
            return offerDetail;
        }

        public async override Task<DeleteOfferDetailResponse> DeleteOffer(DeleteOfferDetailRequest request, ServerCallContext context)
        {
            var isDeleted = await _productOfferService.DeleteOfferByIdAsync(request.ProductId);
            var response = new DeleteOfferDetailResponse
            {
                IsDeleted = isDeleted
            };
            return response;    
        }
    }
}
