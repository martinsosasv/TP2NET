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
                    PlanAdapter planAda = new PlanAdapter();
                    Plan plan = new Plan();
                    plan = planAda.GetOne(Int32.Parse(drPersonas["id_plan"].ToString()));

                    persona.Plan = drPersonas.IsDBNull(8) ? null : plan;
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.IdLegajo = (int)drPersonas["legajo"];
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
                    PlanAdapter planAda = new PlanAdapter();
                    Plan plan = new Plan();

                    plan = planAda.GetOne(Int32.Parse(drPersona["id_plan"].ToString()));

                    persona.Plan = drPersona.IsDBNull(8) ? null : plan;
                    persona.ID = (int)drPersona["id_persona"];
                    persona.Nombre = (string)drPersona["nombre"];
                    persona.Apellido = (string)drPersona["apellido"];
                    persona.Direccion = (string)drPersona["direccion"];
                    persona.Email = (string)drPersona["email"];
                    persona.Telefono = (string)drPersona["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    persona.IdLegajo = (int)drPersona["legajo"];
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
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;

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
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.ID;
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

    }
}
