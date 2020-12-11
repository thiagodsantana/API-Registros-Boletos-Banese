using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBoletoBanese.Models
{
    public class BoletoRequest
    {
        public string NossoNumero { get; set; }
        public int CodigoMoeda { get; set; }
        public string DataVencimento { get; set; }
        public double ValorNominal { get; set; }
        public string NumeroDocumento { get; set; }
        public int CodigoEspecie { get; set; }
        public int CodigoTipoBaixaDevolucao { get; set; }
        public int QuantidadeDiasBaixaDevolucao { get; set; }
        public bool IndicadorPagamentoParcial { get; set; }
        public double ValorAbatimento { get; set; }
        public Juros Juros { get; set; }
        public List<Desconto> Desconto { get; set; }
        public Multa Multa { get; set; }
        public int TipoValorAceito { get; set; }
        public PagamentoDivergente PagamentoDivergente { get; set; }
        public bool FlAceite { get; set; }
        public string IdTituloEmpresa { get; set; }
        public Pagador Pagador { get; set; }
        public SacadorAvalista SacadorAvalista { get; set; }
        public string DataEmissao { get; set; }
    }
}
