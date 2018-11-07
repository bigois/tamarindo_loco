using System;

namespace TestDrive.Models {
    public class Agendamento {
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public DateTime DataAgendamento { get; set; }

        public Agendamento() {
            DataAgendamento = DateTime.Today;
            Cliente = new Cliente();
            Veiculo = new Veiculo();
        }
    }
}
