using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaNetF.BLL;
using LojaNetF.DAL;
using LojaNetF.Models;

namespace LojaNetFwk.Ui.Web {
    public static class AppContainer {

        public static IClienteDados ObterClienteBLL() {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            return bll;
        }

        public static IProdutosDados ObterProdutoBLL() {
            var dal = new ProdutoDAL();
            var bll = new ProdutoBLL(dal);
            return bll;
        }
    }
}