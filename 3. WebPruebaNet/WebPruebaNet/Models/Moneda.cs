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
    public class Moneda
    {
        public int iMonedaId { get; set; }
        public string vnombreMoneda { get; set; }


        public SelectList getMonedas(int iDefault)
        {

            var TipoMonedaList = new SelectList(
                                new[]
                        {

                            new {Value = 1,Text="Soles"},
                            new {Value = 2,Text="Dolares"}

                        }, "Value", "Text", iDefault);

            return TipoMonedaList;
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
        //        using (SqlCommand cmd = new SqlCommand("sp_listarMonedas", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            con.Open();
        //            SqlDataReader drd = cmd.ExecuteReader();
        //            if (drd != null)
        //            {
        //                while (drd.Read())
        //                {
        //                    if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iMonedaId")))
        //                    {
        //                        bancoBE = new Banco();
        //                        bancoBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iMonedaId"));
        //                        bancoBE.vNombreBanco = drd.GetString(drd.GetOrdinal("vNombreMoneda"));
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
