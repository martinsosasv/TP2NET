using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT id_usuario,nombre_usuario,clave,habilitado,email,id_persona FROM usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    Entidades.Personas persona = new Entidades.Personas();
                    PersonaAdapter perAda = new PersonaAdapter();
                    persona = perAda.GetOne(Convert.ToInt32(drUsuarios["id_persona"].ToString()));
                    

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //usr.Nombre = (string)drUsuarios["nombre"];
                    //usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Persona = drUsuarios.IsDBNull(5) ? null : persona;
                    usuarios.Add(usr);
                }

                drUsuarios.Close();
                
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
             return usuarios;
        }


        public Entidades.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT id_usuario,nombre_usuario,clave,habilitado,email,id_persona FROM usuarios WHERE id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID; 
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    Entidades.Personas persona = new Entidades.Personas();
                    PersonaAdapter perAda = new PersonaAdapter();
                    persona = perAda.GetOne(Convert.ToInt32(drUsuarios["id_persona"].ToString()));

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //usr.Nombre = (string)drUsuarios["nombre"];
                    //usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Persona = drUsuarios.IsDBNull(5) ? null : persona;
                }

                drUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public Entidades.Usuario GetOne(string usuario)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT id_usuario,nombre_usuario,clave,habilitado,email,id_persona FROM usuarios WHERE nombre_usuario = @nombre_usuario", SqlConn);
                cmdUsuarios.Parameters.AddWithValue("@nombre_usuario", usuario);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {

                    Entidades.Personas persona = new Entidades.Personas();
                    PersonaAdapter perAda = new PersonaAdapter();
                    persona = perAda.GetOne(Convert.ToInt32(drUsuarios["id_persona"].ToString()));

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //usr.Nombre = (string)drUsuarios["nombre"];
                    //usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Persona = drUsuarios.IsDBNull(5) ? null : persona;
                }

                drUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario = @id",SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario",Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave," +
                                                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, " +
                                                    "id_persona = @id_persona WHERE id_usuario = @id",SqlConn);
                cmdSave.Parameters.Add("@id",SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;

                cmdSave.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario",Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios (nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona) " +
                                                    "VALUES(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona) " +
                                                    "SELECT @@identity", SqlConn);
                
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el id que asingo a la BD automaticamente

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
