using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyControl : ContentView
    {
        //classe responsavel pela criação de todos os eventos
        //Evento usado no xaml
        public event EventHandler Tapped;
         

        #region Titulo
        /************tITULO **************/
        //Propriedade que podemos criar vinculos
        //A propria classe cria uma BindableProperty
        public static readonly BindableProperty TituloProperty = BindableProperty.Create(
                //Qual propriedade vai armanezar o dado se refere a propriedade que vai armazenar o valor
                propertyName: "Titulo",
                
                //Tipo de retorno, se é string, int etc
                returnType: typeof(string),

                //Nome da classe/objeto que recebera essa propriedade
                declaringType: typeof(MyControl),

                //Valor padrão, como é um texto é vazio
                defaultValue: "",

                //Propriedade do tipo binding tem os valores
                //TwoWay: vai se refletir em qualquer lugar, da view pra viewmodel e viewlModel para view
                defaultBindingMode: BindingMode.TwoWay,

                //Qual metodo vai tratar essas alterações, quando a proprieadde for alterada é chamado esse metodo
                propertyChanged: TituloPropertyChanged
            );

        private static void TituloPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //Quando a propriedade for alterada
            //bindable é a classe myControl
            var myControl = (MyControl)bindable;

            //acessando as propriedades do xaml
            myControl.titulo.Text = newValue.ToString();
        }

        //Devemos fazer referencia ao Bindable
        public string Titulo 
        { 
            get
            {
                //Para pegar precisamos usar o GetValue
                return (string)GetValue(TituloProperty);
            }
            set
            {
                SetValue(TituloProperty, value);
            }
        }
        #endregion

        #region TituloCor
        //Propriedade que podemos criar vinculos
        //A propria classe cria uma BindableProperty
        public static readonly BindableProperty TituloCorProperty = BindableProperty.Create(
                //Qual propriedade vai armanezar o dado se refere a propriedade que vai armazenar o valor
                propertyName: "TituloCor",

                //Tipo de retorno, se é string, int etc
                returnType: typeof(Color),

                //Nome da classe/objeto que recebera essa propriedade
                declaringType: typeof(MyControl),

                //Valor padrão, como é um texto é vazio
                defaultValue: Color.Black,

                //Propriedade do tipo binding tem os valores
                //TwoWay: vai se refletir em qualquer lugar, da view pra viewmodel e viewlModel para view
                defaultBindingMode: BindingMode.TwoWay,

                //Qual metodo vai tratar essas alterações
                propertyChanged: TituloCorPropertyChanged
            );

        private static void TituloCorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //Quando a propriedade for alterada
            //bindable é a classe myControl
            var myControl = (MyControl)bindable;

            //acessando as propriedades do xaml
            myControl.titulo.TextColor = (Color)newValue;
        }

        //Devemos fazer referencia ao Bindable
        public Color TituloCor
        {
            get
            {
                //Para pegar precisamos usar o GetValue
                return (Color)GetValue(TituloCorProperty);
            }
            set
            {
                SetValue(TituloCorProperty, value);
            }
        }
        #endregion

        #region Imagem
        //Propriedade que podemos criar vinculos
        //A propria classe cria uma BindableProperty
        public static readonly BindableProperty ImagemProperty = BindableProperty.Create(
                //Qual propriedade vai armanezar o dado se refere a propriedade que vai armazenar o valor
                propertyName: "Imagem",

                //Tipo de retorno, se é string, int etc
                returnType: typeof(string),

                //Nome da classe/objeto que recebera essa propriedade
                declaringType: typeof(MyControl),

                //Valor padrão, como é um texto é vazio
                defaultValue: "",

                //Propriedade do tipo binding tem os valores
                //TwoWay: vai se refletir em qualquer lugar, da view pra viewmodel e viewlModel para view
                defaultBindingMode: BindingMode.TwoWay,

                //Qual metodo vai tratar essas alterações
                propertyChanged: ImagerSourcePropertyChanged
            );

        private static void ImagerSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //Quando a propriedade for alterada
            //bindable é a classe myControl
            var myControl = (MyControl)bindable;

            //acessando as propriedades do xaml
            //Vai buscar o valor dentro de drawlable
            myControl.imagem.Source = ImageSource.FromFile( (string)newValue);
        }

        //Devemos fazer referencia ao Bindable
        public string Imagem
        {
            get
            {
                //Para pegar precisamos usar o GetValue
                return (string)GetValue(ImagemProperty);
            }
            set
            {
                SetValue(ImagemProperty, value);
            }
        }
        #endregion
        public MyControl()
        {
            InitializeComponent();
        }

        //Quando clicar no stack
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Acionar os ventos vinculados ao Tapped

            //Se existe alguem informação vinculada ao evento
            if(Tapped != null)
            {
                Tapped(sender, e);
            }
        }
    }
}