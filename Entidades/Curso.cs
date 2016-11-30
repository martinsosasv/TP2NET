using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso : Entidades
    {
        int _anioCalendario, _cupo;// _idComision, _idMateria;
        Materia _materia;
        Comision _comision;
        

        public int AnioCalendario
        {
            get
            {
                return _anioCalendario;
            }
            set
            {
                _anioCalendario = value;
            }
        }

        public int Cupo
        {
            get
            {
                return _cupo;
            }
            set
            {
                _cupo = value;
            }
        }

        public Comision Comision
        {
            get
            {
                return _comision;
            }
            set
            {
                _comision = value;
            }
        }

        public Materia Materia
        {
            get
            {
                return _materia;
            }
            set
            {
                _materia = value;
            }
        }

        public string DescMateria
        {
            get { return _materia.Descripcion; }
        }

        public string DescComision
        {
            get { return _comision.Descripcion; }
        }

        public string DescPlanEsp
        {
            get { return _materia.Plan.DescripcionEspPlan; }
        }

        public string DescMateriaComision
        {
            get { return _materia.Descripcion + "-" + _comision.Descripcion; }
        }
    }
}
