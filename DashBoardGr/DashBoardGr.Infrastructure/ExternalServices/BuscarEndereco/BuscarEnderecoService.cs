using DashBoardGr.Infrastructure.ExternalServices.BuscarCep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure.BuscarCep.ExternalServices
{
    public class BuscarEnderecoService
    {
        private readonly HttpClient _client;

        public BuscarEnderecoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BuscarEnderecoCommandResult?> BuscarEndereco(string cep)
        {
            var result =  await _client.GetFromJsonAsync<BuscarEnderecoCommandResult>($"{_client.BaseAddress}{cep}/json");

            return result;
        }
        
    }
}
