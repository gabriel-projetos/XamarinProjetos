using app1_testeDrive.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace app1_testeDrive.Data
{
    public class AgendamentoDAO
    {
        //Variavel IMUTAVEL somente LEITURA
        //Conexão IMUTAVEL
        readonly SQLiteConnection conexao;

        //Armazenar a lista de agendamentos realizados
        private List<Agendamento> lista;

        public List<Agendamento> Lista
        {
            get
            {
                //vai retornar a lista de agendamentos do banco, acessando a tabela
                return conexao.Table<Agendamento>().ToList();
            }
            private set { lista = value; }
        }


        //Precisa receber a conexão aqui
        //Construtor que vai receber o parametro da conexão criada externamente
        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;

            //Criação da tabela agendamento
            //<Tabela do TIPO Agendamento> só cria se não existir
            //O método ´CreateTable` executa um comando "create table if not exists 
            this.conexao.CreateTable<Agendamento>();
        }

        //Salvar Agendamento
        //1º Param: Mesmo tipo do modelo usado para salvar o banco
        public void Salvar(Agendamento agendamento)
        {
            //Vai bsucar se já existe o agendamento <nome da tabela> (pk)  
            if (conexao.Find<Agendamento>(agendamento.ID) == null)
            {
                //Se não existir um registro com a mesma pk ele insere

                //Implementar o metodo salvar de AgendamentoDAO, para inserir no banco um novo registro
                conexao.Insert(agendamento);
            }
            else
            {
                //se existir ele faz o update
                conexao.Update(agendamento);
            }
        }
    }
}
