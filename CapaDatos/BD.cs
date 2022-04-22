using CapaEntidad;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class BD
    {
        public string stock;
        public string precio;
        public bool acceso;
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        public SqlConnection Conexion = new SqlConnection("server=LAPTOP-Q17S4LT4\\SQLEXPRESS ; database=GestionH; integrated security = true");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }


        //Crud de Pacientes
        public List<E_Gestion> Listarp(string buscar){


            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("BuscarPacientes", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            AbrirConexion();

            cmd.Parameters.AddWithValue("@idp", buscar);
            leerfilas = cmd.ExecuteReader();

            List<E_Gestion> listar = new List<E_Gestion>();
            while (leerfilas.Read())
            {
                listar.Add(new E_Gestion
                {
                    Id = leerfilas.GetInt32(0),
                    Nombre1 = leerfilas.GetString(1),
                    Apellido1 = leerfilas.GetString(2), 
                    TipoSangre1 = leerfilas.GetString(3),
                    Correo1 = leerfilas.GetString(4),
                    Telefono1 = leerfilas.GetString(5),
                    ContactoEmergencia1 = leerfilas.GetString(6),



                });
            }
            CerrarConexion();
            leerfilas.Close();
            return listar;

        }

        public void InsertarP(E_Gestion InsertarP)
        {




            comando.Connection = AbrirConexion();
            comando.CommandText = "InsertarPacientes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", InsertarP.Nombre1);
            comando.Parameters.AddWithValue("@apellido", InsertarP.Apellido1);
            comando.Parameters.AddWithValue("@tiposangre", InsertarP.TipoSangre1);
            comando.Parameters.AddWithValue("@correo", InsertarP.Correo1);
            comando.Parameters.AddWithValue("@telefono", InsertarP.Telefono1);
            comando.Parameters.AddWithValue("@contactoemergencia", InsertarP.ContactoEmergencia1);




            comando.ExecuteNonQuery();
            comando.Parameters.Clear();




        }

        public void Editarp(E_Gestion editpro)
        {
            SqlCommand cmd = new SqlCommand("EditarPaciente", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            AbrirConexion();

            cmd.Parameters.AddWithValue("@idp", editpro.Id);
            cmd.Parameters.AddWithValue("@nombre", editpro.Nombre1);
            cmd.Parameters.AddWithValue("@apellido", editpro.Apellido1);
            cmd.Parameters.AddWithValue("@tiposangre", editpro.TipoSangre1);
            cmd.Parameters.AddWithValue("@correo", editpro.Correo1);
            cmd.Parameters.AddWithValue("@telefono", editpro.Telefono1);
            cmd.Parameters.AddWithValue("@contactoemergencia", editpro.ContactoEmergencia1);



            cmd.ExecuteNonQuery();
            CerrarConexion();
        }

        public void Eliminarp(E_Gestion eliminar)
        {
            SqlCommand cmd = new SqlCommand("EliminarPaciente", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            AbrirConexion();

            cmd.Parameters.AddWithValue("@idp", eliminar.Id);


            cmd.ExecuteNonQuery();
            CerrarConexion();
        }

        public DataTable MostrarP()
        {
            comando.Connection = AbrirConexion();
            comando.CommandText = "select * from Pacientes";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CerrarConexion();
            return tabla;


        }


        //Fin del crud pacientes 

        //crud historial medico

        public List<E_Gestion2> ListarH(int id)
        {


            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("Buscar", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            AbrirConexion();

            cmd.Parameters.AddWithValue("@idp", id);
            leerfilas = cmd.ExecuteReader();

            List<E_Gestion2> listar = new List<E_Gestion2>();
            while (leerfilas.Read())
            {
                listar.Add(new E_Gestion2
                {
                    Idp = leerfilas.GetInt32(1),
                    Motivo = leerfilas.GetString(2),
                    Fecha = leerfilas.GetDateTime(3),
                    Sintomas = leerfilas.GetString(4),
                    Tratamiento = leerfilas.GetString(5),
                  



                });
            }
            CerrarConexion();
            leerfilas.Close();
            return listar;

        }

        public void InsertarH(E_Gestion2 InsertarP)
        {




            comando.Connection = AbrirConexion();
            comando.CommandText = "InsertarHistorial";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idp", InsertarP.Idp);
            comando.Parameters.AddWithValue("@motivo", InsertarP.Motivo);
            comando.Parameters.AddWithValue("@fecha", InsertarP.Fecha);
            comando.Parameters.AddWithValue("@sintomas", InsertarP.Sintomas);
            comando.Parameters.AddWithValue("@tratamiento", InsertarP.Tratamiento);





            comando.ExecuteNonQuery();
            comando.Parameters.Clear();




        }
        //fin curd historial
    }
}
