using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels {
    public class ListagemViewModel {
        // LISTA DE VEÍCULOS PARA ACESSO PÚBLICO
        public List<Veiculo> Veiculos { get; set; }

        // CHAMA O CONSTRUTOR DA CLASSE DE LISTAGEM
        // PARA RECUPERAR A LISTA DE VEÍCULOS
        public ListagemViewModel() {
            Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}
