using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoPage : ContentPage {
        // PROPRIEDADE GLOBAL PARA FACILITAR O TRANSPORTE
        public Veiculo Veiculo { get; set; }
        public Double ValorTotal { get; set; }

        // ATRIBUTOS DE CLIENTE
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }

        // ATRIBUTOS DO AGENDAMENTO
        public TimeSpan HoraAgendamento { get; set; }

        public DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento { 
            get { return dataAgendamento; }
            set { dataAgendamento = value; }
        }

        public AgendamentoPage(Veiculo veiculo, double valorTotal) {
            // DEFINE ESTA CLASSE COMO CONTEXTO DE BINDING
            BindingContext = this;

            InitializeComponent();

            // ATRÍBUI O VEÍCULO RECEBIDO PARA A VARIÁVEL INTERNA
            Veiculo = veiculo;
            ValorTotal = valorTotal;

            // ALTERA O TÍTULO COM BASE NO NOME DO VEÍCULO
            Title = veiculo.Nome;

            ButtonAgendar.Clicked += ButtonAgendarClicked;
        }

        private void ButtonAgendarClicked(Object sender, EventArgs e) {
            DisplayAlert("Agendamento",
                String.Format(@"Nome: {0}
Telefone: {1}
E-mail: {2}
Data de Agendamento: {3}
Hora do Agendamento: {4}
Veículo: {5}
Valor: {6:N}", 
                                Nome, 
                                Telefone, 
                                Email, 
                                DataAgendamento.ToString("dd/MM/yyyy"),
                                HoraAgendamento,
                                Veiculo.Nome,
                                ValorTotal), "Ok");
        }
    }
}
