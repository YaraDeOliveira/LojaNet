using LojaNetFwk.Ui.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            
            return View(pedido);
        }
    }
}