using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Marca> lista = new List<Marca>();

            conexion.ConnectionString = "data source = CAJS0718; initial catalog = CATALOGO_DB; integrated security = sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT Id, Descripcion FROM MARCAS";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Marca aux = new Marca();
                aux.ID = lector.GetInt32(0);
                aux.Descripcion = lector.GetString(1);

                lista.Add(aux);
            }
            lector.Close();
            conexion.Close();
            return lista;
        }
    }
}
