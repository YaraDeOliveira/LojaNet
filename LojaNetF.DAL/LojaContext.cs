using LojaNetF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LojaNetF.DAL {
    public class LojaContext : DbContext {
        public LojaContext() : base(DbHelper.conexao) {
        }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}
