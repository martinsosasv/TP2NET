using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personas : Entidades
    {
        int _idPersona;
        string _apellido;
        string _direccion;
        string _email;
        DateTime _fechaNacimiento;
        Plan _plan;
        int _idLegajo;
        string _nombre;
        string _telefono;
        TiposPersonas _tipoPersona;

        public int ID
        {
            get
            {
                return _idPersona;
            }
            set
            {
                _idPersona = value;
            }
        }

        public string Apellido
        {
            get{ return _apellido ;}
            set { _apellido = value;}
        }

        public string Direccion
        {
            get{ return _direccion ;}
            set { _direccion = value;}
        }

        public string Email
        {
            get{ return _email ;}
            set {_email = value;}
        }
        
        public DateTime FechaNacimiento
        {
            get{ return _fechaNacimiento ;}
            set { _fechaNacimiento = value;}
        }

        public Plan Plan
        {
            get{ return _plan ;}
            set { _plan = value;}
        }

        public int IdLegajo
        {
            get{ return _idLegajo ;}
            set { _idLegajo = value;}
        }

        public string Nombre
        {
            get{ return _nombre ;}
            set { _nombre = value;}
        }

        public string Telefono
        {
            get{ return _telefono ;}
            set { _telefono = value;}
        }

        public TiposPersonas TipoPersona
        {
            get{ return _tipoPersona ;}
            set { _tipoPersona = value;}
        }

        public enum TiposPersonas
        {
            Administrador=1, Docente, Alumno
        }

        public string ApellidoNombre
        {
            get
            {
                return _apellido + " " + _nombre;
            }
        }
    
    }

}
