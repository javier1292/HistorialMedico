using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class VerHistorial : Form
    {
        int idp;
        public VerHistorial(int _idp)
        {
            this.idp = _idp;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void mostrarBuscartabla(int id)
        {
            N_Pro objNegocio = new N_Pro();
            dataGridView1.DataSource = objNegocio.listarHistorial(id);

        }
        private void VerHistorial_Load(object sender, EventArgs e)
        {
            mostrarBuscartabla(idp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 cc = new Form1();
            cc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                AgregarHistorial cc = new AgregarHistorial(idp);
                cc.Show();
                this.Hide();

     
   
        }
    }
}
