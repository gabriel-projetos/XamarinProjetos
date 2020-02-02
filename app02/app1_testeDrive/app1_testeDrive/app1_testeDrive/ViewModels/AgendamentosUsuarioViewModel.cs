using app1_testeDrive.Data;
using app1_testeDrive.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        //lista que vai levar para a view os agendamentos agendados
        ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista 
        {
            get
            {
                return lista;
            }
            private set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        private Agendamento agendamentoSelecionado;

        public Agendamento AgendamentoSelecionado
        {
            get { return agendamentoSelecionado; }
            set 
            {
                if(value != null)
                {
                    agendamentoSelecionado = value;

                    //enviando o <Agendamento>, (Instancia do agendamento, msg)
                    MessagingCenter.Send<Agendamento>(agendamentoSelecionado,
                        "AgendamentoSelecionado");
                }
            }
        }


        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            //Busca os dados no banco e monta a lista
            using (
            //Método para pegar uma referencia do ISQLITE
            //<Interface> agora vc tem acesso aos metodos dessa interface
            var conexao = DependencyService.Get<ISQLite>().PegarConexão())
            {
                //Objeto de acesso aos dados
                //criar ou obter uma instancia de uma dependencia de uma determinada interface
                //utiliza a interface ISQLite para obter o objeto que implementa as funções do SQLite
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                //Acessar a lista de AGENDAMENTOS
                var listaDB = dao.Lista;

                //Para ordenar a lista usamos o link que é: 
                //consultas integradas a linguagem .NET
                //vai ordenar pela data depois pela hora
                var query = listaDB
                    .OrderBy(l => l.DataAgendamento)
                    .ThenBy(l => l.HoraAgendamento);

                this.Lista.Clear();
                //para cada ITEM na na query
                foreach (var itemDB in query)
                {
                    this.Lista.Add(itemDB);
                }
            }
        }
    }
}
