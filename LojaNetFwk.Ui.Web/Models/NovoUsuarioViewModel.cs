﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaNetFwk.Ui.Web.Models
{
    public class NovoUsuarioViewModel
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}