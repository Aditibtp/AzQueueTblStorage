using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System.IO;

namespace AzQueueTblStorage
{
    class KeyVaultAuthToStorage
    {
        public static async Task<string> GetConnectionString()
        {
            string kvUri = "<key-vault-url>";
            string connStrKey = "<secret-name-conn-str>";

            var tokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));

            var pass = await keyVaultClient.GetSecretAsync(kvUri, connStrKey);
            string connectionStr = pass.Value;

            return connectionStr;
        }
    }
}
