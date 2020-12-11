using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RegBoletoBanese.Models;
using RegBoletoBanese.Service.Services.Interfaces;

namespace RegBoletoBanese.Controllers
{
    [ApiVersion("1.0")]
    [Route("BoletoBanese")]
    [ApiController]
    public class RegistrarController : Controller
    {
        //public const string CLIENT_ID = "fa6d200d-c96f-421e-bc09-6856c2442be5";
        //public const string SECRET = "c19405ef-2c38-4246-bfd2-8d4b988f2b1d";
        //public const string URL_TOKEN = "https://sandbox.banese.b.br/autenticacao/oauth/v1/token";
        //public const string URL_GERAR_BOLETO = "https://sandbox.banese.b.br/cobranca/v1/convenios/13106/boletos";

        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IBoletoService _boletoService;

        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public RegistrarController(IConfiguration configuration, ITokenService tokenService, IBoletoService boletoService)
        #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _boletoService = boletoService;
        }


        // POST Gerar/{convenio}
        /// <summary>
        /// Efetua a geração/registro do boleto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Todo
        ///     {
        ///         "nossoNumero": "8989",
        ///         "codigoMoeda": 9,
        ///         "dataVencimento": "2020-12-20",
        ///         "valorNominal": 100,
        ///         "numeroDocumento": "TESTE-001",
        ///         "codigoEspecie": 4,
        ///         "codigoTipoBaixaDevolucao": 1,
        ///         "quantidadeDiasBaixaDevolucao": 1,
        ///         "indicadorPagamentoParcial": false,
        ///         "valorAbatimento": 0,
        ///         "juros": {
        ///             "data": "2020-12-21",
        ///             "valor": 1.99,
        ///             "tipoJuroMora": 1
        ///         },
        ///         "multa": {
        ///             "data": "2020-12-21",
        ///             "valor": 1.00,
        ///             "tipoMulta": 2
        ///         },
        ///         "tipoValorAceito": 3,
        ///         "flAceite": true,
        ///         "idTituloEmpresa": "TESTE-001",
        ///         "pagador": {
        ///             "tipoPessoa": "F",
        ///             "numeroCPFCNPJ": "83829954034",
        ///             "nomeOuRazaoSocial": "THIAGO DARLEI SANTANA SOUZA",
        ///             "nomeFantasia": "THIAGO DARLEI SANTANA SOUZA",
        ///             "endereco": {
        ///                 "descricaoEndereco": "RUA JOÃO GÊNITON DA COSTA",
        ///                 "cep": "49095796",
        ///                 "bairro": "JABOTIANA",
        ///                 "cidade": "ARACAJU",
        ///                 "unidadeFederativa": "SE"
        ///             }
        ///         },
        ///         "dataEmissao": "2020-12-10"
        ///     }
        ///
        /// </remarks>
        /// <param name="BoletoRequest"></param>
        /// <returns>Um boleto registrado</returns>
        /// <response code="200">Retorna o código de barras e a linha digitável do boleto registrado.</response>
        /// <response code="400">Se o boleto não foi registrado é retornado os possíveis erros.</response>   
        [HttpPost("Gerar/{convenio}")]
        [ProducesResponseType(typeof(BoletoResponse), 200)]
        [ProducesResponseType(typeof(ErrosBoleto), 404)]
        [MapToApiVersion("1.0")]
        public IActionResult Gerar(string convenio, [FromBody][Required]BoletoRequest boleto)
        {            
            var token = _tokenService.Gerar(_configuration);
            if (token != null)
            {
                var boletoReg = _boletoService.Gerar(_configuration, token.access_token, boleto, convenio);
                if (boletoReg.Result.Erros != null)
                    return BadRequest(boletoReg.Result.Erros);
                return Ok(boletoReg.Result);
            }
            return BadRequest();
        }
        
    }
}