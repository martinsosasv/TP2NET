using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    
    public class ReporteAdapter : Adapter
    {
        #region Métodos
        public List<ReportePlan> GetAllReportePlan()
        {
            List<ReportePlan> listadoReportePlan = new List<ReportePlan>();
            
            try
            {
                this.OpenConnection();
                SqlCommand consulta = new SqlCommand("SELECT especialidades.desc_especialidad, planes.desc_plan, materias.desc_materia FROM planes INNER JOIN especialidades on planes.id_especialidad = especialidades.id_especialidad INNER JOIN materias on materias.id_plan = planes.id_plan ORDER BY planes.desc_plan, especialidades.desc_especialidad, materias.desc_materia", SqlConn);
                SqlDataReader drConsulta = consulta.ExecuteReader();
                while (drConsulta.Read())
                {
                    ReportePlan rep = new ReportePlan();
                    rep.Especialidad = drConsulta.IsDBNull(0) ? string.Empty : drConsulta[0].ToString();
                    rep.Plan = drConsulta.IsDBNull(1) ? string.Empty : drConsulta[1].ToString();
                    rep.Materia = drConsulta.IsDBNull(2) ? string.Empty : drConsulta[2].ToString();

                    listadoReportePlan.Add(rep);
                }
                return listadoReportePlan;

            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al tratar de abrir la conexion", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public List<ReporteCurso> GetAllReporteCurso(int id_curso)
        {
            List<ReporteCurso> listadoReporteCurso = new List<ReporteCurso>();
            

            try
            {
                this.OpenConnection();
                SqlCommand consulta = new SqlCommand("SELECT personas.legajo, personas.apellido, personas.nombre, alumnos_inscripciones.condicion FROM alumnos_inscripciones INNER JOIN personas on personas.id_persona = alumnos_inscripciones.id_alumno WHERE id_curso = @id_curso ORDER BY personas.legajo, personas.apellido, personas.nombre, alumnos_inscripciones.condicion", SqlConn);
                consulta.Parameters.AddWithValue("@id_curso", id_curso);
                SqlDataReader drConsulta = consulta.ExecuteReader();
                while (drConsulta.Read())
                {
                    ReporteCurso rep = new ReporteCurso();
                    rep.Legajo = drConsulta.IsDBNull(0) ? 0 : Convert.ToInt32(drConsulta[0]);
                    rep.Apellido = drConsulta.IsDBNull(1) ? string.Empty : drConsulta[1].ToString();
                    rep.Nombre = drConsulta.IsDBNull(2) ? string.Empty : drConsulta[2].ToString();
                    rep.Condicion = drConsulta.IsDBNull(3) ? string.Empty : drConsulta[3].ToString();

                    listadoReporteCurso.Add(rep);
                }
                return listadoReporteCurso;

            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al tratar de abrir la conexion", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    #endregion
    }
}
