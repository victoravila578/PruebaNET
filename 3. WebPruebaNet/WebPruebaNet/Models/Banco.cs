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
    public class Banco
    {


        public int iBancoId { get; set; }
        public string vNombreBanco { get; set; }
        public string vDireccion { get; set; }
        public string dFechaRegistro { get; set; }

        public IEnumerable getAll()
        {
            var lstbanco = new List<Banco>();
            var bancoBE = new Banco();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_listarBancos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        while (drd.Read())
                        {
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iBancoId")))
                            {
                                bancoBE = new Banco();
                                bancoBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iBancoId"));
                                bancoBE.vNombreBanco = drd.GetString(drd.GetOrdinal("vNombreBanco"));
                                bancoBE.vDireccion = drd.GetString(drd.GetOrdinal("vDireccion"));
                                bancoBE.dFechaRegistro = drd.GetString(drd.GetOrdinal("dFechaRegistro"));
                                lstbanco.Add(bancoBE);
                            }
                        }
                    }
                }
            }
            return lstbanco.AsEnumerable();
        }

        public Banco obtenerBanco(int iBancoId)
        {
            var bancoBE = new Banco();
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerBanco", con))
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
                            if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("iBancoId")))
                            {
                                bancoBE = new Banco();
                                bancoBE.iBancoId = drd.GetInt32(drd.GetOrdinal("iBancoId"));
                                bancoBE.vNombreBanco = drd.GetString(drd.GetOrdinal("vNombreBanco"));
                                bancoBE.vDireccion = drd.GetString(drd.GetOrdinal("vDireccion"));
                                bancoBE.dFechaRegistro = drd.GetString(drd.GetOrdinal("dFechaRegistro"));
                            }
                        }
                    }
                }
            }
            return bancoBE;
        }

        public int insertarBanco(Banco BancoBE)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertBanco", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pr2 = cmd.Parameters.Add("@vNombreBanco", SqlDbType.VarChar);
                    pr2.Value = BancoBE.vNombreBanco;

                    SqlParameter pr3 = cmd.Parameters.Add("@vDireccion", SqlDbType.VarChar);
                    pr3.Value = BancoBE.vDireccion;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Edit(Banco BancoBE)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_updateBanco", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iBancoId", SqlDbType.Int);
                    pr1.Value = BancoBE.iBancoId;

                    SqlParameter pr2 = cmd.Parameters.Add("@vNombreBanco", SqlDbType.VarChar);
                    pr2.Value = BancoBE.vNombreBanco;

                    SqlParameter pr3 = cmd.Parameters.Add("@vDireccion", SqlDbType.VarChar);
                    pr3.Value = BancoBE.vDireccion;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }

        public int eliminarBanco(int iBancoId)
        {
            var result = 0;
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            using (SqlConnection con = new SqlConnection(connectionStringConfig.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_deleteBanco", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr1 = cmd.Parameters.Add("@iBancoId", SqlDbType.Int);
                    pr1.Value = iBancoId;

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
    }
}
