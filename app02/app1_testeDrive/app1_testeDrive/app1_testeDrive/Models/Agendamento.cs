using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace app1_testeDrive.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public bool Confirmado { get; set; }
        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento { get; set; }

        public string DataFormatada 
        { 
            get
            {
                //Retornar uma string com data e hora formatada
                return DataAgendamento.Add(HoraAgendamento)
                    .ToString("dd/MM/yyyy HH:mm");
            } 
        }

        public Agendamento()
        {

        }

        //Construtor que vai receber os parametros para fazer o preenchimendo dos dados
        public Agendamento(string nome, string fone, string email, string modelo, decimal preco, DateTime dataAgendamento, TimeSpan horaAgendamento)
            : this (nome, fone, email, modelo, preco)
        {
            
            this.DataAgendamento = dataAgendamento;
            this.HoraAgendamento = horaAgendamento;
        }

        //Sobrecarga do construtor
        public Agendamento(string nome, string fone, string email, string modelo, decimal preco)
        {
            //Setar os valores da instancia
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }

        public Agendamento(string nome, string fone, string email, string modelo, decimal preco, DateTime dataAgendamento, TimeSpan horaAgendamento, bool confirmado)
            : this(nome, fone, email, modelo, preco, dataAgendamento, horaAgendamento)
        {
            this.Confirmado = confirmado;
        }
    }
}
