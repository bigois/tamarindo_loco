using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemPage : ContentPage {
        public ListagemViewModel ListagemViewModel { get; set; }

        public ListagemPage() {
			InitializeComponent();

            ListagemViewModel = new ListagemViewModel();
            BindingContext = ListagemViewModel;

        }

        protected async override void OnAppearing() {
            base.OnAppearing();

            await ListagemViewModel.GetVeiculos();

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
