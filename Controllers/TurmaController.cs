using System.Collections.Generic;
using System.Linq;
using CatalogoCursos.Dados;
using CatalogoCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCursos.Controllers
{
    [Route("api/[controller]")]
    public class TurmaController:Controller
    {
        Turma turma = new Turma();
        readonly CatalogoContext contexto;

        public TurmaController(CatalogoContext contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Turma> Listar(){
            return contexto.Turma.ToList();
        }

        [HttpGet("{id}")]
        public Turma Listar(int id){
            return contexto.Turma.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Turma turma){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            contexto.Turma.Add(turma);

            int x = contexto.SaveChanges();
            if(x > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Turma turma){
            if(turma == null || turma.Id != id){
                return BadRequest();
            }
            var tur = contexto.Turma.FirstOrDefault(x=> x.Id == id);
            if(tur == null){
                return NotFound();
            }

            tur.Id = turma.Id;
            tur.IdCurso = turma.IdCurso;
            tur.DataInicio = turma.DataInicio;
            tur.DataFim = turma.DataFim;
            tur.DiasSemana = turma.DiasSemana;
            tur.HorarioInicio = turma.HorarioInicio;
            tur.HorarioFim = turma.HorarioFim;

            contexto.Turma.Update(tur);
            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var turma = contexto.Turma.Where(x => x.Id == id).FirstOrDefault();
            if(turma == null){
                return NotFound();
            }

            contexto.Turma.Remove(turma);

            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }
    }
}