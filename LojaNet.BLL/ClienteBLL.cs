﻿using System;
using System.Collections.Generic;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.BLL {

    //Business Logic Layer Tarefa de Validar os dados
    public class ClienteBLL : IClienteDados {
        public void Alterar(Cliente cliente) {
            throw new NotImplementedException();
        }

        public void Excluir(string id) {
            throw new NotImplementedException();
        }

        public void Incluir(Cliente cliente) {
           if(string.IsNullOrEmpty(cliente.Nome)) {
                throw new ApplicationException("O nome deve ser informado");
            }
            if (string.IsNullOrEmpty(cliente.Id)) {
                cliente.Id = Guid.NewGuid().ToString();
            }

            var dal = new ClienteDAL();
            dal.Incluir(cliente);
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
