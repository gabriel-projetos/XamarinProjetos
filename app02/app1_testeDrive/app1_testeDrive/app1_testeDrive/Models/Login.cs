using System;
using System.Collections.Generic;
using System.Text;

namespace app1_testeDrive.Models
{
    public class Login
    {
        public string email { get; private set; }
        public string senha { get; private set; }

        //Construtor
        public Login(string email, string senha)
        {
            //os dois vao receber os parametros que virem do construtor
            //parameros estao vindo de LoginViewModel
            this.email = email;
            this.senha = senha;
        }
    }
}
