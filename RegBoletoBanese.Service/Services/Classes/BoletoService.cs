using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RegBoletoBanese.Models;
using RegBoletoBanese.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RegBoletoBanese.Service.Services.Classes
{
    public class BoletoService : IBoletoService
    {
        async Task<BoletoResponse> IBoletoService.Gerar(IConfiguration configuration, string token, BoletoRequest boleto, string convenio)
        {
            try
            {
                CalcularNossoNumero(boleto);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonContent = JsonConvert.SerializeObject(boleto);
                    var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string urlGerarBoleto = string.Format("{0}/{1}", configuration["UrlBase"], string.Format(configuration["MethodGerarBoleto"], convenio));

                    HttpResponseMessage response = await client.PostAsync(urlGerarBoleto, contentString);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var dados = response.Content.ReadAsStringAsync().Result;
                        var boletoReg = JsonConvert.DeserializeObject<BoletoResponse>(dados);
                        return boletoReg;
                    }
                    else
                    {

                        var erros = response.Content.ReadAsStringAsync().Result;
                        var errosBoleto = JsonConvert.DeserializeObject<ErrosBoleto>(erros);

                        return new BoletoResponse
                        {
                            Erros = errosBoleto,
                            NumeroCodigoBarras = "",
                            NumeroLinhaDigitavel = ""
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CalcularNossoNumero(BoletoRequest boleto)
        {
            boleto.NossoNumero = Utils.CalcularNossoNumero(boleto.NossoNumero);
        }
    }
}
