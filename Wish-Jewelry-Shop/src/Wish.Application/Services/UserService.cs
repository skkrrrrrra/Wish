using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Wish.Application.Responses.Results;
using Wish.Application.Responses.User;
using Wish.Domain.Entities;
using Wish.Persistence;
using Wish.Persistence.Common;

namespace Wish.Application.Services
{
    public class UserService : IUserService
    {
        private readonly MainDbContext _dbContext;
        private readonly IAuditUserProvider _auditUserProvider;
        public UserService(MainDbContext dbContext, IAuditUserProvider provider)
        {
            _dbContext = dbContext;
            _auditUserProvider = provider;
        }
        public async Task<Result<UserProfileResponse>> GetUserInfoAsync(CancellationToken cancellationToken)
        {
            var currentUserId = _auditUserProvider.GetUserId();

            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(p => p.Id == currentUserId, cancellationToken);

            if (userProfile is null)
            {
                return new InvalidResult<UserProfileResponse>("Что-то пошло не так, обратитесь в поддержку");
            }

            var result = Map<UserProfileResponse>(userProfile);

           
            return new SuccessResult<UserProfileResponse>(result);
        }
    }
}
