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
    public class Docente_CursoAdapter : Adapter
    {
        public void Insert(Docente_Curso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO docentes_cursos (id_curso, id_docente, cargo) VALUES (@id_curso, @id_docente, @cargo) SELECT @@identity", SqlConn);
                cmd.Parameters.AddWithValue("@id_docente", docenteCurso.Docente.ID);
                cmd.Parameters.AddWithValue("@id_curso", docenteCurso.Curso.ID);
                cmd.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                docenteCurso.ID = Decimal.ToInt32((decimal)cmd.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente
                
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al asignar el Docente al Curso", e);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Update(Docente_Curso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE docentes_cursos SET cargo=@cargo  WHERE id_docente=@idDocente and id_curso=@idCurso ", SqlConn);
                
                cmdUpdate.Parameters.AddWithValue("@idDocente", docenteCurso.Docente.ID);
                cmdUpdate.Parameters.AddWithValue("@idCurso", docenteCurso.Curso.ID);
                cmdUpdate.Parameters.AddWithValue("@cargo", docenteCurso.Cargo);
                
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el Docente al curso", e);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Delete(Docente_Curso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM docentes_cursos WHERE id_docente=@idDocente and id_curso=@idCurso",SqlConn);
                
                cmdDelete.Parameters.AddWithValue("@idDocente", docenteCurso.Docente.ID);
                cmdDelete.Parameters.AddWithValue("@idCurso", docenteCurso.Curso.ID);
                
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Docente_Curso", e);

                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }

        }

        public List<Docente_Curso> GetAll()
        {
            List<Docente_Curso> listado = new List<Docente_Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand consulta = new SqlCommand("SELECT id_docente, id_curso, cargo FROM docentes_cursos", SqlConn);
                
                SqlDataReader dr = consulta.ExecuteReader();
                while (dr.Read())
                {
                    Docente_Curso docCurso = new Docente_Curso();
                    PersonaAdapter perAda = new PersonaAdapter();
                    CursoAdapter curAda = new CursoAdapter();
                    docCurso.Docente = dr.IsDBNull(0) ? null : perAda.GetOne(Convert.ToInt32(dr[0]));
                    docCurso.Curso = dr.IsDBNull(1) ? null : curAda.GetOne(Convert.ToInt32(dr[1]));
                    docCurso.Cargo = (Docente_Curso.TipoCargo)dr["cargo"];
                    listado.Add(docCurso);
                }
                
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
            return listado;
        }

        public List<Docente_Curso> GetAll(int id_docente)
        {
            List<Docente_Curso> listado = new List<Docente_Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand consulta = new SqlCommand("SELECT id_docente,id_curso,cargo FROM docentes_cursos WHERE id_docente=@id_docente ", SqlConn);
                consulta.Parameters.AddWithValue("@id_docente", id_docente);
                SqlDataReader dr = consulta.ExecuteReader();
                while (dr.Read())
                {
                    Docente_Curso docCurso = new Docente_Curso();
                    PersonaAdapter perAda = new PersonaAdapter();
                    CursoAdapter curAda = new CursoAdapter();
                    docCurso.Docente = dr.IsDBNull(0) ? null : perAda.GetOne(Convert.ToInt32(dr[0]));
                    docCurso.Curso = dr.IsDBNull(1) ? null : curAda.GetOne(Convert.ToInt32(dr[1]));
                    docCurso.Cargo =(Docente_Curso.TipoCargo)dr["cargo"];
                    listado.Add(docCurso);
                }
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
            return listado;
        }

        public Docente_Curso GetOne(int idDoc, int idCur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand consulta = new SqlCommand("SELECT id_docente,id_curso, cargo FROM docentes_cursos WHERE id_docente=@idDoc and id_curso=@idCur", SqlConn);
                consulta.Parameters.AddWithValue("@idDoc", idDoc);
                consulta.Parameters.AddWithValue("@idCur", idCur);

                
                SqlDataReader dr = consulta.ExecuteReader();
                Docente_Curso docCurso = new Docente_Curso();
                if (dr.Read())
                {
                    PersonaAdapter perAda = new PersonaAdapter();
                    CursoAdapter curAda = new CursoAdapter();
                    docCurso.Docente = dr.IsDBNull(0) ? null : perAda.GetOne(Convert.ToInt32(dr[0]));
                    docCurso.Curso = dr.IsDBNull(1) ? null : curAda.GetOne(Convert.ToInt32(dr[1]));
                    docCurso.Cargo =(Docente_Curso.TipoCargo)dr["cargo"];
                }

                return docCurso;
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
    }
}
