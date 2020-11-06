using STN.CalculoConsumo.Api.Contracts;
using STN.CalculoConsumo.Api.Models;
using STN.CalculoConsumo.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace STN.CalculoConsumo.Tests.UnitTests
{
    public class CalculoUnitTest
    {
        private readonly ICalculoService _calculoService = new CalculoService();

        [Fact]
        public void Calculo_Valor_Por_Cpf()
        {
            var cpf = "63955700054";
            var valorEsperado = 6354m;

            var result = _calculoService.CalcularPorCpf(cpf);

            Assert.Equal(valorEsperado, result);
        }

        [Fact]
        public void Calculo_Valor_Por_Clientes()
        {
            var clientes = new List<Cliente>()
            {
                new Cliente()
                {
                    Cpf = "63955700054"
                },
                new Cliente()
                {
                    Cpf = "76784690044"
                }
            };

            var valorEsperado1 = 6354m;
            var valorEsperado2 = 7644m;
            var result = _calculoService.CalcularPorClientes(clientes);

            Assert.Equal(valorEsperado1, result[0].Valor);
            Assert.Equal(valorEsperado2, result[1].Valor);
        }
    }
}
