using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;

namespace Negocio
{
    public class Docente_CursoLogic : Negocio
    {
        public Docente_CursoLogic()
        {
            this.DocCurData = new DD.Docente_CursoAdapter();
        }

        DD.Docente_CursoAdapter _docCurData;
        public DD.Docente_CursoAdapter DocCurData
        {
            get { return _docCurData; }
            set { _docCurData = value; }
        }
        public Docente_Curso GetOne(int idDoc, int idCur)
        {
            return this.DocCurData.GetOne(idDoc, idCur);
        }

        public List<Docente_Curso> GetAll()
        {
            return this.DocCurData.GetAll();
        }

        public List<Docente_Curso> GetAll(int id_docente)
        {
            return this.DocCurData.GetAll(id_docente);
        }

        public void Insert(Docente_Curso docenteCurso)
        {
            this.DocCurData.Insert(docenteCurso);
        }

        public void Update(Docente_Curso docenteCurso)
        {
            this.DocCurData.Update(docenteCurso);
        }


        public void Delete(Docente_Curso docenteCurso)
        {
            this.DocCurData.Delete(docenteCurso);
        }
    }
}
