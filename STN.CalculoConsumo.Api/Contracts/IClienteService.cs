using STN.CalculoConsumo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Contracts
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllAsync();
    }
}
