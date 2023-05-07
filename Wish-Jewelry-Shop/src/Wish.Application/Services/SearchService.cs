using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Application.Responses.Product;
using Wish.Application.Responses.Results;
using Wish.Application.Services.Interfaces;
using Wish.Domain.Entities;
using Wish.Persistence;

namespace Wish.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly MainDbContext _dbContext;
        public SearchService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<IEnumerable<ProductResponse>>> GetItemsWhatContains(string s, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Products.AsNoTracking()
                .Where(p => p.Title.ToLower().Contains(s.ToLower()))
                .Select(p => 
                new ProductResponse 
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    PictureImage= p.PictureImage,
                    Price = p.Price,
                    Weight= p.Weight,
                    CategoryId= p.CategoryId,
                    Count = p.Count
                })
                .ToListAsync(cancellationToken);

            if(result is null)
            {
                return new InvalidResult<IEnumerable<ProductResponse>>("Ничего не найдено");
            }
            return new SuccessResult<IEnumerable<ProductResponse>>(result);
        }
    }
}
