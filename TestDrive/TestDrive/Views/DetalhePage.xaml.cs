using System;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePage : ContentPage {
        public Veiculo Veiculo { get; set; }

        public DetalhePage(Veiculo veiculo) {
            InitializeComponent();

            BindingContext = new DetalheViewModel(veiculo);
            Veiculo = veiculo;

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

        protected override void OnAppearing() {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (veiculo) => {
                Navigation.PushAsync(new AgendamentoPage(veiculo));
            });
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}
