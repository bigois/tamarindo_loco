using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels {
    public class ListagemViewModel {
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
    }
}
