using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Domain.Constants;

namespace Wish.Application.Responses.User
{
    public class UserProfileResponse
    {
        public string Username { get; set; }
        public string FullName { get; set; }
    }
}
