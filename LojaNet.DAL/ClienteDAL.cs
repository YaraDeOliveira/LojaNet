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
            var lista = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("ClienteListar")) {
                while (reader.Read()) {
                    var cliente = new Cliente();
                    cliente.Id = reader["Id"].ToString();
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.Telefone = reader["Telefone"].ToString();
                    cliente.Email = reader["Email"].ToString();
                    lista.Add(cliente);
                }
            }
            return lista;
        }
    }
}
