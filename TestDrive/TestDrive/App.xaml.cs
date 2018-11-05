using Xamarin.Forms;

namespace TestDrive {
	public partial class App : Application {
		public App() {
			InitializeComponent();

            // FAZ A CHAMADA DA PÁGINA DE LISTAGEM PELO
            // CONTEXTO DE EMPILHAMENTO DE CAMADAS
            MainPage = new NavigationPage(new Views.ListagemPage());
        }

        // CHAMADO NO NA ABERTURA DA PÁGINA
		protected override void OnStart() { }

        // CHAMADO QUANDO A PÁGINA ENTRE EM ESPERA
        protected override void OnSleep() { }

        // CHAMADO QUANDO A PÁGINA É FECHADA
		protected override void OnResume() { }
	}
}
