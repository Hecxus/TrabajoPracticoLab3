using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulos> lista = new List<Articulos>();
            
            conexion.ConnectionString = "data source = CAJS0718; initial catalog = CATALOGO_DB; integrated security = sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ARTICULOS.Nombre,MARCAS.Descripcion Narca, CATEGORIAS.Descripcion Categoria FROM ARTICULOS, CATEGORIAS, MARCAS WHERE ARTICULOS.IdCategoria = CATEGORIAS.Id AND ARTICULOS.IdMarca = MARCAS.Id ";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while(lector.Read())
            {
                Articulos aux = new Articulos();
                aux.ID = (int)lector["id"];

                aux.categoria = new Categoria();
                aux.categoria.Descripcion = (string)lector["categoria"];

                aux.marca = new Marca();
                aux.marca.Descripcion = (string)lector["marca"];


                try {aux.codArticulo = lector.GetString(1); 
                }catch (Exception E)
                {aux.codArticulo = "Sin codigo";}
                
                aux.Nombre = lector.GetString(2);

                try { aux.Descripcion = lector.GetString(3);
                }catch { aux.Descripcion = "Sin descripcion"; }
                
                //aux.cate = lector.GetInt32(4);
                //aux.codArticulo = lector.GetInt32(5);

                try
                {
                    aux.Imagen = (string)lector["ImagenUrl"];
                }
                catch (Exception E)
                {

                }
                lista.Add(aux);
            }
            lector.Close();
            conexion.Close();
            return lista;
        }

        public void agregar(Articulos nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source = CAJS0718; initial catalog = CATALOGO_DB; integrated security = sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO ARTICULOS(Nombre, Descripcion, IdMarca, IdCategoria, Precio) " + "VALUES('" + nuevo.Nombre + "', '" + nuevo.Descripcion + " ', " + nuevo.marca.ID + ", " + nuevo.categoria.ID + ", ' " + nuevo.Precio + " ')";
            
            comando.Connection = conexion;

            conexion.Open();
            comando.ExecuteNonQuery();
        }


        public bool Delete(Articulos articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            { 
                conexion.ConnectionString = "data source = CAJS0718; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = String.Format("delete from articulos where id = {0}",articulo.ID);
            
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }catch
            {
                return false;
            }
        }
    }
}
