using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBoletoBanese.Models
{
    public class Pagador
    {
        public string TipoPessoa { get; set; }
        public string NumeroCPFCNPJ { get; set; }
        public string NomeOuRazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Endereco Endereco { get; set; }
    }
}
