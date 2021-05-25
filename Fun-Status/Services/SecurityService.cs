using Encryption;
using Helpers;
using Fun_Status.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fun_Status.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly AppSettings _appSettings;

        public SecurityService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> Decrypt(string data)
        {
            var decrypt = new Decrypt(_appSettings);
            var decryptedData = await decrypt.Action(Convert.FromBase64String(data));
            return Encoding.UTF8.GetString(decryptedData);
        }

        public async Task<string> Encrypt(string data)
        {
            var encrypt = new Encrypt(_appSettings);
            var encryptedData = await encrypt.Action(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(encryptedData);
        }
    }
}
