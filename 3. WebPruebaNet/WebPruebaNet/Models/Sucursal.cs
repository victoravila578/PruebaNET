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
    public class Sucursal
    {        
        public int iSucursalId { get; set; }
        public int iBancoId { get; set; }
        public string vNombreBanco { get; set; }
        public string vNombre { get; set; }
        public string vDireccion { get; set; }
        public string dFechaRegistro { get; set; }


        public IEnumerable getAll(int iBancoId)
        {
            var lstSucursal = new List<Sucursal>();
            var SucursalBE = new Sucursal();
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
                    pr1.Value = iBancoId;

                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iSucursalId")))
                            {
                                SucursalBE = new Sucursal();
                                SucursalBE.iSucursalId = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                SucursalBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iBancoId"));
                                SucursalBE.vNombreBanco = drd.GetString(drd.GetOrdinal("vNombreBanco"));
                                SucursalBE.vNombre = drd.GetString(drd.GetOrdinal("vNombre"));
                                SucursalBE.vDireccion = drd.GetString(drd.GetOrdinal("vDireccion"));
                                SucursalBE.dFechaRegistro = drd.GetString(drd.GetOrdinal("dFechaRegistro"));
                                lstSucursal.Add(SucursalBE);
                            }
                        }
                    }
                }
            }
            return lstSucursal.AsEnumerable();
        }

        public int insertarSucursal(Sucursal SucursalBE)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertSucursal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pr1 = cmd.Parameters.Add("@iBancoId", SqlDbType.Int);
                    pr1.Value = SucursalBE.iBancoId;

                    SqlParameter pr2 = cmd.Parameters.Add("@vNombreSucursal", SqlDbType.VarChar);
                    pr2.Value = SucursalBE.vNombre;

                    SqlParameter pr3 = cmd.Parameters.Add("@vDireccion", SqlDbType.VarChar);
                    pr3.Value = SucursalBE.vDireccion;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Edit(Sucursal SucursalBE)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_updateSucursal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iSucursalId", SqlDbType.Int);
                    pr1.Value = SucursalBE.iSucursalId;

                    SqlParameter pr2 = cmd.Parameters.Add("@vNombreSucursal", SqlDbType.VarChar);
                    pr2.Value = SucursalBE.vNombre;

                    SqlParameter pr3 = cmd.Parameters.Add("@vDireccion", SqlDbType.VarChar);
                    pr3.Value = SucursalBE.vDireccion;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }

            return 1;
        }

        public Sucursal obtenerSucursal(int iSucursal)
        {
            var sucursalBE = new Sucursal();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerSucursalesPorId", con))
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
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iSucursalId")))
                            {
                                sucursalBE = new Sucursal();
                                sucursalBE.iSucursalId = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                sucursalBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iBancoId"));
                                sucursalBE.vNombre = drd.GetString(drd.GetOrdinal("vNombre"));
                                sucursalBE.vDireccion = drd.GetString(drd.GetOrdinal("vDireccion"));
                            }
                        }
                    }
                }
            }
            return sucursalBE;
        }

        public int eliminarSucursal(int iSucursal)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_deleteSucursal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@isucursalId", SqlDbType.Int);
                    pr1.Value = iSucursal;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
    }

    public class Sucursales
    {               
        public int iBancoId { get; set; }
        public string vNombreBanco { get; set; }
        public IEnumerable<Sucursal> SucursalList { get; set; }


        public IEnumerable getAllInfo(int iBancoId)
        {
            var bancoBE = new Banco().obtenerBanco(iBancoId);
            var lstSucursal = new List<Sucursal>();
            var SucursalBE = new Sucursal();

            var SucursalesBE = new Sucursales();
            SucursalesBE.iBancoId = bancoBE.iBancoId;
            SucursalesBE.vNombreBanco = bancoBE.vNombreBanco;

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
                    pr1.Value = iBancoId;

                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iSucursalId")))
                            {
                                SucursalBE = new Sucursal();
                                SucursalBE.iSucursalId = drd.GetInt32(drd.GetOrdinal("iSucursalId"));
                                SucursalBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iBancoId"));
                                SucursalBE.vNombreBanco = drd.GetString(drd.GetOrdinal("vNombreBanco"));
                                SucursalBE.vNombre = drd.GetString(drd.GetOrdinal("vNombre"));
                                SucursalBE.vDireccion = drd.GetString(drd.GetOrdinal("vDireccion"));
                                SucursalBE.dFechaRegistro = drd.GetString(drd.GetOrdinal("dFechaRegistro"));
                                lstSucursal.Add(SucursalBE);
                            }
                        }
                    }
                }
            }
            SucursalesBE.SucursalList = lstSucursal.AsEnumerable();
            return lstSucursal.AsEnumerable();//SucursalesBE;
        }


    }
}
