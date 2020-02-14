using System;
using System.Collections.Generic;
using System.Text;

namespace app1_testeDrive.Models
{
    public class Usuario
    {
        //Dados que aparecem a tela MasterView - EDITAR
        public int id { get; set; }
        public string nome { get; set; }
        public string dataNascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }

    public class ResultadoLogin
    {
        public Usuario usuario { get; set; }
    }
}
