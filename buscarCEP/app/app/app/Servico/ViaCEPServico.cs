using app.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";
        HttpClient client = new HttpClient();

        //static ou métodos da classe são funções que não dependem de nenhuma variável de instância
        public async Task<Endereco> BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            var response = await client.GetStringAsync(NovoEnderecoURL);

            //Caso traga uma instancia de endereço mas com as propriedades correspondendo json nulas
            Endereco end = JsonConvert.DeserializeObject<Endereco>(response);

            if (end.cep == null) return null;

            return end;

        }
    }
}
