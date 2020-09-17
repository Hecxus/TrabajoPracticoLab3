using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

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
            comando.CommandText = "SELECT Nombre, ImagenUrl FROM ARTICULOS";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while(lector.Read())
            {
                Articulos aux = new Articulos();
                aux.Nombre = lector.GetString(0);
                aux.Imagen = (string)lector["ImagenUrl"];
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
            comando.CommandText = "INSERT INTO ARTICULOS (Nombre,Descripcion,IdMarca,IdCategoria ,Precio) VALUES ('" +nuevo.Nombre+"','"+nuevo.Descripcion+" ', ' "+nuevo.Precio +" ')";
            comando.Connection = conexion;

            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
