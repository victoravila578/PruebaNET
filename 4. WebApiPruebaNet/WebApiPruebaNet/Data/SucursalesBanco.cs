using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPruebaNet.Data
{
    public class SucursalesBanco
    {
        public int iCodigoSucursal { get; set; }
        public int iCodigoBanco { get; set; }
        public string xNombreBanco { get; set; }
        public string xNombreSucursal { get; set; }
        public string xDireccion { get; set; }
        public string dFechaRegistro { get; set; }


        public List<SucursalesBanco> obtenerSucursalPorBanco(int iBanco)
        {            
            var lstSucursal = new List<SucursalesBanco>();
            var SucursalBE = new SucursalesBanco();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerSucursalesPorBanco", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iBancoId", SqlDbType.Int);
                    pr1.Value = iBanco;

                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iSucursalId")))
                            {
                                SucursalBE = new SucursalesBanco();
                                SucursalBE.iCodigoSucursal = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                SucursalBE.iCodigoBanco = drd.GetInt32(drd.GetOrdinal("iBancoId"));
                                SucursalBE.xNombreBanco = drd.GetString(drd.GetOrdinal("vNombreBanco"));
                                SucursalBE.xNombreSucursal = drd.GetString(drd.GetOrdinal("vNombre"));
                                SucursalBE.xDireccion = drd.GetString(drd.GetOrdinal("vDireccion"));
                                SucursalBE.dFechaRegistro = drd.GetString(drd.GetOrdinal("dFechaRegistro"));
                                lstSucursal.Add(SucursalBE);
                            }
                        }
                    }
                }
            }
            return lstSucursal;
        }
    }
}
