using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan : Entidades
    {
        string _descripcion;
        Especialidad _especialidad;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }
        public Especialidad Especialidad
        {
            get
            {
                return _especialidad;
            }
            set
            {
                _especialidad = value;
            }
        }

        public string DescripcionEspecialidad
        {
            get { return Especialidad.Descripcion; }
        }

        public string DescripcionEspPlan
        {
            get {
                string espPlan = DescripcionEspecialidad + " - " + Descripcion;
                return espPlan;
            }
        }
    }
}
