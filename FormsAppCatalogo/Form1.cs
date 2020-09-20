﻿using System;
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
    public partial class CatalogoPrincipal : Form
    {
        public CatalogoPrincipal()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            //dgvLista.DataSource = negocio.listar();
            //dgvLista.Columns[0].Visible = false;

            lbArticulos.DataSource = negocio.listar();
        }

        private void lbArticulos_SelectedValueChanged(object sender, EventArgs e)
        {

            
            try
            {
                Articulos art = (Articulos)lbArticulos.SelectedItem;
            
                // Pone los datos en el detalle:

                if (art.Descripcion.Length > 1) // + el final de la cadena (en blanco !=NULL)
                    labelDescriptionValue.Text = art.Descripcion;
                else
                    labelDescriptionValue.Text = "Sin descripcion";
                
                labelCodArtValue.Text = art.codArticulo.ToString();

                labelCategoriaValue.Text = art.categoria.Descripcion;

                labelMarcaValue.Text = art.marca.Descripcion;

                pbArticulos.Load(art.Imagen);
            }
            catch (Exception)
            {

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAlta alta = new FormAlta();
            alta.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Desea eliminar este articulo?", "Eliminar articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ArticuloNegocio aritculoNegocio = new ArticuloNegocio();
                if (aritculoNegocio.Delete((Articulos)lbArticulos.SelectedItem))
                {
                    MessageBox.Show("El articulo fue borrado exitosamente.");
                }
                else
                {
                    MessageBox.Show("El articulo no pudo ser borrado.");
                }
            }
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormModificar modificar= new FormModificar((Articulos)lbArticulos.SelectedItem);
            modificar.ShowDialog();
            cargar();
        }
    }
}
