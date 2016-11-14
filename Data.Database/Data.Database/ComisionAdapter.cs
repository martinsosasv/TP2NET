using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT id_comision,desc_comision,anio_especialidad,id_plan FROM comisiones", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comision = new Comision();
                    PlanAdapter plaAda = new PlanAdapter();
                    Plan plan = new Plan();
                    plan = plaAda.GetOne(Int32.Parse(drComisiones["id_plan"].ToString()));

                    comision.ID = (int)drComisiones[0];
                    comision.Descripcion = (string)drComisiones[1];
                    comision.AnioEspecialidad = (int)drComisiones[2];
                    comision.Plan = drComisiones.IsDBNull(3) ? null : plan;

                    comisiones.Add(comision);
                }

                drComisiones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }


        public Entidades.Comision GetOne(int ID)
        {
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT id_comision,desc_comision,anio_especialidad,id_plan FROM comisiones WHERE id_comision = @id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    PlanAdapter plaAda = new PlanAdapter();
                    Plan plan = new Plan();
                    plan = plaAda.GetOne(Convert.ToInt32(drComisiones["id_plan"]));

                    comision.ID = (int)drComisiones[0];
                    comision.Descripcion = (string)drComisiones[1];
                    comision.AnioEspecialidad = (int)drComisiones[2];
                    comision.Plan = drComisiones.IsDBNull(3) ? null : plan;
                }

                drComisiones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }

        public void Delete(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad = @anio_especialidad," +
                                                    "id_plan = @id_plan " +
                                                    "WHERE id_comision = @id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.Plan.ID;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del comision", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones (desc_comision,anio_especialidad,id_plan) " +
                                                    "VALUES(@desc_comision,@anio_especialidad,@id_plan) " +
                                                    "SELECT @@identity", SqlConn);


                cmdSave.Parameters.AddWithValue("@desc_comision",comision.Descripcion);
                cmdSave.Parameters.AddWithValue("@anio_especialidad",comision.AnioEspecialidad);
                cmdSave.Parameters.AddWithValue("@id_plan",comision.Plan.ID);

                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}

