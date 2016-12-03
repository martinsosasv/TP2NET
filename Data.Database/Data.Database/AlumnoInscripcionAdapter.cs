using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {

        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("SELECT id_inscripcion,id_alumno,id_curso,condicion,nota FROM alumnos_inscripciones", SqlConn);
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();
                while (drAlumnoInscripciones.Read())
                {
                    AlumnoInscripcion aluIns = new AlumnoInscripcion();

                    Persona per = new Persona();
                    Curso cur = new Curso();

                    PersonaAdapter perAda = new PersonaAdapter();
                    CursoAdapter curAda = new CursoAdapter();

                    per = perAda.GetOne(Convert.ToInt32(drAlumnoInscripciones["id_alumno"]));
                    cur = curAda.GetOne(Convert.ToInt32(drAlumnoInscripciones["id_curso"]));

                    aluIns.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    aluIns.Alumno = drAlumnoInscripciones.IsDBNull(1) ? null : per;
                    aluIns.Curso = drAlumnoInscripciones.IsDBNull(2) ? null : cur;
                    aluIns.Condicion = (string)drAlumnoInscripciones["condicion"];
                    aluIns.Nota = (int)drAlumnoInscripciones["nota"];
                    
                    alumnos.Add(aluIns);
                }

                drAlumnoInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos inscriptos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }


        public List<AlumnoInscripcion> GetInscripcionesCurso(int IDCurso)
        {
            List<AlumnoInscripcion> inscripcionesCursos = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDatosCurso = new SqlCommand("SELECT id_inscripcion,id_alumno,id_curso,condicion,nota FROM alumnos_inscripciones WHERE id_curso = @id_curso", SqlConn);
                cmdDatosCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;
                SqlDataReader drDatosCurso = cmdDatosCurso.ExecuteReader();
                if (drDatosCurso.Read())
                {
                    AlumnoInscripcion aluCurso = new AlumnoInscripcion();

                    Persona per = new Persona();
                    Curso cur = new Curso();

                    PersonaAdapter perAda = new PersonaAdapter();
                    CursoAdapter curAda = new CursoAdapter();

                    per = perAda.GetOne(Convert.ToInt32(drDatosCurso["id_alumno"]));
                    cur = curAda.GetOne(Convert.ToInt32(drDatosCurso["id_curso"]));

                    aluCurso.ID = (int)drDatosCurso["id_inscripcion"];
                    aluCurso.Alumno = drDatosCurso.IsDBNull(1) ? null : per;
                    aluCurso.Curso = drDatosCurso.IsDBNull(2) ? null : cur;
                    aluCurso.Condicion = (string)drDatosCurso["condicion"];
                    aluCurso.Nota = (int)drDatosCurso["nota"];

                    inscripcionesCursos.Add(aluCurso);
                }

                drDatosCurso.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripciones curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripcionesCursos;
        }

        public List<AlumnoInscripcion> GetInscripcionesAlumno(int IDAlumno)
        {
            List<AlumnoInscripcion> inscripcionesCursos = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDatosCurso = new SqlCommand("SELECT id_inscripcion,id_alumno,id_curso,condicion,nota FROM alumnos_inscripciones WHERE id_alumno = @id_alumno", SqlConn);
                cmdDatosCurso.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drDatosCurso = cmdDatosCurso.ExecuteReader();
                if (drDatosCurso.Read())
                {
                    AlumnoInscripcion aluCurso = new AlumnoInscripcion();

                    Persona per = new Persona();
                    Curso cur = new Curso();

                    PersonaAdapter perAda = new PersonaAdapter();
                    CursoAdapter curAda = new CursoAdapter();

                    per = perAda.GetOne(Convert.ToInt32(drDatosCurso["id_alumno"]));
                    cur = curAda.GetOne(Convert.ToInt32(drDatosCurso["id_curso"]));

                    aluCurso.ID = (int)drDatosCurso["id_inscripcion"];
                    aluCurso.Alumno = drDatosCurso.IsDBNull(1) ? null : per;
                    aluCurso.Curso = drDatosCurso.IsDBNull(2) ? null : cur;
                    aluCurso.Condicion = (string)drDatosCurso["condicion"];
                    aluCurso.Nota = (int)drDatosCurso["nota"];

                    inscripcionesCursos.Add(aluCurso);

                }

                drDatosCurso.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de inscripciones alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripcionesCursos;
        }

        public void Delete(AlumnoInscripcion aluInscripto)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = aluInscripto.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripcion SET id_curso = @id_curso, id_alumno = @id_alumno," +
                                                    "condicion = @condicion, nota = @nota " +
                                                    "WHERE id_inscripcion = @id_inscripcion", SqlConn);
                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.Curso.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.Alumno.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;


                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void UpdateNota(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET condicion = @condicion, nota = @nota " +
                                                    "WHERE id_inscripcion = @id_inscripcion", SqlConn);
                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de inscripcion", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones (id_alumno,id_curso,condicion,nota) " +
                                                    "VALUES(@id_alumno,@id_curso,@condicion,@nota) " +
                                                    "SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.Alumno.ID;//El ID del alumno en la inscripcion es el legajo
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.Curso.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
