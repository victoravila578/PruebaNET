using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace WebPruebaNet.Models
{
    public class OrdenPago
    {
        public int iOrdenId { get; set; }
        public int iSucursalId { get; set; }
        public decimal fMonto { get; set; }
        public int iTipoMoneda { get; set; }
        public string vNombreMoneda { get; set; }
        public int iEstadoId { get; set; }
        public string vDescripcionEstado { get; set; }
        public string dFechaPago { get; set; }

        public OrdenPago obtenerOrdenPAgo(int iOrdenPago)
        {
            var ordenPagoBE = new OrdenPago();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerOrdenPagoPorId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pr1 = cmd.Parameters.Add("@iOrdenId", SqlDbType.Int);
                    pr1.Value = iOrdenPago;

                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iSucursalId")))
                            {
                                ordenPagoBE = new OrdenPago();
                                ordenPagoBE.iOrdenId = drd.GetInt32(drd.GetOrdinal("iOrdenId"));
                                ordenPagoBE.iSucursalId = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                ordenPagoBE.fMonto = (decimal)drd.GetDouble(drd.GetOrdinal("fMonto"));
                                ordenPagoBE.iTipoMoneda = drd.GetInt32(drd.GetOrdinal("iTipoMoneda"));
                                ordenPagoBE.vNombreMoneda = drd.GetString(drd.GetOrdinal("vNombreMoneda"));
                                ordenPagoBE.iEstadoId = drd.GetInt32(drd.GetOrdinal("iEstadoId"));
                                ordenPagoBE.vDescripcionEstado = drd.GetString(drd.GetOrdinal("vDescripcionEstado"));
                                ordenPagoBE.dFechaPago = drd.GetString(drd.GetOrdinal("dFechaPago"));
                            }
                        }
                    }
                }
            }
            return ordenPagoBE;
        }

        public int insertarOrdenPago(OrdenPago ordenPagoBE)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertOrdenPago", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pr1 = cmd.Parameters.Add("@iSucursalId", SqlDbType.Int);
                    pr1.Value = ordenPagoBE.iSucursalId;

                    SqlParameter pr2 = cmd.Parameters.Add("@fMonto", SqlDbType.Float);
                    pr2.Value = ordenPagoBE.fMonto;

                    SqlParameter pr3 = cmd.Parameters.Add("@iTipoMoneda", SqlDbType.Int);
                    pr3.Value = ordenPagoBE.iTipoMoneda;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Edit(OrdenPago ordenPagoBE)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_modificarOrdenPago", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pr1 = cmd.Parameters.Add("@iOrdenId", SqlDbType.Int);
                    pr1.Value = ordenPagoBE.iOrdenId;

                    SqlParameter pr2 = cmd.Parameters.Add("@fMonto", SqlDbType.Float);
                    pr2.Value = ordenPagoBE.fMonto;

                    SqlParameter pr3 = cmd.Parameters.Add("@iTipoMoneda", SqlDbType.Int);
                    pr3.Value = ordenPagoBE.iTipoMoneda;

                    SqlParameter pr4 = cmd.Parameters.Add("@iEstadoId", SqlDbType.Int);
                    pr4.Value = ordenPagoBE.iEstadoId;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }

            return 1;
        }

        public int eliminarOrdenPago(int iOrdenPago)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_deleteOrderPago", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iOrdenId", SqlDbType.Int);
                    pr1.Value = iOrdenPago;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
    }

    public class OrdenesPago
    {
        public int iBancoId { get; set; }
        public int iSucursalId { get; set; }
        public string vNombreSucursal { get; set; }
        public IEnumerable<OrdenPago> lstOrderVenta { get; set; }


        public OrdenesPago getAllOrdenes(int iSucursal)
        {
            var sucursalBE = new Sucursal().obtenerSucursal(iSucursal);
            var lstOrdenesVentas = new List<OrdenPago>();
            var ordenVentaBE = new OrdenPago();

            var ordenesVentaBE = new OrdenesPago();
            ordenesVentaBE.iSucursalId = sucursalBE.iSucursalId;
            ordenesVentaBE.vNombreSucursal = sucursalBE.vNombre;
            ordenesVentaBE.iBancoId = sucursalBE.iBancoId;

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerOrdenesPago", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iSucursalId", SqlDbType.Int);
                    pr1.Value = iSucursal;

                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iOrdenId")))
                            {
                                ordenVentaBE = new OrdenPago();
                                ordenVentaBE.iOrdenId = drd.GetInt32(drd.GetOrdinal("iOrdenId"));
                                ordenVentaBE.iSucursalId = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                ordenVentaBE.fMonto = (decimal)drd.GetDouble(drd.GetOrdinal("fMonto"));
                                ordenVentaBE.iTipoMoneda = drd.GetInt32(drd.GetOrdinal("iTipoMoneda"));
                                ordenVentaBE.vNombreMoneda = drd.GetString(drd.GetOrdinal("vNombreMoneda"));
                                ordenVentaBE.iEstadoId = drd.GetInt32(drd.GetOrdinal("iEstadoId"));
                                ordenVentaBE.vDescripcionEstado = drd.GetString(drd.GetOrdinal("vDescripcionEstado"));
                                ordenVentaBE.dFechaPago = drd.GetString(drd.GetOrdinal("dFechaPago"));
                                lstOrdenesVentas.Add(ordenVentaBE);
                            }
                        }
                    }
                }
            }
            ordenesVentaBE.lstOrderVenta = lstOrdenesVentas.AsEnumerable();
            return ordenesVentaBE;
        }


    }

}
