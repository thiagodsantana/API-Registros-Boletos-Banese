using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RegBoletoBanese.Models;
using RegBoletoBanese.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RegBoletoBanese.Service.Services.Classes
{
    public class TokenService : ITokenService
    {
        public Token Gerar(IConfiguration configuration)
        {
            try
            {
                Dictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("grant_type", "client_credentials");
                parametros.Add("scope", "boletos");


                string autorization = Utils.Base64Encode(string.Format("{0}:{1}", configuration["ClientId"].ToString(), configuration["Secret"].ToString()));
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", autorization));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string urlToken = string.Format("{0}/{1}", configuration["UrlBase"], configuration["MethodToken"]);

                    HttpResponseMessage response = client.PostAsync(urlToken, new FormUrlEncodedContent(parametros)).Result;
                    var tokenBanese = response.Content.ReadAsStringAsync().Result;
                    var token = JsonConvert.DeserializeObject<Token>(tokenBanese);

                    return token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
