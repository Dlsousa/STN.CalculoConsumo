using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using STN.CalculoConsumo.Api.Contracts;
using STN.CalculoConsumo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Services
{
    public class ClienteService : IClienteService
    {
        private HttpClient _client = new HttpClient();

        public ClienteService(IConfiguration config)
        {
            // TODO: para os testes não consegue pegar as configurações do appsettings.json
            //_client.BaseAddress = new Uri(config.GetValue<string>("Urls:UrlCliente"));
            _client.BaseAddress = new Uri("http://localhost:51513/");

            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/v1/Cliente");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(dados);
            }

            return new List<Cliente>();
        }
    }
}
