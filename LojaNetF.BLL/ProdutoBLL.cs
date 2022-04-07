using System;
using System.Collections.Generic;
using System.Linq;
using LojaNetF.Models;
using LojaNetF.DAL;

namespace LojaNetF.BLL {
    public class ProdutoBLL : IProdutosDados {
        private IProdutosDados dal;
        public ProdutoBLL(IProdutosDados produtoDados) {
            this.dal = produtoDados;
        }

        public void Validar(Produto produto) {
            if (String.IsNullOrEmpty(produto.Nome)) {
                throw new Exception("O nome deve ser informado");
            }

            if (produto.Preco < 0) {
                throw new Exception("O preço deve ser maior ou igual a zero");
            }

        }

        public void Alterar(Produto produto) {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id)) {
                throw new Exception("O Id deve ser informado");
            }
            dal.Alterar(produto);
        }

        public void Excluir(string id) {
            if (string.IsNullOrEmpty(id)) {
                throw new Exception("O Id deve ser informado");
            }
            dal.Excluir(id);
        }

        public void Incluir(Produto produto) {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id)) {
                produto.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(produto); ;
        }

        public Produto ObterPorId(string id) {
            return dal.ObterPorId(id); ;
        }

        public List<Produto> ObterTodos() {
            var lista = dal.ObterTodos();
            return lista;
        }
    }
}
