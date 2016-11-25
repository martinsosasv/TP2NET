using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ReportePlan
    {
        #region Propiedades
        private string especialidad;
        public string Especialidad
        {
            get
            {
                return especialidad;
            }

            set
            {
                especialidad = value;
            }
        }

        private string plan;
        public string Plan
        {
            get
            {
                return plan;
            }

            set
            {
                plan = value;
            }
        }


        private string materia;
        public string Materia
        {
            get
            {
                return materia;
            }

            set
            {
                materia = value;
            }
        }
        #endregion
    }
}
