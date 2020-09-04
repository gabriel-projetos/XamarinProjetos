using App.DataService;
using App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                //this: quem chama é a propria classe
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
        

    public class ListagemViewModel : BaseViewModel
    {
        public ListagemViewModel()
        {
            _dataService = new Services();
            AtualizaDados();            
        }
        
        public ObservableCollection<Produto> Produto
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Produto> _produtos = new ObservableCollection<Produto>();
        Services _dataService;
        async void AtualizaDados()
        {
            //Busca na api
            var produtos = await _dataService.ListarProdutos();

            foreach (var produto in produtos)
            {
                //Armaeza localmente
                await App.Database.SaveNoteAsync(produto);          
            }
            //Pega os dados localmente
            var prod = await App.Database.GetNotesAsync();

            foreach (var produto in prod)
            {
                //Alimenta a tela.
                this._produtos.Add(produto);
            }
            
        }


    }
}
