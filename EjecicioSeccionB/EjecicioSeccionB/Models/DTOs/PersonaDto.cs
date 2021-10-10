using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjecicioSeccionB.Models.DTOs
{
    public class PersonaDto
    {
        [Display(Name = "Nombre de la Persona")]
        public string NombrePersona { get; set; }

        
        [Display(Name = "Apellido de la Persona")]
        public string ApellidoPersona { get; set; }

           
        [Display(Name = "Edad de la Persona")]
        public int Edad { get; set; }
    }
}
