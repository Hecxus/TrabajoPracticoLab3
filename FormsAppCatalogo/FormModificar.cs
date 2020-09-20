using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppCatalogo
{
    public partial class FormModificar : Form
    {
        Articulos articulo;
        public FormModificar(Articulos _articulo)
        {
            articulo = _articulo;
            InitializeComponent();

        }

        private void FormModificar_Load(object sender, EventArgs e)
        {

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            cbxMarca.DataSource = marcaNegocio.listar();
            cbxMarca.ValueMember = "Id";
            cbxMarca.DisplayMember = "Descripcion";

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cbxCategoria.DataSource = categoriaNegocio.listar();
            //cbxCategoria.ValueMember = "Id";
            cbxCategoria.DisplayMember = "Descripcion";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulos artTemporal = new Articulos();

            artTemporal.ID = articulo.ID;
            artTemporal.Nombre = txtNombre.Text;
            artTemporal.Descripcion = txtDescripcion.Text;
            artTemporal.categoria = new Categoria();
            artTemporal.categoria.ID = ((Categoria)cbxCategoria.SelectedItem).ID;

            artTemporal.marca = new Marca();
            artTemporal.marca.ID = ((Marca)cbxMarca.SelectedItem).ID;

            artTemporal.Precio = (float)nudPrecio.Value;

            if (negocio.modificar(artTemporal))
            {
                MessageBox.Show("Articulo modificado correctamente.");
                Close();
            }
            else
            {
                MessageBox.Show("El articulo no pudo ser modificado.");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
