using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiPruebaNet.Models;

namespace WebApiPruebaNet.Data
{
    public class OrdenPagoSucursal
    {
        
        //public int iCodigoOrdenPago { get; set; }        
        //public int iCodigoSucursal { get; set; }        
        //public string vNombreSucursal { get; set; }        
        //public decimal fMonto { get; set; }        
        //public int iCodigoTipoMoneda { get; set; }        
        //public string vMonedaDescripcion { get; set; }        
        //public int iCodigoEstado { get; set; }        
        //public string vDescripcionEstado { get; set; }        
        //public string dFechaPago { get; set; }

        public IEnumerable<OrdenPagoSucursal> getAll(int iSucursal, int iTipoMoneda)
        {
            var lstOrdenPago = new List<OrdenPagoSucursal>();
            var OrdenPagoBE = new OrdenPagoSucursal();

            var ordenPagoBE = new OrdenPagoSucursal();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerOrdenesPagoPorSucursalTipoMoneda", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iSucursal", SqlDbType.Int);
                    pr1.Value = iSucursal;
                    SqlParameter pr2 = cmd.Parameters.Add("@iTipoMoneda", SqlDbType.Int);
                    pr2.Value = iTipoMoneda;

                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iOrdenId")))
                            {
                                //OrdenPagoBE = new OrdenPago();
                                //OrdenPagoBE.iCodigoOrdenPago = drd.GetInt32(drd.GetOrdinal("iOrdenId"));
                                //OrdenPagoBE.iCodigoSucursal = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                //OrdenPagoBE.vNombreSucursal = drd.GetString(drd.GetOrdinal("vNombreSucursal"));
                                //OrdenPagoBE.fMonto = (decimal)drd.GetDouble(drd.GetOrdinal("fMonto"));
                                //OrdenPagoBE.iCodigoTipoMoneda = drd.GetInt32(drd.GetOrdinal("iTipoMoneda"));
                                //OrdenPagoBE.vMonedaDescripcion = drd.GetString(drd.GetOrdinal("vMonedaDescripcion"));
                                //OrdenPagoBE.iCodigoEstado = drd.GetInt32(drd.GetOrdinal("iCodigoEstado"));
                                //OrdenPagoBE.vDescripcionEstado = drd.GetString(drd.GetOrdinal("vDescripcionEstado"));
                                //OrdenPagoBE.dFechaPago = drd.GetString(drd.GetOrdinal("dFechaPago"));
                                //lstOrdenPago.Add(OrdenPagoBE);
                            }
                        }
                    }
                }
            }
            return lstOrdenPago;
        }
    }
}
