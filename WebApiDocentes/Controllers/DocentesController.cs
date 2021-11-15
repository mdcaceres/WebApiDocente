using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDocentes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDocentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {

        private static List<Docente> lst = new List<Docente>();

        // GET: api/<DocentesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        // POST api/<DocentesController>
        [HttpPost]
        public IActionResult Save(Docente dto)
        {
            if (dto == null)
                return BadRequest();

            lst.Add(dto);
            return Ok("se registro exitosamente el docente!");
        }

        [HttpPut]
        public IActionResult Put(Docente oDocente)
        {
            foreach(Docente aux in lst)
            {
                if(aux.Id == oDocente.Id)
                {
                    aux.Name = oDocente.Name;
                    aux.LastName = oDocente.LastName;
                    return Ok(oDocente); 
                }
            }
            return NotFound(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            foreach(Docente aux in lst)
            {
                if(aux.Id == id)
                {
                    lst.Remove(aux);
                    return Ok("se elimino correctamente"); 
                }
            }
            return NotFound(); 
        }

    }
}
