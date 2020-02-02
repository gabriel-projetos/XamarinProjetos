using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using app1_testeDrive.Midia;
using app1_testeDrive.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;
using Java.IO;


//Assembly: Marcado para ser usado como uma dependencia pelo dependencyService
[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace app1_testeDrive.Droid
{
    [Activity(Label = "app1_testeDrive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    //Responsável por rodar o xamarim
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
         , ICamera
    {
        //escopo da classe
        static Java.IO.File arquivoImagem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //É chamado pelo masterViewModel como uma dependencia
        public void TirarFoto()
        {
            //Intenção/ação de abrir camera para capturar imagem
            Intent intent = new Intent(MediaStore.ActionImageCapture);
          
            arquivoImagem = PegarArquivoImagem();

            //Armazenar dados extra 
            //Passando uma inteção com dados extra do tipo ExtraOutput
            //ExtraOutput: Saída de dados é aonde será guardado a captura final da foto
            // :Local aonde será guardado
            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(arquivoImagem));

            //Activity: Atividade
            //Intent:Intenção de executar uma tarefa de outro aplicativo e com quais dados se quer trabalhar
            //Para acionar o activity da camera é preciso acionar atravez de um intent

            //Atravez do contexto do xamarim transformado em activity sabemos qual é a atividade
            //apartir da atividade local é possivel ativar a atividade externa(camera)
            var activity = Forms.Context as Activity;

            //Iniciar uma atividade com o intuito de obeter um resultado
            //(Intent, 'Código de requisição')
            //Usamos o código na volta para saber qual requisição é
            activity.StartActivityForResult(intent, 0);
        }

        private static File PegarArquivoImagem()
        {
            File arquivoImagem;
            //Diretorio aonde vai ficar salvo as imagems
            Java.IO.File diretorio = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "Imagens");

            //Verificar se o diretorio existe
            if (!diretorio.Exists())
            {
                //é criado toda a estrutura de pais das pastas
                diretorio.Mkdirs();
            }

            //diretorio é usado aqui tb para ser a base
            //aonde a imagem Minhafoto.jpg será gravada
            arquivoImagem =
                new Java.IO.File(diretorio, "MinhaFoto.jpg");
            return arquivoImagem;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            //SE TIRAR A FOTO e confirmar 
            if (resultCode == Result.Ok)
            {
                byte[] bytes;

                //Retorna uma stream onde é possivel ler os dados do arquivo
                using (var stream = new Java.IO.FileInputStream(arquivoImagem))
                {
                    //Convertendo a imagem em um array de bytes para usar o array na troca de mensagens com o projeto c#
                    bytes = new byte[arquivoImagem.Length()];

                    //transferir pro array de bytes o conteudo do arquivo de imagem
                    //stream le os dados do arquivo
                    stream.Read(bytes);
                }

                //Arquivo do tipo array de byte[]
                //instancia de arquivoImagem
                //Sobrepoe a imagem original no diretorio
                //envia a msg para a classe masterviewmodel
                MessagingCenter.Send<byte[]>(bytes, "FotoTirada");
            }
        }
    }
}