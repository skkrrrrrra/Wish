using Wish.Application.Responses.User;
using Wish.Domain.Entities;

namespace Wish.Application.Services
{
    public interface IUserService
    {
        public Task<Result<UserProfileResponse>> GetUserInfoAsync(CancellationToken cancellationToken);
    }
}