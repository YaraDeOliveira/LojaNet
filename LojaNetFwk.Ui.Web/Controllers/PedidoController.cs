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
            
            var pedido = new PedidoViewModel();
            pedido.Clientes = bllCliente.ObterTodos();
            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagtoEnum)).ToList();
            return View(pedido);
        }
    }
}