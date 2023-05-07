using Wish.Application.Responses.Product;
using Wish.Domain.Entities;

namespace Wish.Application.Services.Interfaces
{
    public interface ISearchService
    {
        public Task<Result<IEnumerable<ProductResponse>>> GetItemsWhatContains(string s, CancellationToken cancellationToken);
    }
}