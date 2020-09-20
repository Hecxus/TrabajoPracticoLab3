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
        public FormModificar()
        {
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
            Articulos nuevo = new Articulos();
            ArticuloNegocio negocio = new ArticuloNegocio();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.marca = (Marca)cbxMarca.SelectedItem;
            nuevo.categoria = (Categoria)cbxCategoria.SelectedItem;
            nuevo.Precio = (float)nudPrecio.Value;  // El numericUpDown toma valor decimal, se transforma en flotante

            negocio.agregar(nuevo);

            Close();

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
