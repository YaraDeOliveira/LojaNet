using System;
using System.Collections.Generic;
using LojaNetF.Models;
using System.Web;

namespace LojaNetF.DAL {
    public class ClienteDAL : IClienteDados {
        // Cliente: Acesso a dados
        // Data Access Layer
        public void Alterar(Cliente cliente) {
            DbHelper.ExecuteNonQuery("ClienteAlterar",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Telefone", cliente.Telefone,
                "@Email", cliente.Email
                ); ;
        }

        public void Excluir(string id) {

            string arquivo = HttpContext.Current.Server.MapPath("~/App_data/Cliente_" + id + ".xml");
            Cliente cliente = ObterPorId(id);
            SerializadorHelper.Serializar(arquivo, cliente);
            DbHelper.ExecuteNonQuery("ClienteExcluir", "@Id", id);
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
            if (string.IsNullOrEmpty(email)) {
                throw new ApplicationException("O email deve ser informado");
            }

            Cliente cliente = null;
            using (var reader = DbHelper.ExecuteReader("ClienteObterPorEmail", "@Email", email)) {
                if (reader.Read()) {
                    cliente = ObterClienteReader(reader);
                }
            }
            return cliente;

        }

        public Cliente ObterPorId(string id) {
            Cliente cliente = null;
            using (var reader = DbHelper.ExecuteReader("ClienteObterPorId", "@Id", id)) {
                if (reader.Read()) {
                    cliente = ObterClienteReader(reader);
                }
            }
            return cliente;

        }

        public List<Cliente> ObterTodos() {
            var lista = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("ClienteListar")) {
                while (reader.Read()) {
                    Cliente cliente = ObterClienteReader(reader);
                    lista.Add(cliente);
                }
            }
            return lista;
        }

        private static Cliente ObterClienteReader(System.Data.IDataReader reader) {
            var cliente = new Cliente();
            cliente.Id = reader["Id"].ToString();
            cliente.Nome = reader["Nome"].ToString();
            cliente.Telefone = reader["Telefone"].ToString();
            cliente.Email = reader["Email"].ToString();
            return cliente;
        }
    }
}
