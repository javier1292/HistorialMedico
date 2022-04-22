using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Pro
    {
        BD objdato = new BD();

        //crud Inventario
        public void insertarP(E_Gestion insertarpro)
        {
            objdato.InsertarP(insertarpro);
        }

        public void EditarP(E_Gestion editpro)
        {
            objdato.Editarp(editpro);
        }



        public void EliminarP(E_Gestion eliminarP)
        {
            objdato.Eliminarp(eliminarP);
        }

        

        public List<E_Gestion> listarPacientes(string buscar)
        {
            return objdato.Listarp(buscar);
        }

        public DataTable MostrarP()
        {

            DataTable tabla = new DataTable();
            tabla = objdato.MostrarP();
            return tabla;
        }

        //crud Inventario fin

        //crud historial

        public List<E_Gestion2> listarHistorial(int id)
        {
            return objdato.ListarH(id);
        }

        public void insertarHistorial(E_Gestion2 insertarHistorial)
        {
            objdato.InsertarH(insertarHistorial);
        }

        //fin crud historial

    }
}
