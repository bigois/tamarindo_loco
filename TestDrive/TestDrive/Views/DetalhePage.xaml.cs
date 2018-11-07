using System;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePage : ContentPage {
        // PROPRIEDADE GLOBAL PARA FACILITAR O TRANSPORTE
        public Veiculo Veiculo { get; set; }

        public DetalhePage(Veiculo veiculo) {
            InitializeComponent();

            // DEFINE ESTA CLASSE COMO CONTEXTO DE BINDING
            BindingContext = new DetalheViewModel(veiculo);

            // ATRÍBUI O VEÍCULO RECEBIDO PARA A VARIÁVEL INTERNA
            Veiculo = veiculo;

            // VINCULA O MÉTODO DE CLIQUE COM A AÇÃO DE CLIQUE NO BOTÃO
            ButtonProximo.Clicked += ButtonProximoClicked;

            // NÃO CORRESPONDE AO MODELO MVVM, MAS FOI O MELHOR JEITO ENCONTRADO
            // PARA ADICIONAR AÇÕES EM CASO DE MUDANÇA DE ESTADO DOS SWITCHES
            SwitchFreio.OnChanged += OnSwitchChanged;
            SwitchMP3.OnChanged += OnSwitchChanged;
            SwitchArCondicionado.OnChanged += OnSwitchChanged;
        }

        // NÃO CORRESPONDE AO MODELO MVVM, MAS FOI O MELHOR JEITO ENCONTRADO
        // PARA REALIZAR A AÇÃO DE RECÁLCULO DOS VALORES
        private void OnSwitchChanged(object sender, ToggledEventArgs e) {
            Veiculo.CalculaValorTotal(SwitchFreio, SwitchMP3, SwitchArCondicionado, TextTotal);
        }

        // AÇÃO DO BOTÃO DE NAVEGAÇÃO PARA A PÁGINA AGENDAMENTO
        private void ButtonProximoClicked(Object sender, EventArgs e) {
            Navigation.PushAsync(new AgendamentoPage(Veiculo));
        }
    }
}
