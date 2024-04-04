using Microsoft.EntityFrameworkCore;
using ProductOffergRPCService.Data;
using ProductOffergRPCService.Entities;

namespace ProductOffergRPCService.Repositories
{
    public class ProductOfferService(DbContextClass dbContext) : IProductOfferService
    {
        private readonly DbContextClass _dbContext = dbContext;

        public async Task<Offer> AddOfferAsync(Offer offer)
        {
            var result = _dbContext.Offer.Add(offer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteOfferByIdAsync(int id)
        {
            var filteredData = _dbContext.Offer.Where(x => x.Id == id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null;
        }

        public async Task<Offer> GetOfferByIdAsync(int id)
        {
            return await _dbContext.Offer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Offer>> GetOfferListAsync()
        {
            return await _dbContext.Offer.ToListAsync();
        }

        public async Task<Offer> UpdateOfferAsync(Offer offer)
        {
            var result = _dbContext.Offer.Update(offer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
