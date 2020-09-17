using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
namespace FormsAppCatalogo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvLista.DataSource = negocio.listar();
            dgvLista.Columns[3].Visible = false;
            dgvLista.Columns[2].Visible = false;
            dgvLista.Columns[4].Visible = false;
            dgvLista.Columns[5].Visible = false;
            dgvLista.Columns[6].Visible = false;
            dgvLista.Columns[1].Visible = false;
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulos art = (Articulos)dgvLista.CurrentRow.DataBoundItem;
                pbArticulos.Load(art.Imagen);
            }
            catch(Exception) 
            {
            
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAlta alta = new FormAlta();
            alta.ShowDialog();
        }
    }
}
