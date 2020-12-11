using Microsoft.Extensions.Configuration;
using RegBoletoBanese.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RegBoletoBanese.Service.Services.Interfaces
{
    public interface IBoletoService
    {
        Task<BoletoResponse> Gerar(IConfiguration configuration, string token, BoletoRequest boleto, string convenio);
    }
}
