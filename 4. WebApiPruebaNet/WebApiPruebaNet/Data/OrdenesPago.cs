using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebApiPruebaNet.Data
{
    public class OrdenesPago
    {
        public int iCodigoOrdenPago { get; set; }
        public int iCodigoSucursal { get; set; }
        public string xNombreSucursal { get; set; }
        public decimal fMonto { get; set; }
        public int iCodigoTipoMoneda { get; set; }
        public string xMonedaDescripcion { get; set; }
        public int iCodigoEstado { get; set; }
        public string xDescripcionEstado { get; set; }
        public string dFechaPago { get; set; }


        public List<OrdenesPago> getAll(int iSucursal, int iTipoMoneda)
        {
            
            var lstOrdenPago = new List<OrdenesPago>();
            var OrdenPagoBE = new OrdenesPago();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerOrdenesPagoPorSucursalTipoMoneda", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iSucursalId", SqlDbType.Int);
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
                                OrdenPagoBE = new OrdenesPago();
                                OrdenPagoBE.iCodigoOrdenPago = drd.GetInt32(drd.GetOrdinal("iOrdenId"));
                                OrdenPagoBE.iCodigoSucursal = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                OrdenPagoBE.xNombreSucursal = drd.GetString(drd.GetOrdinal("vNombre"));
                                OrdenPagoBE.fMonto = (decimal)drd.GetDouble(drd.GetOrdinal("fMonto"));
                                OrdenPagoBE.iCodigoTipoMoneda = drd.GetInt32(drd.GetOrdinal("iTipoMoneda"));
                                OrdenPagoBE.xMonedaDescripcion = drd.GetString(drd.GetOrdinal("vNombreMoneda"));
                                OrdenPagoBE.iCodigoEstado = drd.GetInt32(drd.GetOrdinal("iEstadoId"));
                                OrdenPagoBE.xDescripcionEstado = drd.GetString(drd.GetOrdinal("vDescripcionEstado"));
                                OrdenPagoBE.dFechaPago = drd.GetString(drd.GetOrdinal("dFechaPago"));
                                lstOrdenPago.Add(OrdenPagoBE);
                            }
                        }
                    }
                }
            }
            return lstOrdenPago;
        }

    }
}
