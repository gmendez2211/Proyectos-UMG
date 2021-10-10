using EjecicioSeccionB.Connection;
using EjecicioSeccionB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjecicioSeccionB.Controllers
{
    public class PersonaController : Controller
    {
        private readonly ILogger<PersonaController> _looger;
        private readonly Conn _context;

        public PersonaController(Conn context)
        {
            _context = context;
        }
        public IActionResult Personas() {
            return View();
        }
        /*public IActionResult ConsultaPersonas()
        {
            return View();
        }*/
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_persona.ToListAsync());  //Lista todos los registros de la tabla
        }

        [HttpPost]
        public async Task<ActionResult> Personas([Bind("CodigoPersona, NombrePersona, ApellidoPersona, Edad, EstadoPersona")] PersonaModel personamodel) 
        {
            if (ModelState.IsValid)
            {
                _context.Add(personamodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personamodel);
        }
       [HttpGet]
        public async Task<IActionResult> ConsultaPersonas(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Datos = await _context.tbl_persona
                .FirstOrDefaultAsync(a => a.CodigoPersona == int.Parse(id));
            return View(Datos);
        }
        public async Task<IActionResult> EditarPersona(string id) {
            int nCodigoPersona;
            if (id == null) { return NotFound(); }

            nCodigoPersona = int.Parse(id);
            var datos = await _context.tbl_persona.FindAsync(nCodigoPersona);
            if (datos == null) { return NotFound(); }

            return View(datos);

        }
        [HttpPost]
        public async Task<IActionResult> EditarPersona(string id, [Bind("CodigoPersona, NombrePersona, ApellidoPersona, Edad")] PersonaModel personamodel) { 
        
            if(id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid) {
                try
                {
                    _context.Update(personamodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!personamodelExiste(personamodel.CodigoPersona.ToString())) { return NotFound(); }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personamodel);
        }

        private bool personamodelExiste(string pCodigoPersona) {
            return _context.tbl_persona.Any(e => e.CodigoPersona.ToString() == pCodigoPersona);
        }
    }
}
