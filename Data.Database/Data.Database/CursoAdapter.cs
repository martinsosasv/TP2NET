using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class CursoAdapter : Adapter
    {

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT id_curso,id_materia,id_comision,anio_calendario,cupo FROM cursos", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    ComisionAdapter comAda = new ComisionAdapter();
                    Comision comision = new Comision();
                    MateriaAdapter matAda = new MateriaAdapter();
                    Materia materia = new Materia();
                    materia = matAda.GetOne(Int32.Parse(drCursos["id_materia"].ToString()));
                    comision = comAda.GetOne(Int32.Parse(drCursos["id_comision"].ToString()));

                    curso.ID = (int)drCursos[0];
                    curso.Materia = drCursos.IsDBNull(1) ? null : materia;
                    curso.Comision = drCursos.IsDBNull(2) ? null : comision;
                    curso.AnioCalendario = (int)drCursos[3];
                    curso.Cupo = (int)drCursos[4];

                    cursos.Add(curso);
                }

                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }


        public Entidades.Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT id_curso,id_materia,id_comision,anio_calendario,cupo FROM cursos WHERE id_curso = @id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    ComisionAdapter comAda = new ComisionAdapter();
                    Comision comision = new Comision();
                    MateriaAdapter matAda = new MateriaAdapter();
                    Materia materia = new Materia();
                    materia = matAda.GetOne(Int32.Parse(drCursos["id_materia"].ToString()));
                    comision = comAda.GetOne(Int32.Parse(drCursos["id_comision"].ToString()));

                    curso.ID = (int)drCursos[0];
                    curso.Materia = drCursos.IsDBNull(1) ? null : materia;
                    curso.Comision = drCursos.IsDBNull(2) ? null : comision;
                    curso.AnioCalendario = (int)drCursos[3];
                    curso.Cupo = (int)drCursos[4];
                }

                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public void Delete(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision," +
                                                    "anio_calendario = @anio_calendario, cupo = @cupo " +
                                                    "WHERE id_curso = @id", SqlConn);
                cmdSave.Parameters.AddWithValue("@id_materia", curso.Materia.ID);
                cmdSave.Parameters.AddWithValue("@id_comision", curso.Comision.ID);
                cmdSave.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmdSave.Parameters.AddWithValue("@cupo", curso.Cupo);
                cmdSave.Parameters.AddWithValue("@id",curso.ID);

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos (id_materia,id_comision,anio_calendario,cupo) " +
                                                    "VALUES(@id_materia,@id_comision,@anio_calendario,@cupo) " +
                                                    "SELECT @@identity", SqlConn);


                cmdSave.Parameters.AddWithValue("@id_materia", curso.Materia.ID);
                cmdSave.Parameters.AddWithValue("@id_comision", curso.Comision.ID);
                cmdSave.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmdSave.Parameters.AddWithValue("@cupo", curso.Cupo);

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
