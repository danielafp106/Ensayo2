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
    public partial class Form2 : Form
    {
        ensayoEntities2 db = new ensayoEntities2();
        prueba prueba = new prueba();
        public Form2()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            prueba.cmpTexto = txtText.Text;
            prueba.cmpFecha = dtpDate.Value;
            prueba.cmpNumero = Convert.ToDecimal(txtNumber.Text);
            if(prueba.cmpTexto!=""&&prueba.cmpFecha!=null)
            {
                db.pruebas.Add(prueba);
            }
            db.SaveChanges();
            MessageBox.Show("Record Save Successfully");
            Limpiar();
            this.Close();


        }

        public void Limpiar()
        {
            txtNumber.Text = txtText.Text = string.Empty;
        }
    }
}
