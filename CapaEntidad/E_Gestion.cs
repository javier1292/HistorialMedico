using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Gestion
    {
        private int id;
        private string Nombre;
        private string Apellido;
        private string TipoSangre;
        private string Correo;
        private string Telefono;
        private string ContactoEmergencia;

        public int Id { get => id; set => id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public string TipoSangre1 { get => TipoSangre; set => TipoSangre = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string ContactoEmergencia1 { get => ContactoEmergencia; set => ContactoEmergencia = value; }
    }

    public class E_Gestion2
    {
        private int idp;
        private string motivo;
        private DateTime fecha;
        private string sintomas;
        private string tratamiento;

        public int Idp { get => idp; set => idp = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Sintomas { get => sintomas; set => sintomas = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
    }
}
