using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensayo2
{
    public partial class Form1 : Form
    {
        ensayoEntities2 db = new ensayoEntities2();
        prueba prueba = new prueba();
        int idRegistro = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.pruebas.ToList<prueba>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            prueba.cmpTexto = txtText.Text;
            prueba.cmpFecha = dtpDate.Value;
            prueba.cmpNumero = Convert.ToDecimal(txtNumber.Text);
            if (prueba.cmpTexto != "" && prueba.cmpFecha != null)
            {
                db.pruebas.Add(prueba);
            }
            db.SaveChanges();
            MessageBox.Show("Record Save Successfully");
            Limpiar();
            dataGridView1.DataSource = db.pruebas.ToList<prueba>();
        }
        public void Limpiar()
        {
            txtNumber.Text = txtText.Text = string.Empty;
            idRegistro = 0;
            btnInsertar.Enabled = true;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != -1)
            {
                idRegistro = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                prueba = db.pruebas.Where(x=>x.idPrueba==idRegistro).FirstOrDefault();
                txtNumber.Text = prueba.cmpNumero.ToString();
                txtText.Text = prueba.cmpTexto;
                dtpDate.Value =Convert.ToDateTime(prueba.cmpFecha);
                btnInsertar.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prueba.cmpTexto = txtText.Text;
            prueba.cmpFecha = dtpDate.Value;
            prueba.cmpNumero = Convert.ToDecimal(txtNumber.Text);
            if (prueba.cmpTexto != "" && prueba.cmpFecha != null)
            {
                db.Entry(prueba).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            MessageBox.Show("Record Save Successfully");
            Limpiar();
            dataGridView1.DataSource = db.pruebas.ToList<prueba>();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quiere eliminar?", "eliminar", MessageBoxButtons.YesNo);
            if(respuesta == DialogResult.Yes)
            {
                db.pruebas.Remove(prueba);
                db.SaveChanges();
                Limpiar();
                dataGridView1.DataSource = db.pruebas.ToList<prueba>();
                MessageBox.Show("Record Deleted Successfully");

            }

        }
    }
}
