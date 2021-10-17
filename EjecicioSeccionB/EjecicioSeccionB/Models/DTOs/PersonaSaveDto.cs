using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EjecicioSeccionB.Models.DTOs
{
    public class PersonaSaveDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Permite manejar en la tabla un secuencial        
        public int CodigoPersona { get; set; }
        public string NombrePersona { get; set; }                     
        public string ApellidoPersona { get; set; }                        
        public int Edad { get; set; }
        public string EstadoPersona { get; set; } = "ACT";

    }
}
