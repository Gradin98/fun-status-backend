using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fun_Status.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<string> Encrypt(string data);
        Task<string> Decrypt(string data);
    }
}
