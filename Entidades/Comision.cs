using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision : Entidades
    {
        int _anioEspecialidad;
        string _descripcion;
        Plan _plan;

        public int AnioEspecialidad
        {
            get { return _anioEspecialidad; }
            set { _anioEspecialidad = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Plan Plan
        {
            get { return _plan; }
            set { _plan = value; }
        }

        public string PlanDescripcion
        {
            get { return _plan.Descripcion; }
        }

        public string DescripcionEspecPlan
        {
            get { return this.Plan.DescripcionEspecialidad; }
        }

        public string DescComPlanEsp
        {
            get { return this.Descripcion + "-" + this.DescripcionEspecPlan + " " + this.PlanDescripcion; }
        }
    }
}
