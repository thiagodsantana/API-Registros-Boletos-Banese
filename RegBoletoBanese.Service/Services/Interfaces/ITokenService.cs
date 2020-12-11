using Microsoft.Extensions.Configuration;
using RegBoletoBanese.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegBoletoBanese.Service.Services.Interfaces
{
    public interface ITokenService
    {
        Token Gerar(IConfiguration configuration);
    }
}
