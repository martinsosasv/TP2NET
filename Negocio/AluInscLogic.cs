using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;

namespace Negocio
{
    public class AluInscLogic
    {
        DD.AlumnoInscripcionAdapter _aluInscData;
        public DD.AlumnoInscripcionAdapter AluInscData
        {
            get { return _aluInscData; }
            set { _aluInscData = value; }
        }
        public AluInscLogic()
        {
            this.AluInscData = new DD.AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return this.AluInscData.GetAll();
        }

        public List<AlumnoInscripcion> GetInscripcionesCurso(int idCurso)
        {
            return this.AluInscData.GetInscripcionesCurso(idCurso);
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumno(int IDAlumno)
        {
            return this.AluInscData.GetInscripcionesAlumno(IDAlumno);
        }

        public void Delete(AlumnoInscripcion aluInsc)
        {
            this.AluInscData.Delete(aluInsc);
        }

        public void Insert(AlumnoInscripcion aluInsc)
        {
            this.AluInscData.Insert(aluInsc);
        }

        public void Update(AlumnoInscripcion aluInsc)
        {
            this.AluInscData.Update(aluInsc);
        }
    }
}
