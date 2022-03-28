using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojaNet.Ui.Web.Controllers {
    public class ClienteController : Controller {
        private ClienteBLL bll;
        public ClienteController() {
            bll = new ClienteBLL();
        }

        public ActionResult Incluir() {
            var cli = new Cliente();
            return View(cli);
        }

        public ActionResult Detalhes(string id) {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente) {
            try {
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        } 
        public ActionResult Index() {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}
