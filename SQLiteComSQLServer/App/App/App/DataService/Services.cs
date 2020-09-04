using App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.DataService
{
    public class Services
    {
        const string URL_GET_PRODUTOS = "http://192.168.15.8:5000/api/produtos";
        public async Task<List<Produto>> ListarProdutos()
        {

            HttpClient client = new HttpClient();
            var resultado = await client.GetStringAsync(URL_GET_PRODUTOS);
            var produtos = JsonConvert.DeserializeObject<List<Produto>>(resultado);
            return produtos;
            //Produtos = new ObservableCollection<Produto>();
            //this.Produtos = new ObservableCollection<Produto>()
            //{
            //    new Produto{ Nome = "Gab", Preco = 50, Estoque = 3, Descricao = "Opa"}
            //};
            //foreach (var produto in produtos)
            //{
            //    Produtos.Add(new Produto { Nome = produto.Nome, Descricao = produto.Descricao, Estoque = produto.Estoque, Preco = produto.Preco });
            //}
        }
    }
}
