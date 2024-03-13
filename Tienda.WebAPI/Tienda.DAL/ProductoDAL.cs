using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tienda.WebAPI.Contratos;
using Tienda.WebAPI.Tienda.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tienda.WebAPI.Tienda.DAL
{
    public class ProductoDAL : IProducto
    {
        string dbconexion;

        public ProductoDAL()
        {
            dbconexion = ConfigurationManager.ConnectionStrings["ConectaProductos"].ConnectionString;
        }
        public async Task<List<Producto>> ObtenerProductoPorNombre(string nombre)
        {
            List<Producto> ListProductos = new List<Producto>();

            using(SqlConnection con = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductoPorNombre", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProducto", nombre);

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            ListProductos.Add(new Producto
                            {
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                CostoUnitario = Convert.ToDouble(sdr["CostoUnitario"]),
                                PMayoreo = Convert.ToDouble(sdr["PMayoreo"]),
                                PMenudeo = Convert.ToDouble(sdr["PMenudeo"]),
                                Existencia = Convert.ToInt16(sdr["Existencia"]),
                            });
                        }
                        con.Close();
                    }
                    else
                    {
                        ListProductos = null;
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
                return (ListProductos);
            }
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            List<Producto> ListProductos = new List<Producto>();

            using (SqlConnection con = new SqlConnection(dbconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerProductos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await con.OpenAsync();
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                    if (sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            ListProductos.Add(new Producto
                            {
                                ProductoId = Convert.ToInt16(sdr["Productoid"]),
                                Nombre = sdr["Nombre"].ToString(),
                                Presentacion = sdr["Presentacion"].ToString(),
                                CostoUnitario = Convert.ToDouble(sdr["CostoUnitario"]),
                                PMayoreo = Convert.ToDouble(sdr["PMayoreo"]),
                                PMenudeo = Convert.ToDouble(sdr["PMenudeo"]),
                                Existencia = Convert.ToInt16(sdr["Existencia"]),
                                ImagenPath = sdr["ImagenPath"].ToString()
                            });
                        }
                        con.Close();
                    }
                    else
                    {
                        ListProductos = null;
                    }
                }
                catch
                {
                    con.Close();
                }
                return (ListProductos);
            }
        }
    }
}