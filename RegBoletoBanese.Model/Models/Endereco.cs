using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBoletoBanese.Models
{
    public class Endereco
    {
        public string DescricaoEndereco { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UnidadeFederativa { get; set; }
    }
}
