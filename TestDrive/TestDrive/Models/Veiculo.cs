using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace TestDrive.Models {
    public class Veiculo {
        public const Double FREIO_ABS = 800.0;
        public const Double AR_CONDICIONADO = 1000.0;
        public const Double MP3_PLAYER = 500.0;

        [JsonProperty("nome")]
        public String Nome { get; set; }
        [JsonProperty("preco")]
        public Double Preco { get; set; }
        public Double ValorTotal { get; set; }

        public Veiculo() { }

        public Veiculo(String nome, Double preco) {
            Nome = nome;
            Preco = preco;
            ValorTotal = Preco + FREIO_ABS + MP3_PLAYER;
        }

        public void CalculaValorTotal(SwitchCell switchFreio, SwitchCell switchMP3, SwitchCell switchAr, TextCell textTotal) {
            Double ValorOpcionais = 0;

            if (switchFreio.On) { ValorOpcionais += Veiculo.FREIO_ABS; }
            if (switchMP3.On) { ValorOpcionais += Veiculo.MP3_PLAYER; }
            if (switchAr.On) { ValorOpcionais += Veiculo.AR_CONDICIONADO; }

            ValorTotal = Preco + ValorOpcionais;
            textTotal.Text = String.Format("Valor Total: R$ {0:N}", ValorTotal);
        }
    }
}
