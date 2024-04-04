using ProductOffergRPCService.Entities;

namespace ProductOffergRPCService.Repositories
{
    public interface IProductOfferService
    {
        public Task<List<Offer>> GetOfferListAsync();
        public Task<Offer> GetOfferByIdAsync(int id);
        public Task<Offer> AddOfferAsync(Offer offer);
        public Task<Offer> UpdateOfferAsync(Offer offer);
        public Task<bool> DeleteOfferByIdAsync(int id);
    }
}
