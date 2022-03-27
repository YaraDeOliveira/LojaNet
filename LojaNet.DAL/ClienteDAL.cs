using System;
using System.Collections.Generic;
using LojaNet.Models;

namespace LojaNet.DAL {
    public class ClienteDAL : IClienteDados {
        // Cliente: Acesso a dados
        // Data Access Layer
        public void Alterar(Cliente cliente) {
            throw new NotImplementedException();
        }

        public void Excluir(string id) {
            throw new NotImplementedException();
        }

        public void Incluir(Cliente cliente) {
            DbHelper.ExecuteNonQuery("ClienteIncluir",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Telefone", cliente.Telefone,
                "@Email", cliente.Email
                );
        }

        public Cliente ObterPorEmail(string email) {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string id) {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterTodos() {
            throw new NotImplementedException();
        }
    }
}
