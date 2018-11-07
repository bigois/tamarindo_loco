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
            MessagingCenter.Subscribe<Agendamento>(this, "VeiculoAgendado", (agendamento) => {
                DisplayAlert("Agendamento", 
                    String.Format("Nome: {0}\nTelefone: {1}\nE -mail: {2}\nData de Agendamento: {3}\nHora do Agendamento: {4}\nVeículo: {5}\nValor: {6:N}",
                               agendamento.Cliente.Nome,
                               agendamento.Cliente.Telefone,
                               agendamento.Cliente.Email,
                               agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                               agendamento.HoraAgendamento,
                               agendamento.Veiculo.Nome,
                               agendamento.Veiculo.ValorTotal), "Ok");
            });
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "VeiculoAgendado");
        }
    }
}
