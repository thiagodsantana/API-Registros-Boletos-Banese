using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBoletoBanese.Models
{
    public class BoletoResponse
    {
        public string NumeroCodigoBarras { get; set; }
        public string NumeroLinhaDigitavel { get; set; }
        public ErrosBoleto Erros { get; set; }
    }
}
