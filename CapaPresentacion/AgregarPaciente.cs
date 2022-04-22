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
    public partial class AgregarPaciente : Form
    {
        public int ID;
        public bool isEdit;
        public AgregarPaciente(int _id, bool _estado)
        {
            this.ID = _id;
            this.isEdit = _estado;
            InitializeComponent();
        }

        bool vai = false;
        N_Pro objent = new N_Pro();
        private bool editarse = false;
        E_Gestion objen = new E_Gestion();


        private void AgregarPaciente_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
            loadData();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
                
            }
            else
            {

            }
                
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                try
                {

                    objen.Nombre1 = textBox1.Text;
                    objen.Apellido1 = textBox2.Text;
                    objen.TipoSangre1 = textBox3.Text;
                    objen.Correo1 = textBox4.Text;
                    objen.Telefono1 = textBox5.Text;
                    objen.ContactoEmergencia1 = textBox6.Text;

                    objent.insertarP(objen);
                    MessageBox.Show("Se agrego correctamente  ");

                    Form1 cc = new Form1();
                    cc.Show();
                    Close();
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar el producto  " + ex);
                }

            }
            if (isEdit == true)
            {
                try
                {
                    objen.Id= Convert.ToInt32(this.ID);
                    objen.Nombre1 = textBox1.Text;
                    objen.Apellido1 = textBox2.Text;
                    objen.TipoSangre1 = textBox3.Text;
                    objen.Correo1 = textBox4.Text;
                    objen.Telefono1 = textBox5.Text;
                    objen.ContactoEmergencia1 = textBox6.Text;



                    objent.EditarP(objen);
                    

                    MessageBox.Show("se edito correctamente");
                    editarse = false;
                    Form1 cc = new Form1();
                    cc.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos   " + ex);
                }
            }

        }


        private void loadData()
        {
          List<E_Gestion>  list = objent.listarPacientes(Convert.ToString(this.ID));
            textBox1.Text = list[0].Nombre1;
            textBox2.Text = list[0].Apellido1;
            textBox3.Text = list[0].TipoSangre1;
            textBox4.Text = list[0].Correo1;
            textBox5.Text = list[0].Telefono1;
            textBox6.Text = list[0].ContactoEmergencia1;
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
