using TestDrive.Models;

namespace TestDrive.ViewModels {
    public class AgendamentoViewModel {
        public Agendamento Agendamento { get; set; }

        public AgendamentoViewModel(Veiculo veiculo) {
            Agendamento = new Agendamento();
            Agendamento.Veiculo = veiculo;
        }
    }
}
