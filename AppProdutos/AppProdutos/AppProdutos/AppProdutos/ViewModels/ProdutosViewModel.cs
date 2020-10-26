using AppProdutos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppProdutos.ViewModels
{
    public class ProdutosViewModel
    {
        public ProdutosViewModel()
        {
            Produtos = new ObservableCollection<Produto>() 
            { 
                new Produto { Nome = "Laranja", Estoque = 5, Preco = 10 },
                new Produto { Nome = "Pera", Estoque = 5, Preco = 10 },
                new Produto { Nome = "Uva", Estoque = 5, Preco = 10 },
                new Produto { Nome = "Arroz", Estoque = 5, Preco = 10 },
                new Produto { Nome = "Café", Estoque = 5, Preco = 10 },
            };
        }

        public ObservableCollection<Produto> Produtos { get; set; }

    }
}
