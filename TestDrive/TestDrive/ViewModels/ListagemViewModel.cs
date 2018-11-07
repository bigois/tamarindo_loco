using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using System.Collections.Generic;

namespace TestDrive.ViewModels {
    public class ListagemViewModel {
        private const string URI = "http://aluracar.herokuapp.com";
        public ObservableCollection<Veiculo> Veiculos { get; set; }

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
            Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos() {
            HttpClient client = new HttpClient();

            var resultado = await client.GetStringAsync(URI);
            var veiculosJson = JsonConvert.DeserializeObject<List<Veiculo>>(resultado);

            foreach (var veiculoJson in veiculosJson) {
                Veiculos.Add(veiculoJson);
            }
            
        }
    }
}
