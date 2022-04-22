using CapaEntidad;
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
    public partial class AgregarHistorial : Form
    {
        int id;
        public AgregarHistorial(int _id)
        {
            this.id = _id; 
            InitializeComponent();
        }
        E_Gestion2 objen = new E_Gestion2();
         N_Pro objent = new N_Pro();
        private void AgregarHistorial_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                objen.Idp = id;
                objen.Motivo = textBox1.Text;
                objen.Fecha = DateTime.Now;
                objen.Sintomas = textBox2.Text;
                objen.Tratamiento = textBox3.Text;


                objent.insertarHistorial(objen);
                MessageBox.Show("Se agrego correctamente  ");

                VerHistorial cc = new VerHistorial(id);
                cc.Show();
                Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar el producto  " + ex);
            }
        }
    }
}
