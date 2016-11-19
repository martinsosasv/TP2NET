﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInscripcion : Entidades
    {
        string _condicion;
        int _nota;
        Personas _alumno;
        Curso _curso;

        public AlumnoInscripcion()
        {
            _condicion = "Cursando";
        }

        public string Condicion
        {
            get{ return _condicion; }

            set
            {
                if (_nota < 4)
                {
                    _condicion = "No aprobado";
                }
                else if (_nota >= 4)
                {
                    _condicion = "Aprobado";
                }
            }
        }

        public Personas Alumno
        {
            get {  return _alumno; }

            set { _alumno = value; }
        }

        public Curso Curso
        {
            get { return _curso; }
            set { _curso = value; }
        }

        public int Nota
        {
            get
            {
                return _nota;
            }
            set
            {
                _nota = value;
            }
        }
    }
}
