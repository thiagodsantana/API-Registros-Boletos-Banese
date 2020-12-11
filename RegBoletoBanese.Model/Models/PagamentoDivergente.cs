using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBoletoBanese.Models
{
    public class PagamentoDivergente
    {
        public string TipoValorMinimoMaximo { get; set; }
        public double ValorMaximo { get; set; }
        public double ValorMinimo { get; set; }
    }
}
