using System.Collections.Generic;
using System.Linq;
using CatalogoCursos.Dados;
using CatalogoCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCursos.Controllers
{
    [Route("api/[controller]")]
    public class CursoController:Controller
    {
        Curso curso = new Curso();
        readonly CatalogoContext contexto;

        public CursoController(CatalogoContext contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Curso> Listar(){
            return contexto.Curso.ToList();
        }

        [HttpGet("{id}")]
        public Curso Listar(int id){
            return contexto.Curso.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Curso curso){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            contexto.Curso.Add(curso);

            int x = contexto.SaveChanges();
            if(x > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Curso curso){
            if(curso == null || curso.Id != id){
                return BadRequest();
            }
            var cur = contexto.Curso.FirstOrDefault(x=> x.Id == id);
            if(cur == null){
                return NotFound();
            }

            cur.Id = curso.Id;
            cur.IdArea = curso.IdArea;
            cur.Nome = curso.Nome;

            contexto.Curso.Update(cur);
            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var curso = contexto.Curso.Where(x => x.Id == id).FirstOrDefault();
            if(curso == null){
                return NotFound();
            }

            contexto.Curso.Remove(curso);

            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }
    }
}