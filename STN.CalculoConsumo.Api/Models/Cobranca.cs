using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Models
{
    public class Cobranca
    {
        public string Id { get; set; }

        public DateTime DataVencimento { get; set; }

        public decimal Valor { get; set; }

        public string Cpf { get; set; }
    }
}
