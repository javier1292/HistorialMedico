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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool vai = false;
        N_Pro objent = new N_Pro();
        private string idp;
        private bool editarse = false;
        E_Gestion objen = new E_Gestion();

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        public void mostrarBuscartabla(string buscar)
        {
            N_Pro objNegocio = new N_Pro();
            dataGridView1.DataSource = objNegocio.listarPacientes(buscar);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarBuscartabla("");
            MostrarPacientes();
        }
        public void MostrarPacientes()
        {
            N_Pro objNegocio = new N_Pro();
            dataGridView1.DataSource = objNegocio.MostrarP();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarPaciente cc = new AgregarPaciente(0,false);
            cc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Quieres eliminar este paciente ", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objen.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    objent.EliminarP(objen);


                    MessageBox.Show("se elimino el Paciente");
                    MostrarPacientes();

                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("seleccione la fila que desea eliminar");
            }

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
             if (dataGridView1.SelectedRows.Count > 0)
            {
                AgregarPaciente cc = new AgregarPaciente(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString()), true);
                cc.Show();
                this.Hide();

                //cc. = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //txt2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //txt3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //textBox1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("seleccione la fila que desea editar ");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                VerHistorial cc = new VerHistorial(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                cc.Show();
                this.Hide();

                //cc. = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //txt2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //txt3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //textBox1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("seleccione la fila ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
