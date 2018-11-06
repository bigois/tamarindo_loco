using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePage : ContentPage {
        // DECLARAÇÃO DE CONSTANTES
        private const Double FREIO_ABS = 800.0;
        private const Double AR_CONDICIONADO = 1000.0;
        private const Double MP3_PLAYER = 500.0;

        // MÉTODO FEIO DE FORMTAÇÃO DE TEXTO DO SWITCH FREIO ABS
        public String TextFreioABS {
            get {
                return String.Format("Freio ABS - R$ {0:N}", FREIO_ABS);
            }
        }

        // MÉTODO FEIO DE FORMATAÇÃO DE TEXTO DO SWITCH AR CONDICIONADO
        public String TextArCondicionado {
            get {
                return String.Format("Ar Condicionado - R$ {0:N}", AR_CONDICIONADO);
            }
        }

        public String TextMP3Player {
            get {
                return String.Format("MP3 Player - R$ {0:N}", MP3_PLAYER);
            }
        }

        // PROPRIEDADE GLOBAL PARA FACILITAR O TRANSPORTE
        public Veiculo Veiculo { get; set; }

        public Double valorTotal;
        public Double ValorTotal {
            get { return valorTotal; }
            set { valorTotal = value;  }
        }

        public DetalhePage(Veiculo veiculo) {
            InitializeComponent();

            // ATRÍBUI O VEÍCULO RECEBIDO PARA A VARIÁVEL INTERNA
            Veiculo = veiculo;

            // ALTERA O TÍTULO COM BASE NO NOME DO VEÍCULO
            Title = veiculo.Nome;

            // ATRIBUI O VALOR TOTAL COMO INICIALIZADOR
            valorTotal = Veiculo.Preco + FREIO_ABS + MP3_PLAYER;
            TextTotal.Text = String.Format("Valor Total: R$ {0:N}", ValorTotal);

            // VINCULA O MÉTODO DE CLIQUE COM A AÇÃO DE CLIQUE NO BOTÃO
            ButtonProximo.Clicked += ButtonProximoClicked;

            // DEFINE ESTA CLASSE COMO CONTEXTO DE BINDING
            BindingContext = this;

            // ADICIONA AÇÕES EM CASO DE MUDANÇA DE ESTADO DOS SWITCHES
            SwitchFreio.OnChanged += OnSwitchChanged;
            SwitchMP3.OnChanged += OnSwitchChanged;
            SwitchArCondicionado.OnChanged += OnSwitchChanged;
        }

        // MÉTODO PARA MUDANÇA DE SWITCHES
        private void OnSwitchChanged(Object sender, ToggledEventArgs e) {
            ValorTotal = Veiculo.Preco;

            // VERIFICA SE OS SWITCHES ESTÃO SELECIONADOS,
            // CASO SIM, SOMA OS VALORES
            if (SwitchFreio.On) { ValorTotal += FREIO_ABS; }
            if (SwitchMP3.On) { ValorTotal += MP3_PLAYER; }
            if (SwitchArCondicionado.On) { ValorTotal += AR_CONDICIONADO; }

            TextTotal.Text = String.Format("Valor Total: R$ {0:N}", ValorTotal);
        }

        // AÇÃO DO BOTÃO DE NAVEGAÇÃO PARA A PÁGINA AGENDAMENTO
        private void ButtonProximoClicked(Object sender, EventArgs e) {
            Navigation.PushAsync(new AgendamentoPage(Veiculo, ValorTotal));
        }
    }
}
