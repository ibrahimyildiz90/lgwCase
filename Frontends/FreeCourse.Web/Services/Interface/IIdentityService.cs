using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Interface
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefleshToken();
        Task RevokeRefleshToken();

    }
}
