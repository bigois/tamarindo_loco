using System;

namespace TestDrive.Models {
    public class Veiculo {
        // DECLARAÇÃO DE CONSTANTES
        public const Double FREIO_ABS = 800.0;
        public const Double AR_CONDICIONADO = 1000.0;
        public const Double MP3_PLAYER = 500.0;

        public String Nome { get; set; }
        public Double Preco { get; set; }
    }
}
