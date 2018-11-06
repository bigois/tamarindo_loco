using System;
using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemPage : ContentPage {
        // LISTA DE VEÍCULOS PARA ACESSO PÚBLICO
        public List<Veiculo> Veiculos { get; set; }

        public ListagemPage() {
			InitializeComponent();

            // CHAMA O CONSTRUTOR DA CLASSE DE LISTAGEM
            // PARA RECUPERAR A LISTA DE VEÍCULOS
            Veiculos = new ListagemVeiculos().Veiculos;

            // ADICIONA O EVENTO DE CLIQUE NA LISTA
            ListViewVeiculos.ItemTapped += ListViewVeiculosItemTapped;

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
