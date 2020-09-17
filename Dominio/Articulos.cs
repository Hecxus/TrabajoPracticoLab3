using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Articulos
    {
        private int codArticulo;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Catgoria { get; set; }
        public string Imagen { get; set; }
        public float Precio { get; set; }
        public  Categoria categoria { get; set; }
        public Marca marca { get; set; }
        
    }
    
}
