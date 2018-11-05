using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoPage : ContentPage {
        // PROPRIEDADE GLOBAL PARA FACILITAR O TRANSPORTE
        public Veiculo Veiculo { get; set; }

        public AgendamentoPage(Veiculo veiculo) {
			InitializeComponent();

            // ATRÍBUI O VEÍCULO RECEBIDO PARA A VARIÁVEL INTERNA
            Veiculo = veiculo;

            // ALTERA O TÍTULO COM BASE NO NOME DO VEÍCULO
            Title = veiculo.Nome;
        }
	}
}
