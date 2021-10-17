using AutoMapper;
using EjecicioSeccionB.Repository.iRepository;
using EjecicioSeccionB.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjecicioSeccionB.Models;

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

            foreach (var nLista in nListaPersona)
            {
                nListaPersonaDTO.Add(_mapper.Map<PersonaDto>(nLista));
            }
            return Ok(nListaPersonaDTO);
        }

        [HttpGet("{pCodigoInterno:int}", Name = "GetPersona")]
        public IActionResult GetPersonaByCodigo(int pCodigoInterno)
        {
            var RegistroPersona = _ctoPersonas.GetPersona(pCodigoInterno);

            if(RegistroPersona == null)
            {
                NotFound();
            }
            var nRegistroPersonaDto = _mapper.Map<PersonaDto>(RegistroPersona);

            return Ok(nRegistroPersonaDto);
        }

        [HttpPost]
        public IActionResult CreaPersona([FromBody] PersonaSaveDto _PersonSaveDato)
        {
            if(_PersonSaveDato == null)
            {
                return BadRequest(ModelState);
            }
            var Persona = _mapper.Map<PersonaModel>(_PersonSaveDato);

            if (!_ctoPersonas.CreaPersona(Persona))
            {
                ModelState.AddModelError("", $"Ocurrio un error al grabar el registro {Persona.CodigoPersona}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetPersona", new { pCodigoInterno = _PersonSaveDato.CodigoPersona }, Persona);

        }
    }
}
