using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class UsuarioLogic : Negocio
    {
        public UsuarioLogic()
        {
          this.UsuarioData = new DD.UsuarioAdapter();
        }
        
        DD.UsuarioAdapter _usuarioData;
        public DD.UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

        public List<Usuario> GetAll()
        {
            return this.UsuarioData.GetAll();
        }

        public Usuario GetOne(int id)
        {
            return this.UsuarioData.GetOne(id);
        }
        public Usuario GetOne(string usuario)
        {
            return this.UsuarioData.GetOne(usuario);
        }

        public void Delete(int id)
        {
            this.UsuarioData.Delete(id);
        }

        public void Insert(Usuario usuario)
        {
            this.UsuarioData.Insert(usuario);
        }

        public void Update(Usuario usuario)
        {
            this.UsuarioData.Update(usuario);
        }

    }
}
