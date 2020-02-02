using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace app1_testeDrive.Data
{
    public interface ISQLite
    {

        //Interface que será implementa pelo projeto droid e pelo Portable
        //Cada projeto precisa implementa-la de acordo com a plataforma
        //É OBRIGADO QUE QUEM HERDAR A INTERFACE TEM QUE IMPLEMENTAR
        //Retorna a conexão com o banco
        SQLiteConnection PegarConexão();
    }
}
