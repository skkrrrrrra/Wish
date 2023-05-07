using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Wish.Domain.Entities.Identity;

public class UserClaim : IdentityUserClaim<long>
{

}
