using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels {
    public class AgendamentoViewModel {
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
    }
}
