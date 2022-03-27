using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;


namespace LojaNet.DAL {
    public static class DbHelper {
        private static string conexao {
            get {
                return @"Data Source = LOCALHOST\SQLEXPRESS; 
                         Initial Catalog=LojaNetDb;
                         Integrated Security=true";   

            }
        }
        public static int ExecuteNonQuery(string storedProcedure, params object[] parametros) {
            int retorno = 0;
            using (var cn = new SqlConnection(conexao)) {
                using (var cmd = new SqlCommand(storedProcedure, cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(parametros.Length > 0) {
                        for( int i = 0; i < parametros.Length; i += 2) {
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                        }
                    }
                    cn.Open();
                    retorno = cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
            return retorno;
        }

    }
}
