using LojaNetF.BLL;
using LojaNetF.DAL;
using LojaNetF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNetFwk.Ui.Web.Controllers
{
    public class ClienteController : Controller {
        // GET: Cliente
        private ClienteBLL bll;
        public ClienteController() {
            var dal = new ClienteDAL();
            bll = new ClienteBLL(dal);
        }

        public ActionResult Detalhes(string id) {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        public ActionResult Alterar(string id) {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Alterar(Cliente cliente) {
            try {
                bll.Alterar(cliente);
                return RedirectToAction("Index");
            } catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }
        public ActionResult Incluir() {
            var cli = new Cliente();
            return View(cli);
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente) {
            try {
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            } catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }
        public ActionResult Index() {
            var lista = bll.ObterTodos();
            return View(lista);
        }
        public ActionResult Excluir(string id) {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form) {
            try {
                bll.Excluir(id);
                return RedirectToAction("Index");
            } catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }

        }
    }
}