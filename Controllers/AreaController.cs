using System.Collections.Generic;
using System.Linq;
using CatalogoCursos.Dados;
using CatalogoCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCursos.Controllers
{
    [Route("api/[controller]")]
    public class AreaController:Controller
    {
        Area area = new Area();
        readonly CatalogoContext contexto;

        public AreaController(CatalogoContext contexto){
            this.contexto = contexto;
        }

        /// <summary>
        /// Retorna lista de Áreas
        /// </summary>
        /// <returns>Retorna lista de Áreas</returns>
        /// <response code="200">Retorna uma lista de áreas</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Area>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        /*public IEnumerable<Area> Listar(){
            return contexto.Area.ToList();
        }*/
        public IActionResult Listar(){
            try{
                return Ok(contexto.Area.ToList());
            } catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma área pelo seu Id
        /// </summary>
        /// <param name="id">Id da área</param>
        /// <returns>Retorna uma área</returns>
        /// <response code="200">Retorna uma área</response>
        /// <response code="400">Ocorreu um erro</response>
        /// <response code="404">Área não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Area), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        /*public Area Listar(int id){
            return contexto.Area.Where(x => x.Id == id).FirstOrDefault();
        }*/
        public IActionResult Listar(int id){
            try{
                Area area = contexto.Area.FirstOrDefault(x => x.Id == id);
                if(area == null){
                    return NotFound("Área não encontrada");
                }

                return Ok(area);
            } catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastro de área
        /// </summary>
        /// <param name="area">Objeto Area</param>
        /// <returns></returns>
        /// <remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a area request:
        /// 
        ///     POST /Area
        ///     {
        ///         "nome" : "nome da área"
        ///     }     
        /// </remarks>
        /// <response code="200">Retorna a área cadastrada</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpPost]
        [ProducesResponseType(typeof(Area), 200)]
        [ProducesResponseType(typeof(Area), 400)]
        public IActionResult Cadastro([FromBody] Area area){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{
                contexto.Area.Add(area);
                contexto.SaveChanges();
                return Ok(area);
            /*contexto.Area.Add(area);

            int x = contexto.SaveChanges();
            if(x > 0){
                return Ok();
            } else {
                return BadRequest();
            }*/

            } catch (System.Exception ex){
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Atualiza uma Área
        /// </summary>
        /// <remarks>
        /// Modelo da área que irá ser atualizada request:
        ///     PUT /Area
        ///     {
        ///         "id" : 0,
        ///         "nome" : "Nome da área atualizada"    
        ///     }
        /// </remarks>
        /// <param name="id">Id da área que vai ser atualizada</param>
        /// <param name="area">Área que irá atualizar</param>
        /// <returns>Retorna a área atualizada</returns>
        /// <response code="200">Retorna a área atualizada</response>
        /// <response code="400">Ocorreu um erro</response>
        /// <response code="404">Área não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Area), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult Atualizar(int id, [FromBody] Area area){
            try{
                if(area == null || area.Id != id){
                    return BadRequest();
                }
                var ar = contexto.Area.FirstOrDefault(x=> x.Id == id);
                if(ar == null){
                    return NotFound();
                }

                ar.Id = area.Id;
                ar.Nome = area.Nome;

                contexto.Area.Update(ar);
                contexto.SaveChanges();
                Ok(ar);
                } catch (System.Exception ex){
                    return BadRequest(ex.Message);
                }
            
            /*if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }*/
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var area = contexto.Area.Where(x => x.Id == id).FirstOrDefault();
            if(area == null){
                return NotFound();
            }

            contexto.Area.Remove(area);

            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }
    }
}