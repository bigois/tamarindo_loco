using System;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoPage : ContentPage {
        public AgendamentoViewModel AgendamentoViewModel { get; set; }

        public AgendamentoPage(Veiculo veiculo) {
            InitializeComponent();

            AgendamentoViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = AgendamentoViewModel;
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSucesso", (agendamento) => {
                DisplayAlert("Agendamento", "Dados salvos com sucesso!", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "AgendamentoFalha", (exception) => {
                DisplayAlert("Agendamento", "Ocorreu um erro durante o salvamente dos dados.\n" +
                    "Verifique as informações e tente novamente", "Ok");
            });

            MessagingCenter.Subscribe<Agendamento>(this, "VeiculoAgendado", async (agendamento) => {
                var confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?", "sim", "não");

                if (confirma) {
                    AgendamentoViewModel.SalvarAgendamento();
                }
            });
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "VeiculoAgendado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSucesso");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "AgendamentoFalha");
        }
    }
}
