using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojaNet.Ui.Web.Controllers {
    public class ClienteController : Controller {
        
        public ActionResult Incluir() {
            var cli = new Cliente();
            return View(cli);
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente) {
            try {
                var bll = new ClienteBLL();
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        } 
        public ActionResult Index() {
            return View();
        }
    }
}
