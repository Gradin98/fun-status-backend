using JWTAuth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWTAuth
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
