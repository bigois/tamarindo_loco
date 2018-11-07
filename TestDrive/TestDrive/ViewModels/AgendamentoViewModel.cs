using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels {
    public class AgendamentoViewModel {
        private const String URI = "http://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }
        public ICommand CommandAgendar { get; set; }

        public AgendamentoViewModel(Veiculo veiculo) {
            Agendamento = new Agendamento {
                Veiculo = veiculo
            };
            CommandAgendar = new Command(() => {
                MessagingCenter.Send(Agendamento, "VeiculoAgendado");
            });
        }

        public async void SalvarAgendamento() {
            HttpClient client = new HttpClient();

            var conteudo = new StringContent("", Encoding.UTF8, "application/json");
            var response = await client.PostAsync(URI, conteudo);

            if (response.IsSuccessStatusCode) {
                MessagingCenter.Send(Agendamento, "AgendamentoSucesso");
            } else {
                MessagingCenter.Send(new ArgumentException(), "AgendamentoFalha");
            }
        }
    }
}
