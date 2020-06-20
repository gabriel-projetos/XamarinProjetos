using App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class CalendarioMesViewModel : BaseViewModel
    {
        //Propriedade statica para usar no avançar o mes, ano dia etc e retrocedelos. 
        static DateTime CurrentMes { get; set; } = DateTime.Now;

        private string textoMes;
        public string TextoMes
        {
            get { return textoMes; }
            set
            {
                textoMes = value;
                OnPropertyChanged(nameof(TextoMes));
            }
        }


        public ICommand TapRetroceder { get; set; }
        public ICommand TapAvancar { get; set; }
        public ICommand novoEventoCommand { get; set; }
        //public ICommand ScrollCommand { get; set; }



        //Propriedade para termos acesso ao metodos da view
        Page parent;

        ObservableCollection<CellModel> _dias = new ObservableCollection<CellModel>();
        public ObservableCollection<CellModel> CalendarioGridModel
        {
            get
            {
                return _dias;
            }
            set
            {
                _dias = value;
                OnPropertyChanged("Dias");
            }
        }      

        public CalendarioMesViewModel()
        {
            //MontaCalendarioGeral(dataH);
        }

        //List<Calendario> calendario;

        //private void MontaCalendarioGeral(DateTime dataConsulta)
        //{
        //    if (calendario == null)
        //    {
        //        calendario = new List<Calendario>();
        //    }

        //    var valor1 = calendario.Where(y => y.data == dataConsulta).ToList();
        //    if (valor1 != null || valor1.Count > 0)
        //    {
        //        return;
        //    }

        //    DateTime dataT;
        //    for (int i = 1; i <= 31; i++)
        //    {
        //        switch (dataConsulta.Month)
        //        {
        //            case 02:
        //                {
        //                    if (i > 28) break;
        //                }
        //                break;
        //            case 04:
        //            case 06:
        //            case 08:
        //            case 09:
        //            case 11:
        //                {
        //                    if (i > 30) break;
        //                }
        //                break;
        //        }
        //        dataT = new DateTime(i, dataConsulta.Month, dataConsulta.Year, dataConsulta.Hour, dataConsulta.Minute, 0);
        //        calendario.Add(new Calendario { data = dataT });
        //    }
        //}


        private int[] montaCalendario(int mes)
        {
            int cboMes = mes;
            int Dayz = DateTime.DaysInMonth(CurrentMes.Year, mes);

            int[] num = new int[Dayz];
            for (int i = 0; i < Dayz; i++)
            {

                num[i] = i + 1;
            }
            return num;
        }



        

        Days DiaSemanaComecaMes(int mes)
        {
            var teste = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            //Dia da semana que começa o mes
            DateTime time = new DateTime(CurrentMes.Year, mes, 1, System.Globalization.CultureInfo.CurrentCulture.Calendar);
            //péga o dia de inicio da semana para data informada
            return (Days)System.Globalization.CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(time);

        }

        Days verificadia(int coluna)
        {
            switch (coluna)
            {
                case 0:
                    return Days.Domingo;
                case 1:
                    return Days.Segunda;
                case 2:
                    return Days.Terca;
                case 3:
                    return Days.Quarta;
                case 4:
                    return Days.Quinta;
                case 5:
                    return Days.Sexta;
                case 6:
                    return Days.Sabado;
                default:
                    return default;
            }
        }


        public CalendarioMesViewModel(Page page, int mes) : this()
        {

            montaGrid(page, mes);
            TapAvancar = new Command(() =>
            {
                CurrentMes = CurrentMes.AddMonths(1);
                montaGrid(page, CurrentMes.Month);
            });

            TapRetroceder = new Command(() =>
            {
                CurrentMes = CurrentMes.AddMonths(-1);
                montaGrid(page, CurrentMes.Month);
            });

            //Command do scroll
            //ScrollCommand = new Command(async () =>
            //{

            //    //parent.DisplayAlert("OK", "OK", "OK");
            //    MessagingCenter.Send<CalendarioMesViewModel>(this, "ScrollCalendar");

            //});

        }

        void montaGrid(Page page, int mes)
        {
            var Meses = CurrentMes.AddMonths(-1);
            var mesAnterior = montaCalendario(Convert.ToInt32(Meses.Month)).Length;
            //MainPage para usar elementos do xaml sem usar Mensageria
            parent = page;
            //monta o vetor com quantos dias tem no mes.
            var a = montaCalendario(mes);
            //exibe o nome completo do mes atual
            var nomeMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(mes));
            TextoMes = nomeMes + " " + CurrentMes.Year;
            CalendarioGridModel.Clear();
            //Pega o dia da semana que começa o mes
            Days diaCOmecaMes = DiaSemanaComecaMes(mes);
            int b = 1;
            int i = 0, contCasasMesAnterior = 0, colunaMesAnterior = 0, controlador = 0;
            for (int linhas = 0; linhas < 6; linhas++)
            {
                for (int colunas = 0; colunas < 7; colunas++)
                {
                    if (i < a.Length)
                    {
                        CellModel dia = new CellModel()
                        {
                            Coluna = colunas,
                            Linha = linhas,
                            Dia = new DateTime(CurrentMes.Year, CurrentMes.Month, a[i]),
                            dados = new DadosDia()
                            {
                                DiaValor = a[i].ToString(),
                                DiaDaSemana = verificadia(colunas)
                            },
                            BackgroundColor = Color.DeepSkyBlue,
                            TextColor = Color.White
                        };
                        //nomeMes + " " + CurrentMes.Year
                        dia.TapCommand = new Command(() => { TextoMes = nomeMes + " " + CurrentMes.Year; });
                        //Monta a primeira linha do grid
                        if (linhas == 0)
                        {
                            //Verifica se o dia 1 é igual ao dia que começa o mes
                            //Coluna 1 = Segunda, diaCOmecaMes se for terça é = 2 então ñ entrara na condição
                            if (dia.dados.DiaDaSemana >= diaCOmecaMes)
                            {
                                //Tirando sabado e domingo
                                if (dia.dados.DiaDaSemana != Days.Domingo && dia.dados.DiaDaSemana != Days.Sabado)
                                {
                                    CalendarioGridModel.Add(dia);
                                    i++;
                                }
                                else
                                {
                                    //Sabado e domingo
                                    CalendarioGridModel.Add(new CellModel()
                                    {
                                        Coluna = colunas,
                                        Linha = linhas,
                                        Dia = new DateTime(CurrentMes.Year, CurrentMes.Month, CurrentMes.Day)
                                        {

                                        },
                                        dados = new DadosDia()
                                        {
                                            DiaValor = a[i].ToString()
                                        },
                                        BackgroundColor = Color.White,
                                        TextColor = Color.Black,
                                        TapCommand = new Command(() => { TextoMes = nomeMes + " " + CurrentMes.Year; })
                                    });
                                    i++;
                                }
                            }
                            else
                            {
                                /******* MES ANTERIOR *****/
                                contCasasMesAnterior += 1;
                                colunaMesAnterior += 1;
                                controlador += 1;

                            }
                            if (linhas == 0 && dia.dados.DiaDaSemana >= diaCOmecaMes && controlador != 0)
                            {
                                var teste = contCasasMesAnterior;
                                /*Primeira Linha mes anterior */
                                for (int casasEmBranco = 0; casasEmBranco < teste; casasEmBranco++)
                                {
                                    CalendarioGridModel.Add(new CellModel()
                                    {
                                        Coluna = (teste - 1) - casasEmBranco,
                                        Linha = 0,
                                        Dia = new DateTime(CurrentMes.Year, CurrentMes.Month, CurrentMes.Day),
                                        dados = new DadosDia()
                                        {
                                            DiaValor = mesAnterior.ToString()
                                        },
                                        BackgroundColor = Color.White,
                                        TextColor = Color.Gray,
                                        TapCommand = new Command(() =>
                                        {
                                            TextoMes = nomeMes + " " + CurrentMes.Year;
                                            CurrentMes = CurrentMes.AddMonths(-1);
                                            montaGrid(page, CurrentMes.Month);
                                        })
                                    });
                                    colunaMesAnterior--;
                                    mesAnterior--;
                                    controlador--;
                                }
                            }
                        }
                        else
                        {
                            /**Talvez precisa tirar a lógica de sabado e domingo porque a cor da celular é de acordo se o médico tem plantão ou não
                             *BackGround Azul é escala e Amarelo é plantão */
                            //Restante do calendario apos a primeira linha do grid.
                            if (dia.dados.DiaDaSemana != Days.Domingo && dia.dados.DiaDaSemana != Days.Sabado)
                            {
                                //Dias tirando sabado e domingo 
                                CalendarioGridModel.Add(dia);
                                i++;
                            }
                            else
                            {
                                //Sabado e domingo 
                                CalendarioGridModel.Add(new CellModel()
                                {
                                    Coluna = colunas,
                                    Linha = linhas,
                                    Dia = new DateTime(CurrentMes.Year, CurrentMes.Month, CurrentMes.Day)
                                    {

                                    },
                                    dados = new DadosDia()
                                    {
                                        DiaValor = a[i].ToString()
                                    },
                                    BackgroundColor = Color.White,
                                    TextColor = Color.Black,
                                    TapCommand = new Command(() => { TextoMes = nomeMes + " " + CurrentMes.Year; })
                                });
                                i++;
                            }
                        }

                    }
                    else
                    {

                        /********** MES SEGUINTE **********/
                        CellModel dia = new CellModel()
                        {
                            Coluna = colunas,
                            Linha = linhas,
                            Dia = new DateTime(CurrentMes.Year, CurrentMes.Month, CurrentMes.Day),
                            dados = new DadosDia()
                            {
                                DiaValor = b.ToString(),
                                DiaDaSemana = verificadia(colunas)
                            },
                            TextColor = Color.Gray
                        };


                        dia.TapCommand = new Command(async () =>
                        {
                            CurrentMes = CurrentMes.AddMonths(1);
                            TextoMes = nomeMes + " " + CurrentMes.Year;
                            montaGrid(page, CurrentMes.Month);
                            //dia.dados.DiaValor.ToString() + "/" + CurrentMes.Month.ToString() + "/" + CurrentMes.Year.ToString();
                        });
                        CalendarioGridModel.Add(dia);
                        b++;



                    }
                }
            }
        }
    }
}