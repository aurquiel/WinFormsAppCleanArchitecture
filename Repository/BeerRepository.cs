using ApplicationBusiness;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private readonly AppDbContext _dbContext;

        public BeerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Beer item)
        {
            var beerModel = new BeerModel()
            {
                Name = item.Name,
                Alcohol = item.Alcohol,
                BrandId = item.BrandId,
            };

            await _dbContext.AddAsync(beerModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var beerModel = await _dbContext.Beers.FindAsync(id);
            _dbContext.Beers.Remove(beerModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Beer item)
        {
            var beerModel = await _dbContext.Beers.FindAsync(item.Id);

            beerModel.Name = item.Name;
            beerModel.Alcohol = item.Alcohol;
            beerModel.BrandId = item.BrandId;

            _dbContext.Entry(beerModel).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beer>> GetAllAsync() => await _dbContext.Beers.Select(b => new Beer() { Id = b.Id, Alcohol = b.Alcohol, BrandId = b.BrandId, Name = b.Name }).ToArrayAsync();

        public async Task<Beer> GetByIdAsync(int id)
        {
            var beerModel = await _dbContext.Beers.FindAsync(id);

            return new Beer()
            {
                Id = beerModel.Id,
                Name = beerModel.Name,
                Alcohol = beerModel.Alcohol,
                BrandId = beerModel.BrandId,
            };
        }
    }
}
