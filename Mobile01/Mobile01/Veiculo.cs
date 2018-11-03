using System;

namespace Mobile01 {
    public class Veiculo {
        private String nome { get; set; }
        private Double preco { get; set; }

        public Veiculo(string nome, double preco) {
            this.nome = nome;
            this.preco = preco;
        }
    }
}
