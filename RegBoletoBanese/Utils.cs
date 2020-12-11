using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegBoletoBanese
{
    public static class Utils
    {
        #region Métodos Auxiliares

        #region Encode 64
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        #endregion

        #region Decode 64
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        #endregion

        #region Fator Vencimento
        public static string CalculaFatorVencimento(DateTime DataDesejada)
        {
            string sFatorVencto;
            TimeSpan lTimeSpan = DataDesejada.Subtract(new DateTime(1997, 10, 7));
            sFatorVencto = lTimeSpan.Days.ToString();
            sFatorVencto = sFatorVencto.PadLeft(4, '0');
            if (sFatorVencto.StartsWith("0")) return "0000";
            else return sFatorVencto;
        }
        #endregion

        #region Modulo 10
        public static string Modulo10(string Valor)
        {
            int nSoma = 0, nMult = 2, nIndice, nProd;

            for (nIndice = Valor.Length - 1; nIndice >= 0; nIndice--)
            {
                nProd = (Convert.ToByte(Valor[nIndice]) - 48) * nMult;

                if (nProd > 9) nSoma += nProd - 9;
                else nSoma += nProd;

                if (nMult == 2) nMult = 1;
                else nMult = 2;
            }

            nSoma = nSoma % 10;
            if (nSoma > 0) nSoma = 10 - nSoma;
            return nSoma.ToString();
        }
        #endregion

        #region * Início do Módulo 11
        /// <summary>
        ///Esse é o Modulo 11 responsável pelo Nosso Número 
        /// </summary>
        /// <param name="Valor">Valor a ser inserido para retorno do DV</param>
        /// <param name="Base">Base que pode variar de 2 a 9 </param>
        /// <returns></returns>
        private static string Modulo11(string Valor, int Base, bool Resto)
        {
            int Contador, Peso, Digito, Soma;
            Soma = 0;
            Peso = 2;
            string retorno = string.Empty;

            for (Contador = Valor.Length - 1; Contador >= 0; Contador--)
            {
                Soma = Soma + (int.Parse(Valor[Contador].ToString()) * Peso);
                if (Peso < Base)
                {
                    Peso = Peso + 1;
                }
                else
                {
                    Peso = 2;
                }
            }
            if (Resto)
                retorno = (Soma % 11).ToString();
            else
            {
                Digito = 11 - (Soma % 11);
                if (Digito > 9)
                    Digito = 0;
                retorno = Digito.ToString();
            }
            return retorno;
        }
        #endregion ( Fim do Módulo 11 )

        #region Modulo 11 Linha
        public static string Modulo11Linha(string Valor, int Base, bool Resto)
        {
            int Soma, Rest, Contador, Peso, Digito;
            Soma = 0;
            Peso = 2;
            string retorno = string.Empty;

            for (Contador = Valor.Length - 1; Contador >= 0; Contador--)
            {
                Soma = Soma + (int.Parse(Valor[Contador].ToString()) * Peso);
                if (Peso < Base)
                    Peso = Peso + 1;
                else
                    Peso = 2;
            }

            if (Resto)
            {
                Rest = (Soma % 11);
                if (Rest >= 2)
                {
                    retorno = (11 - Rest).ToString();
                }
                else
                {
                    retorno = "1";
                }
            }
            return retorno;
        }

        #endregion

        #region Nosso Numero
        public static string NossoNumero(string Numero)
        {
            string NossoNumeros = "";

            int total = 9;

            int total2 = 8;
            int tamanhoValor3 = Numero.ToString().Length;
            string valorConcat3 = Numero.ToString();
            for (int i = 0; i < (total2 - tamanhoValor3); i++)
            {
                valorConcat3 = "0" + valorConcat3;
            }
            Numero = valorConcat3;


            string NumNumero, Digito, NumFormato;
            NumNumero = "058" + Numero;
            Digito = Modulo11(NumNumero, 9, false);
            NossoNumeros = Numero + Digito;
            //adiciona zeros. com o digito, deve ter 9 caracteres.
            int tamanhoValor = NossoNumeros.Length;
            string valorConcat = NossoNumeros.ToString();
            for (int i = 0; i < (total - tamanhoValor); i++)
            {
                valorConcat = "0" + valorConcat;
            }
            NossoNumeros = valorConcat;
            //formata e adiciona os zeros
            NumFormato = Numero + "" + Digito;
            return NumFormato;
        }
        #endregion

        #region Add Zeros
        public static string addZeros(double Valor)
        {
            int total = 10;
            Valor = Valor * 100;
            int tamanhoValor = Valor.ToString().Length;
            string valorConcat = Valor.ToString();

            for (int i = 0; i < (total - tamanhoValor); i++)
            {
                valorConcat = "0" + valorConcat;
            }
            return valorConcat;
        }
        #endregion

        #endregion
    }
}
