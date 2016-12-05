using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Docente_Curso : Entidades
    {
        #region Propiedades
        private Persona _docente;
        public Persona Docente
        {
            get { return _docente; }
            set { _docente = value; }
        }

        private Curso _curso;
        public Curso Curso
        {
            get { return _curso; }
            set { _curso = value; }
        }

        public enum TipoCargo
        {
            Titular=1, Auxiliar=2, JefeTPs=3
        }

        private TipoCargo _tipoCargo;
        public TipoCargo Cargo
        {
            get { return _tipoCargo; }
            set { _tipoCargo = value; }
        }

        public string DescCurso
        {
            get { return _curso.DescMateriaComision; }
        }

        public string DescDocente
        {
            get { return _docente.ApellidoNombre; }
        }
        
        public int IdDocente
        {
            get { return _docente.ID; }            
        }
        
        public int IdCurso
        {
            get { return _curso.ID; }
        }
        #endregion
    }
}
