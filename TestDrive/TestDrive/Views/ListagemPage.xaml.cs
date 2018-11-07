using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemPage : ContentPage {
        public ListagemPage() {
			InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado" , (veiculo) => {
                Navigation.PushAsync(new DetalhePage(veiculo));
            });
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
