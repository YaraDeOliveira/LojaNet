using LojaNetFwk.Ui.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaNetF.Models;

namespace LojaNetFwk.Ui.Web.Controllers
{
    public class PedidoController : Controller
    {

        // GET: Pedido
        public ActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();
            var bllProduto = AppContainer.ObterProdutoBLL();

            var pedido = new PedidoViewModel();

            pedido.Clientes = bllCliente.ObterTodos();
            pedido.Produtos = bllProduto.ObterTodos();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagtoEnum)).ToList();

            //pedido.Items.Add(new PedidoViewModel.Item()
            //{
            //    ProdutoId = "837483",
            //    ProdutoNome = "Caneta",
            //    Quantidade = 10,
            //    Valor = 2
            //});

            //pedido.Items.Add(new PedidoViewModel.Item()
            //{
            //    ProdutoId = "7787857",
            //    ProdutoNome = "Borracha",
            //    Quantidade = 180,
            //    Valor = 100
            //});

            //pedido.Items.Add(new PedidoViewModel.Item()
            //{
            //    ProdutoId = "998367",
            //    ProdutoNome = "Lápis",
            //    Quantidade = 150,
            //    Valor = 320
            //});

            return View(pedido);
        }

        [HttpPost]
        public ActionResult Incluir(PedidoViewModel pedido)
        {
            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();

            pedido.Clientes = bllCliente.ObterTodos();
            pedido.Produtos = bllProduto.ObterTodos();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagtoEnum)).ToList();

            if (Request.Form["incluirProduto"] == "Incluir")
            {

                var item = new PedidoViewModel.Item();
                item.ProdutoId = pedido.NovoItemProdutoId;
                item.Quantidade = pedido.NovoItemQuantidade;


                var produto = bllProduto.ObterPorId(item.ProdutoId);
                item.Valor = produto.Preco;
                item.ProdutoNome = produto.Nome;

                pedido.Items.Add(item);

            }
            else if (Request.Form["Gravar"] == "Gravar")
            {
                //var bll = AppContainer.ObterPedidoBLL();
            }

            return View(pedido);
        }
    }
}