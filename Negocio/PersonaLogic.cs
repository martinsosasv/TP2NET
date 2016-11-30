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

        public List<Entidades.Persona> GetAll()
        {
            return this.PersonaData.GetAll();
        }

        public Entidades.Persona GetOne(int id)
        {
            return this.PersonaData.GetOne(id);
        }

        public void Delete(Persona persona)
        {
            this.PersonaData.Delete(persona);
        }

        public void Insert(Persona persona)
        {
            this.PersonaData.Insert(persona);
        }

        public void Update(Persona persona)
        {
            this.PersonaData.Update(persona);
        }

        public List<Persona> GetAllDocentes()
        {
           return this.PersonaData.GetAllDocentes();
        }
    }
}
