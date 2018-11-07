using System;

namespace TestDrive.Models {
    public class Cliente {
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }

        public Cliente() { }

        public Cliente(String nome, String telefone, String email) {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
