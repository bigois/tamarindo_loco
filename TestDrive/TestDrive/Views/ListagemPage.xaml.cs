using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
    // CLASSE VEÍCULO NÃO ENCAPSULADA
    public class Veiculo {
        public String Nome { get; set; }
        public Double Preco { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemPage : ContentPage {
        // LISTA DE VEÍCULOS PARA ACESSO PÚBLICO
        public List<Veiculo> Veiculos { get; set; }

        public ListagemPage() {
			InitializeComponent();

            // ADICIONA O EVENTO DE CLIQUE NA LISTA
            ListViewVeiculos.ItemTapped += ListViewVeiculosItemTapped;

            // MONTA A LISTA DE VEÍCULOS
            Veiculos = new List<Veiculo>() {
                new Veiculo { Nome = "Azera V6", Preco = 85000 },
                new Veiculo { Nome = "Onix 1.6", Preco = 35000 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 52000 },
                new Veiculo { Nome = "C3 1.0", Preco = 22000 },
                new Veiculo { Nome = "Uno Fire", Preco = 11000 },
                new Veiculo { Nome = "Sentra 2.0", Preco = 53000 },
                new Veiculo { Nome = "Astra Sedan", Preco = 39000 },
                new Veiculo { Nome = "Vectra 2.0 Turbo", Preco = 37000 },
                new Veiculo { Nome = "Hilux 4x4", Preco = 90000 },
                new Veiculo { Nome = "Montana Sport", Preco = 57000 },
                new Veiculo { Nome = "Outlander 2.4", Preco = 99000 },
                new Veiculo { Nome = "Brasilia Amarela", Preco = 9500 },
                new Veiculo { Nome = "Omega Hatch", Preco = 8000 }
            };

            // INFORMA QUE O CONTEXTO DE MONTAGEM É A PRÓPRIA CLASSE
            BindingContext = this;
        }

        // MÉTODO CHAMADO AO TOCAR EM CADA ITEM DA LISTAGEM
        private void ListViewVeiculosItemTapped(Object sender, ItemTappedEventArgs e) {
            // RETORNA O VALOR CONTIDO EM ITEMTAPPEDEVENTARGS
            // QUE FOI TOCADO PELO USUÁRIO
            var veiculo = (Veiculo) e.Item;

            // CHAMA A PÁGINA DE DETALHE PASSANDO O VEÍCULO
            Navigation.PushAsync(new DetalhePage(veiculo));
        }
    }
}
