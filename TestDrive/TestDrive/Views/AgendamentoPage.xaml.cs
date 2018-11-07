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

            ButtonAgendar.Clicked += ButtonAgendarClicked;
        }

        private void ButtonAgendarClicked(Object sender, EventArgs e) {
            DisplayAlert("Agendamento",
                String.Format("Nome: {0}\nTelefone: {1}\nE -mail: {2}\nData de Agendamento: {3}\nHora do Agendamento: {4}\nVeículo: {5}\nValor: {6:N}",
                                AgendamentoViewModel.Agendamento.Cliente.Nome,
                                AgendamentoViewModel.Agendamento.Cliente.Telefone,
                                AgendamentoViewModel.Agendamento.Cliente.Email,
                                AgendamentoViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                                AgendamentoViewModel.Agendamento.HoraAgendamento,
                                AgendamentoViewModel.Agendamento.Veiculo.Nome,
                                AgendamentoViewModel.Agendamento.Veiculo.ValorTotal), "Ok");
        }
    }
}
