using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebPruebaNet.Models
{
    public class Estado
    {
        public int iEstadoId { get; set; }
        public string vDescripcionEstado { get; set; }


        public SelectList getEstados(int iDefault)
        {

            var lstEstados = new SelectList(
                                new[]
                        {

                            new {Value = 1,Text="Pagada"},
                            new {Value = 2,Text="Declinada"},
                            new {Value = 3,Text="Fallida"},
                            new {Value = 4,Text="Anulada"}

                        }, "Value", "Text", iDefault);

            return lstEstados;
        }

        //public IEnumerable getAll()
        //{
        //    var lstbanco = new List<Banco>();
        //    var bancoBE = new Banco();
        //    var builder = new ConfigurationBuilder();
        //    builder.SetBasePath(Directory.GetCurrentDirectory());
        //    builder.AddJsonFile("appsettings.json");
        //    var connectionStringConfig = builder.Build();

        //    using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_listarEstados", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            con.Open();
        //            SqlDataReader drd = cmd.ExecuteReader();
        //            if (drd != null)
        //            {
        //                while (drd.Read())
        //                {
        //                    if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iEstadoId")))
        //                    {
        //                        bancoBE = new Banco();
        //                        bancoBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iEstadoId"));
        //                        bancoBE.vNombreBanco = drd.GetString(drd.GetOrdinal("vDescripcionEstado"));                                
        //                        lstbanco.Add(bancoBE);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return lstbanco.AsEnumerable();
        //}
    }
}
