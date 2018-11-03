using Xamarin.Forms;
using System.Collections.Generic;

namespace Mobile01 {
    public partial class MainPage : ContentPage {
        public List<Veiculo> Veiculos { get; set; }

        public MainPage() {
            InitializeComponent();

            Veiculos.Add(new Veiculo("Azera V6", 60000.0));
            Veiculos.Add(new Veiculo("Fiesta 2.0", 50000.0));
            Veiculos.Add(new Veiculo("HB20 S", 40000.0));

            // INFORMA QUE A FONTE DE DADOS DO MAINPAGE.XAML SERÁ ESTÁ CLASSE
            this.BindingContext = this;
        }
    }
}
