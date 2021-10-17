using AutoMapper;
using EjecicioSeccionB.Models;
using EjecicioSeccionB.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace EjecicioSeccionB.Mapper
{
    public class PersonaMapper:Profile
    {
        public PersonaMapper()
        {
            CreateMap<PersonaModel, PersonaDto>().ReverseMap();
            CreateMap<PersonaModel, PersonaSaveDto>().ReverseMap();
        }
    }
}
