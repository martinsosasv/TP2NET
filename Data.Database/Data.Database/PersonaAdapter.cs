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
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT id_persona,nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan FROM personas", SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    //PlanAdapter planAda = new PlanAdapter();
                    //Plan plan = new Plan();
                    //plan = planAda.GetOne(Int32.Parse(drPersonas["id_plan"].ToString()));

                    string idPlan = drPersonas["id_plan"].ToString();
                    Plan plan = new Plan();
                    if (idPlan != "")
                    {
                        PlanAdapter planAda = new PlanAdapter();
                        plan = planAda.GetOne(Int32.Parse(idPlan));
                    }


                    persona.Plan = drPersonas.IsDBNull(9) ? null : plan;
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.IdLegajo = drPersonas.IsDBNull(7) ? -1 : (int)drPersonas["legajo"];
                    persona.TipoPersona = (Persona.TiposPersonas)drPersonas["tipo_persona"];


                    personas.Add(persona);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Entidades.Persona GetOne(int ID)
        {
            Persona persona = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("SELECT id_persona,nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan FROM personas WHERE id_persona = @id", SqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersona = cmdPersona.ExecuteReader();
                if(drPersona.Read())
                {

                    string idPlan = drPersona["id_plan"].ToString();
                    Plan plan = new Plan();
                    if(idPlan != "")
                    {
                        PlanAdapter planAda = new PlanAdapter();
                        plan = planAda.GetOne(Int32.Parse(idPlan));
                    }
                    

                    persona.Plan = drPersona.IsDBNull(9) ? null : plan;
                    persona.ID = (int)drPersona["id_persona"];
                    persona.Nombre = (string)drPersona["nombre"];
                    persona.Apellido = (string)drPersona["apellido"];
                    persona.Direccion = (string)drPersona["direccion"];
                    persona.Email = (string)drPersona["email"];
                    persona.Telefono = (string)drPersona["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    persona.IdLegajo = drPersona.IsDBNull(7) ? -1 : (int)drPersona["legajo"];
                    persona.TipoPersona = (Persona.TiposPersonas)drPersona["tipo_persona"];
                }

                drPersona.Close();

            }
            catch (Exception Ex)
            {
                Exception exManejada = new Exception("Error al recuperar un usuario", Ex);
                throw exManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }

        public void Delete(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona = @id",SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdDelete.ExecuteNonQuery();
                
            }
            catch (Exception Ex)
            {
                Exception exManejada = new Exception("Error al eliminar persona",Ex);
                throw exManejada;
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
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception exManejada = new Exception("Error al eliminar persona", Ex);
                throw exManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Update(Entidades.Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre = @nombre, apellido = @apellido," +
                                                    "direccion = @direccion, email = @email, telefono = @telefono, fecha_nac = @fecha_nac, " +
                                                    "legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan " +
                                                    "WHERE id_persona = @id",SqlConn);
                cmdSave.Parameters.Add("@id",SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.IdLegajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                if(persona.Plan == null)
                {
                    cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = (object)DBNull.Value;
                }
                else
                {
                    cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
                }
                

                cmdSave.ExecuteNonQuery();
                
            }
            catch (Exception Ex)
            {
                Exception exManejada = new Exception("Error al modificar datos de una persona", Ex);
                throw exManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) " +
                                                    "VALUES(@nombre,@apellido,@direccion,@email,@telefeno,@fecha_nac,@legajo,@tipo_persona,@id_plan) " +
                                                    "SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefeno", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.IdLegajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                if (persona.Plan == null)
                {
                    cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
                }
                
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Persona> GetAllDocentes()
        {
            List<Persona> listadoPersonas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand consulta = new SqlCommand("SELECT id_persona,nombre,apellido,direccion,email,telefono,fecha_nac FROM personas WHERE tipo_persona = 2 ", SqlConn);
                System.Data.SqlClient.SqlDataReader dr = consulta.ExecuteReader();
                while (dr.Read())
                {
                    Persona per = new Persona();
                    per.ID = Convert.ToInt32(dr[0]);
                    per.Nombre = dr.IsDBNull(1) ? string.Empty : dr[1].ToString();
                    per.Apellido = dr.IsDBNull(2) ? string.Empty : dr[2].ToString();
                    per.Direccion = dr.IsDBNull(3) ? string.Empty : dr[3].ToString();
                    per.Email = dr.IsDBNull(4) ? string.Empty : dr[4].ToString();
                    per.Telefono = dr.IsDBNull(5) ? string.Empty : dr[5].ToString();
                    per.FechaNacimiento = Convert.ToDateTime(dr[6]);


                    //per.Legajo = dr.IsDBNull(3) ? string.Empty : dr[3].ToString();
                    //per.Id_Tipo_Persona = dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr[8]);
                    //per.Plan = dr.IsDBNull(9) ? null : PlanAdapter.GetOne(Convert.ToInt32(dr[9]));
                    
                   

                    listadoPersonas.Add(per);
                }
                return listadoPersonas;

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
