using System;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels {
    public class DetalheViewModel {
        public Veiculo Veiculo { get; set; }
        public ICommand CommandProximo { get; set; }

        public DetalheViewModel(Veiculo veiculo) {
            Veiculo = veiculo;
            CommandProximo = new Command(() => {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }

        public String TextFreioABS {
            get { return String.Format("Freio ABS - R$ {0:N}", Veiculo.FREIO_ABS); }
        }

        public String TextArCondicionado {
            get { return String.Format("Ar Condicionado - R$ {0:N}", Veiculo.AR_CONDICIONADO); }
        }

        public String TextMP3Player {
            get { return String.Format("MP3 Player - R$ {0:N}", Veiculo.MP3_PLAYER); }
        }        
    }
}
