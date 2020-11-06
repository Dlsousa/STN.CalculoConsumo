using STN.CalculoConsumo.Api.Contracts;
using STN.CalculoConsumo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Services
{
    public class CalculoService : ICalculoService
    {
        public List<Cobranca> CalcularPorClientes(List<Cliente> clientes)
        {
            var cobrancas = new List<Cobranca>();
            var vencimento = DateTime.Now.Date;

            clientes.ForEach(c => cobrancas.Add(new Cobranca { DataVencimento = vencimento, Valor = CalcularPorCpf(c.Cpf), Cpf = c.Cpf }));

            return cobrancas;
        }

        public decimal CalcularPorCpf(string cpf)
        {
            string valor = cpf.Substring(0, 2) + cpf.Substring(cpf.Length - 2, 2);
            decimal.TryParse(valor, out decimal valorCalc);
            return valorCalc;
        }
    }
}
