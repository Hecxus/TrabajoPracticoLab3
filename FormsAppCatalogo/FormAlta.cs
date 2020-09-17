using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace FormsAppCatalogo
{
    public partial class FormAlta : Form
    {
        public FormAlta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulos nuevo = new Articulos();
            ArticuloNegocio negocio = new ArticuloNegocio();

            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            //nuevo.Precio = txtPrecio.Text; -- como asignar a la variable precio?

            negocio.agregar(nuevo);

            Close();
        }

        private void keyPrecio(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void FormAlta_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cbxMarca.DataSource = marcaNegocio.listar();

           
        }
    }
}
