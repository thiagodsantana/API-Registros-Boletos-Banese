using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBoletoBanese.Models
{
    public class ErrosBoleto
    {
        public List<Erro> Erros { get; set; }
        public string LogId { get; set; }
    }
}
