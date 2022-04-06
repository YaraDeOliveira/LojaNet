using System;
using System.Collections.Generic;
using LojaNetF.Models;
using LojaNetF.DAL;

namespace LojaNetF.BLL {

    //Business Logic Layer Tarefa de Validar os dados
    public class ClienteBLL : IClienteDados {

        private IClienteDados dal;

        public ClienteBLL(IClienteDados clienteDados) {
            this.dal = clienteDados;
        }
        public void Alterar(Cliente cliente) {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id)) {
                throw new Exception("O Id deve ser informado");
            }
            dal.Alterar(cliente);
        }

        public void Excluir(string id) {
            if (string.IsNullOrEmpty(id)) {
                throw new Exception("O Id deve ser informado");
            }
            dal.Excluir(id);
        }

        public void Incluir(Cliente cliente) {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id)) {
                cliente.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(cliente);
        }

        public Cliente ObterPorEmail(string email) {
            return dal.ObterPorEmail(email);
        }

        public Cliente ObterPorId(string id) {
            return dal.ObterPorId(id);
        }

        public List<Cliente> ObterTodos() {
            var lista = dal.ObterTodos();
            return lista;
        }

        private static void Validar(Cliente cliente) {
            if (string.IsNullOrEmpty(cliente.Nome)) {
                throw new ApplicationException("O nome deve ser informado");
            }
        }
    }
}
