using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocios;
using Entidades;

namespace agenda
{
    public partial class Form1 : Form
    {
        Mantenimiento mantenimiento = new Mantenimiento();
        Contacto contacto = new Contacto();

        public Form1()
        {
            InitializeComponent();
        }

        void Operaciones(string op)
        {

            contacto.Nombre = txtNombre.Text;
            contacto.Telefono = txtTelefono.Text;
            contacto.Email = txtEmail.Text;

            switch (op)
            {
                case "Agregar":
                    mantenimiento.AgregarContacto(contacto);
                    LimpiarCampos();
                    Notificaciones("Contacto agregado exitosamente.", "Éxito");
                    break;
                case "Actualizar":
                    contacto.ID = Convert.ToInt32(txtID.Text);
                    mantenimiento.ActualizarContacto(contacto);
                    LimpiarCampos();
                    Notificaciones("Contacto actualizado exitosamente.", "Éxito");
                    break;
                case "Eliminar":
                    int id = Convert.ToInt32(txtID.Text);
                    DialogResult result = MessageBox.Show(
                        "¿Está seguro que desea eliminar este registro?",   // contenido
                        "Confirmación",                                     // título
                        MessageBoxButtons.YesNo,                            // botones
                        MessageBoxIcon.Question                             // ícono
                    );
                    if (result == DialogResult.Yes)
                    {
                        mantenimiento.EliminarContacto(id);
                        LimpiarCampos();
                        Notificaciones("Contacto eliminado exitosamente.", "Éxito");
                    }

                    break;
            }

         
        }

        private void LlenarTabla()
        {
            dataGridView1.DataSource = mantenimiento.ObtenerContactos();
        }

        private void Notificaciones(string contenido, string titulo)
        {

            MessageBox.Show(contenido, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            LlenarTabla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Operaciones("Agregar");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Seleccione un contacto para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Operaciones("Actualizar");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Seleccione un contacto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Operaciones("Eliminar");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                LlenarTabla();

            }
            else
            {
                dataGridView1.DataSource = mantenimiento.BuscarContacto(textBox5.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                txtID.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                txtTelefono.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[fila].Cells[3].Value.ToString();
            }

        }
    }
}
