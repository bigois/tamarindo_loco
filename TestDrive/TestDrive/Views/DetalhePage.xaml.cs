using System;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePage : ContentPage {
        // PROPRIEDADE GLOBAL PARA FACILITAR O TRANSPORTE
        public Veiculo Veiculo { get; set; }

        // MÉTODO FEIO DE FORMTAÇÃO DE TEXTO DO SWITCH FREIO ABS
        public String TextFreioABS {
            get {
                return String.Format("Freio ABS - R$ {0:N}", Veiculo.FREIO_ABS);
            }
        }

        // MÉTODO FEIO DE FORMATAÇÃO DE TEXTO DO SWITCH AR CONDICIONADO
        public String TextArCondicionado {
            get {
                return String.Format("Ar Condicionado - R$ {0:N}", Veiculo.AR_CONDICIONADO);
            }
        }

        public String TextMP3Player {
            get {
                return String.Format("MP3 Player - R$ {0:N}", Veiculo.MP3_PLAYER);
            }
        }

        public DetalhePage(Veiculo veiculo) {
            InitializeComponent();

            // ATRÍBUI O VEÍCULO RECEBIDO PARA A VARIÁVEL INTERNA
            Veiculo = veiculo;

            // ALTERA O TÍTULO COM BASE NO NOME DO VEÍCULO
            Title = veiculo.Nome;

            // ATRIBUI O VALOR TOTAL COMO INICIALIZADOR
            TextTotal.Text = String.Format("Valor Total: R$ {0:N}", Veiculo.ValorTotal);

            // VINCULA O MÉTODO DE CLIQUE COM A AÇÃO DE CLIQUE NO BOTÃO
            ButtonProximo.Clicked += ButtonProximoClicked;

            // DEFINE ESTA CLASSE COMO CONTEXTO DE BINDING
            BindingContext = this;

            // ADICIONA AÇÕES EM CASO DE MUDANÇA DE ESTADO DOS SWITCHES
            SwitchFreio.OnChanged += OnSwitchChanged;
            SwitchMP3.OnChanged += OnSwitchChanged;
            SwitchArCondicionado.OnChanged += OnSwitchChanged;
        }

        // MELHOR JEITO QUE ENCONTREI PARA RESOLVER O PROBLEMA
        private void OnSwitchChanged(object sender, ToggledEventArgs e) {
            Veiculo.CalculaValorTotal(SwitchFreio, SwitchMP3, SwitchArCondicionado, TextTotal);
        }

        // AÇÃO DO BOTÃO DE NAVEGAÇÃO PARA A PÁGINA AGENDAMENTO
        private void ButtonProximoClicked(Object sender, EventArgs e) {
            Navigation.PushAsync(new AgendamentoPage(Veiculo, Veiculo.ValorTotal));
        }
    }
}
