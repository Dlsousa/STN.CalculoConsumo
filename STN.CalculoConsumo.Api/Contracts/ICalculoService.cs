using STN.CalculoConsumo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Contracts
{
    public interface ICalculoService
    {
        List<Cobranca> CalcularPorClientes(List<Cliente> clientes);

        decimal CalcularPorCpf(string cpf);
    }
}
