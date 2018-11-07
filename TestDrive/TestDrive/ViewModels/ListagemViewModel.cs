using System.Collections.Generic;
using System.Net.Http;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels {
    public class ListagemViewModel {
        private const string URI = "http://aluracar.herokuapp.com";
        public List<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado {
            get { return veiculoSelecionado; }
            set {
                veiculoSelecionado = value;

                if (veiculoSelecionado != null) {
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
                }
            }
        }

        public ListagemViewModel() {
            Veiculos = new ListagemVeiculos().Veiculos;
        }

        public async void GetVeiculos() {
            HttpClient client = new HttpClient();
            var resultado = await client.GetStringAsync(URI);
        }
    }
}
