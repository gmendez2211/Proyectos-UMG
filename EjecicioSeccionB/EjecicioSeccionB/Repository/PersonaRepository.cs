using EjecicioSeccionB.Connection;
using EjecicioSeccionB.Models;
using EjecicioSeccionB.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjecicioSeccionB.Repository
{
    public class PersonaRepository : iPersonaRepository
    {
        private readonly Conn _db;

        public PersonaRepository(Conn db)
        {
            _db = db;
        }

        public bool ActualizarPersona(PersonaModel persona)
        {
            _db.tbl_persona.Update(persona);
            return GuardaPersona();
        }

        public bool BorrarPersona(PersonaModel persona)
        {
            _db.tbl_persona.Remove(persona);
            return GuardaPersona();
        }

        public bool CreaPersona(PersonaModel persona)
        {
            _db.tbl_persona.Add(persona);
            return GuardaPersona();
        }

        public PersonaModel GetPersona(int pCodigoInterno)
        {
            return _db.tbl_persona.FirstOrDefault(p=>p.CodigoPersona == pCodigoInterno);
        }

        public ICollection<PersonaModel> GetPersonaModels()
        {
            return _db.tbl_persona.OrderBy(p=>p.ApellidoPersona).ToList();
        }

        public bool GuardaPersona()
        {
            return _db.SaveChanges() >= 0 ? true:false;
        }
    }
}
