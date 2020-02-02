using app1_testeDrive.Data;
using app1_testeDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app1_testeDrive.Services
{
    class AgendamentoService
    {
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";

        //Passando uma instancia de agendamento como parametro
        public async Task EnviarAgendamento(Agendamento agendamento)
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                agendamento.DataAgendamento.Year, agendamento.DataAgendamento.Month, agendamento.DataAgendamento.Day,
                agendamento.HoraAgendamento.Hours, agendamento.HoraAgendamento.Minutes,
                agendamento.HoraAgendamento.Seconds
                );

            //Json a partir dos objetos.
            var Json = JsonConvert.SerializeObject(new
            {
                nome = agendamento.Nome,
                fone = agendamento.Fone,
                email = agendamento.Email,
                carro = agendamento.Modelo,
                preco = agendamento.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(Json, Encoding.UTF8, "application/json");

            //Aguardar o resultado vindo do await para continuar a execução
            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

            //recebe se o agendamento foi um sucesso ou falha.
            agendamento.Confirmado = resposta.IsSuccessStatusCode;
            SalvarAgendamentoDB(agendamento);

            //Se a requisição foi bem sucessida
            if (agendamento.Confirmado)
                //this.agendamento(guarda os dados do agendamento)
                MessagingCenter.Send<Agendamento>(agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
        }

        private void SalvarAgendamentoDB(Agendamento agendamento)
        {
            /*           ------------- CONEXÃO COM O BANCO -----------
            * Pegar uma referencia ja existente ou nova de uma instancia de um OBJETO  
            * que está implementando a interface no caso ISQLite 
            * 1º Param: < Tipo que está pegando, uma instancia que implementa ISQLite >
            * 2º Param: Qual o metodo que deseja obter dessa instancia para ter acessso
            * Dentro de um using para a conexão ser aberta e fechada
            */
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexão())
            {
                //Bloco que vai utilizar a conexão
                AgendamentoDAO dao = new AgendamentoDAO(conexao);

                //Nova instancia do Agendamento com os parametros de Agendamento.cs
                //Com os dados que queremos salvar no banco de dados
                //Parametros que vem do construtor 
                dao.Salvar(agendamento);
            }
        }
    }
}
