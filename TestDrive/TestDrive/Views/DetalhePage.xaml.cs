using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePage : ContentPage {
        // PROPRIEDADE GLOBAL PARA FACILITAR O TRANSPORTE
        public Veiculo Veiculo { get; set; }

        public DetalhePage(Veiculo veiculo) {
            InitializeComponent();

            // ATRÍBUI O VEÍCULO RECEBIDO PARA A VARIÁVEL INTERNA
            Veiculo = veiculo;

            // ALTERA O TÍTULO COM BASE NO NOME DO VEÍCULO
            Title = veiculo.Nome;

            // VINCULA O MÉTODO DE CLIQUE COM A AÇÃO DE CLIQUE NO BOTÃO
            ButtonProximo.Clicked += ButtonProximoClicked;

            // DEFINE ESTA CLASSE COMO CONTEXTO DE BINDING
            BindingContext = this;
        }

        // AÇÃO DO BOTÃO DE NAVEGAÇÃO PARA A PÁGINA AGENDAMENTO
        private void ButtonProximoClicked(Object sender, EventArgs e) {
            Navigation.PushAsync(new AgendamentoPage(Veiculo));
        }
    }
}
