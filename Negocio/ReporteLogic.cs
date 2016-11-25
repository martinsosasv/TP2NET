using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;

namespace Negocio
{
    public class ReporteLogic
    {
        #region Constructor
        public ReporteLogic()
        {
            this.ReporteData = new DD.ReporteAdapter();
        }
        #endregion

        #region Propiedades
        DD.ReporteAdapter _reporteData;
        public DD.ReporteAdapter ReporteData
        {
            get { return _reporteData; }
            set { _reporteData = value; }
        }
        #endregion

        #region Métodos
        public List<ReportePlan> GetAllReportePlan()
        {
            return this.ReporteData.GetAllReportePlan();
        }

        public List<ReporteCurso> GetAllReporteCurso(int id_curso)
        {
            return this.ReporteData.GetAllReporteCurso(id_curso);
        }
        #endregion
    }
}
