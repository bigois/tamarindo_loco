using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models {
    public class Cliente {
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }

        public Cliente() { }

        public Cliente(string nome, string telefone, string email) {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
