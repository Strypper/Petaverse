using Petaverse.Models.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petaverse.Refits
{
    public interface IAuthenticateServices
    {
        [Post("/Access/LoginWithPhoneNumber")]
        Task<TotechsIdentityUser> Authenticate(LoginModel model);

        [Post("/Access/Register")]
        Task<UserPrincipal> RegisterAsync(UserPrincipal mode);
    }
}
