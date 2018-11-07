using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels {
    public class DetalheViewModel {
        public Veiculo Veiculo { get; set; }

        // CONSTRUTOR PARA RECEBER O VEÍCULO
        public DetalheViewModel(Veiculo veiculo) {
            Veiculo = veiculo;
        }

        // MÉTODO FEIO DE FORMTAÇÃO DE TEXTO DO SWITCH FREIO ABS
        public String TextFreioABS {
            get { return String.Format("Freio ABS - R$ {0:N}", Veiculo.FREIO_ABS); }
        }

        // MÉTODO FEIO DE FORMATAÇÃO DE TEXTO DO SWITCH AR CONDICIONADO
        public String TextArCondicionado {
            get { return String.Format("Ar Condicionado - R$ {0:N}", Veiculo.AR_CONDICIONADO); }
        }

        public String TextMP3Player {
            get { return String.Format("MP3 Player - R$ {0:N}", Veiculo.MP3_PLAYER); }
        }
    }
}
