using Microsoft.AspNetCore.Mvc;
using STN.CalculoConsumo.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CalculoConsumoController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ICalculoService _calculoService;
        private readonly ICobrancaService _cobrancaService;

        public CalculoConsumoController(IClienteService clienteService, ICalculoService calculoService, ICobrancaService cobrancaService)
        {
            _clienteService = clienteService;
            _calculoService = calculoService;
            _cobrancaService = cobrancaService;
        }

        [HttpPost]
        public async Task<IActionResult> Calcular()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();

                var cobrancas = _calculoService.CalcularPorClientes(clientes);

                await _cobrancaService.InserirCobrancas(cobrancas);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Problemas ao efetuar calculo: {ex.Message}");
            }
        }
    }
}