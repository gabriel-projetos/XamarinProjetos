using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using app1_testeDrive.Data;
using app1_testeDrive.Droid;
using SQLite;

//Assembly: Marcado para ser usado como uma dependencia pelo dependencyService
[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace app1_testeDrive.Droid
{
    class SQLite_android : ISQLite
    {
        private const string nomeArquivoDB = "Agendamento.db3";

        public SQLiteConnection PegarConexão()
        {
            //Concatenar o DIRETORIO com o NOME do ARQUIVO
            //1º Param: Caminho do SD
            //2º Param: Nome do Banco
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path,
                nomeArquivoDB);

            //Conexão que vem da variavel de cima CAMINHO+NOME DO BANCO
            return new SQLite.SQLiteConnection(caminhoDB);
        }
    }
}