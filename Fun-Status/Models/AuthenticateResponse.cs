using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fun_Status.Models
{
    public class AuthenticateResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
