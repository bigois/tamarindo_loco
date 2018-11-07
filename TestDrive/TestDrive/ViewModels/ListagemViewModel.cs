using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace TestDrive.ViewModels {
    public class ListagemViewModel : BaseViewModel {
        private const string URI = "http://aluracar.herokuapp.com";
        public ObservableCollection<Veiculo> Veiculos { get; set; }

        private Boolean aguarde;

        public Boolean Aguarde {
            get { return aguarde; }
            set {
                aguarde = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Aguarde));
            }
        }

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
            Aguarde = true;

            HttpClient client = new HttpClient();

            var resultado = await client.GetStringAsync(URI);
            var veiculosJson = JsonConvert.DeserializeObject<List<Veiculo>>(resultado);

            foreach (var veiculoJson in veiculosJson) {
                Veiculos.Add(new Veiculo(veiculoJson.Nome, veiculoJson.Preco));
            }

            Aguarde = false;
        }
    }
}
