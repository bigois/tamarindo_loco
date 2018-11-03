using System;

namespace Mobile01 {
    public class Veiculo {
        private String Nome { get; set; }
        private Double Preco { get; set; }

        public Veiculo(string Nome, double Preco) {
            this.Nome = Nome;
            this.Preco = Preco;
        }
    }
}
