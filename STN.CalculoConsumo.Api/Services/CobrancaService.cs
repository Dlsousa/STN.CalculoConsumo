using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using STN.CalculoConsumo.Api.Contracts;
using STN.CalculoConsumo.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STN.CalculoConsumo.Api.Services
{
    public class CobrancaService : ICobrancaService
    {
        private readonly IConfiguration _config;

        public CobrancaService(IConfiguration config)
        {
            _config = config;
        }

        public async Task InserirCobrancas(List<Cobranca> cobrancas)
        {
            using (var client = new HttpClient())
            {
                foreach (Cobranca cobranca in cobrancas)
                {
                    var serializedCob = JsonConvert.SerializeObject(cobranca);
                    var content = new StringContent(serializedCob, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("http://localhost:51515/api/v1/Cobranca", content);

                    // TODO: para os testes não consegue pegar as configurações do appsettings.json
                    //var result = await client.PostAsync(_config.GetValue<string>("Urls:UrlCobranca"), content);
                }
            }
        }
    }
}
