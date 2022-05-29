using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LojaNetF.Models;
using LojaNetF.DAL;

namespace LojaNetF.Test
{

    [TestClass]
    public class PedidoUnitTest
    {
        [TestMethod]
        public void Incluir()
        {
            var pedido = new Pedido();
            pedido.Data = DateTime.Now;
            pedido.Cliente = new Cliente()
            {
                Id = "13abee88-daee-4a90-a054-f9b35feedd18",
                Nome = "José da Silva",
                Telefone = "339475485",
                Email = "email@teste.com.br"
            };
            pedido.FormaPagto = FormaPagtoEnum.Dinheiro;
            pedido.Items = new List<Pedido.Item>();

            var item = new Pedido.Item();
            item.Produto = new Produto()
            {
                Id = "39bee29b-1e05-4fc7-b48a-ac2ab1ea3f10",
                Nome = "Caneta",
                Preco = 1,
                Estoque = 300
            };
            item.Quantidade = 3;
            item.Ordem = 1;
            item.Preco = 1;

            pedido.Items.Add(item);

            item = new Pedido.Item();
            item.Produto = new Produto()
            {
                Id = "46832b77-976f-4003-8379-0d8ae1eb0ef9",
                Nome = "Borracha",
                Preco = 0.50m,
                Estoque = 300
            };
            item.Quantidade = 3;
            item.Ordem = 2;
            item.Preco = 0.50M;

            pedido.Items.Add(item);

            var dal = new PedidoDAL();
            dal.Incluir(pedido);
        }


    }
}
