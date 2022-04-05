﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LojaNetF.DAL;

namespace LojaNetF.Test {
    [TestClass]
    public class ClienteDALTest {

        [TestMethod]
        public void ObterPorEmailNullTest() {
            string email = null;
            var dal = new ClienteDAL();
            bool ok = false;
            try {
                var cliente = dal.ObterPorEmail(email);
            } catch (ApplicationException ex) {
                if (ex.Message == "O email deve ser informado") {
                    ok = true;
                }
                Console.WriteLine("Erro no Servidor. Parametro não informado" + ex.Message);
            }
            Assert.IsTrue(ok, "O email deve ser informado");
        }




        [TestMethod]
        public void ObterPorEmailTest() {
            string email = "teste@silva.com.br";
            var dal = new ClienteDAL();
            var cliente = dal.ObterPorEmail(email);


            if (cliente != null) {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(cliente.Id);
                Console.WriteLine(cliente.Nome);
                Console.WriteLine(cliente.Email);
                Console.WriteLine(cliente.Telefone);
            }

            Assert.IsTrue(cliente != null, "Deveria ter retornado uma instância de um cliente");
        }
    }
}
