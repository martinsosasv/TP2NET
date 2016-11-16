using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : Entidades
    {
        string _nombreUsuario;
        string _clave;
        string _email;
        bool _habilitado;
        string _campoagregado;
        Personas _persona;
        
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        public Personas Persona
        {
            get
            {
                return _persona;
            }
            set
            {
                _persona = value;
            }
        }

        public int IdPersona
        {
            get
            {
                return this.Persona.ID;
            }
        }

        public string NombrePersona
        {
            get
            {
                return this.Persona.Nombre;
            }
        }

        public string ApellidoPersona
        {
            get
            {
                return this.Persona.Apellido;
            }
        }

        public string ApellidoNombrePersona
        {
            get { return _persona.ApellidoNombre; }
        }
    }
}
