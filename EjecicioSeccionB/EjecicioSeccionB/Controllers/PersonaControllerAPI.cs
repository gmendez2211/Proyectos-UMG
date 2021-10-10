using AutoMapper;
using EjecicioSeccionB.Repository.iRepository;
using EjecicioSeccionB.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjecicioSeccionB.Controllers
{
    [Route("api/Persona")]
    [ApiController]
    public class PersonaControllerAPI : Controller
    {
        private readonly iPersonaRepository _ctoPersonas;
        private readonly IMapper _mapper;

        //constructor
        public PersonaControllerAPI(iPersonaRepository ctoPersonas, IMapper mapper)
        {
            _ctoPersonas = ctoPersonas;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaPersonas()
        {
            var nListaPersona = _ctoPersonas.GetPersonaModels();

            var nListaPersonaDTO = new List<PersonaDto>();

            foreach(var nLista in nListaPersona)
            {
                nListaPersonaDTO.Add(_mapper.Map<PersonaDto>(nLista));
            }
            return Ok(nListaPersonaDTO);
        }

    }
}
