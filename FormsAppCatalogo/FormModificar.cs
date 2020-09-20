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
            ArticuloNegocio negocio = new ArticuloNegocio();

            negocio.modificar();

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
