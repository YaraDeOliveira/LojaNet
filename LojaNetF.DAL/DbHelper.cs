﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;


namespace LojaNetF.DAL {
    public static class DbHelper {
        public static string conexao {
            get {
                return @"Data Source = DESKTOP-UMN81ED\SQLEXPRESS; 
                         Initial Catalog=LojaNetDb;
                         Integrated Security=true";   

            }
        }
        public static int ExecuteNonQuery(string storedProcedure, params object[] parametros) {
            int retorno = 0;
            using (var cn = new SqlConnection(conexao)) {
                using (var cmd = new SqlCommand(storedProcedure, cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    PreencherParametros(parametros, cmd);
                    cn.Open();
                    retorno = cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
            return retorno;
        }

      
        public static IDataReader ExecuteReader(string storedProcedure, params object [] parametros) {
            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand(storedProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            PreencherParametros(parametros, cmd);
            cn.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        private static void PreencherParametros(object[] parametros, SqlCommand cmd) {
            if (parametros.Length > 0) {
                for (int i = 0; i < parametros.Length; i += 2) {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }
        }

    }
}