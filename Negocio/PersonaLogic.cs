using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class PersonaLogic : Negocio
    {
        public PersonaLogic()
        {
            this.PersonaData = new DD.PersonaAdapter();
        }

        DD.PersonaAdapter _personaData;

        public DD.PersonaAdapter PersonaData
        {
            get
            {
                return _personaData;
            }
            set
            {
                _personaData = value;
            }
        }

        public List<Entidades.Personas> GetAll()
        {
            return this.PersonaData.GetAll();
        }

        public Entidades.Personas GetOne(int id)
        {
            return this.PersonaData.GetOne(id);
        }

        public void Delete(Personas persona)
        {
            this.PersonaData.Delete(persona);
        }

        public void Insert(Personas persona)
        {
            this.PersonaData.Insert(persona);
        }

        public void Update(Personas persona)
        {
            this.PersonaData.Update(persona);
        }
    }
}
