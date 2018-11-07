using System.Collections.Generic;

namespace TestDrive.Models {
    public class ListagemVeiculos {
        public List<Veiculo> Veiculos { get; set; }
        
        public ListagemVeiculos() {
            Veiculos = new List<Veiculo>() {
                new Veiculo ("Azera V6", 85000.0),
                new Veiculo ("Onix 1.6", 35000.0),
                new Veiculo ("Fiesta 2.0", 52000.0),
                new Veiculo ("C3 1.0", 22000.0),
                new Veiculo ("Uno Fire",  11000.0),
                new Veiculo ("Sentra 2.0", 53000.0),
                new Veiculo ("Astra Sedan", 39000.0),
                new Veiculo ("Vectra 2.0 Turbo", 37000.0),
                new Veiculo ("Hilux 4x4", 90000.0),
                new Veiculo ("Montana Sport", 57000.0),
                new Veiculo ("Outlander 2.4", 99000.0),
                new Veiculo ("Brasilia Amarela", 9500.0),
                new Veiculo ("Omega Hatch", 8000.0)
            };
        }
    }
}
