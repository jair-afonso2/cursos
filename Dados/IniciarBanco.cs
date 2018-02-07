using System;
using System.Linq;
using CatalogoCursos.Models;

namespace CatalogoCursos.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(CatalogoContext contexto){
            contexto.Database.EnsureCreated();

            if(contexto.Area.Any()){
                return;
            }
            
            var area = new Area(){
                Nome = "Informática"
            };
            contexto.Area.Add(area);

            var curso = new Curso(){
                IdArea = area.Id,
                Nome = "PHP"
            };
            contexto.Curso.Add(curso);

            var curso2 = new Curso(){
                IdArea = area.Id,
                Nome = "C#"
            };
            contexto.Curso.Add(curso2);

            var turma = new Turma(){
                IdCurso = curso.Id,
                DataInicio = DateTime.Parse("09/02/2017"),
                DataFim = DateTime.Parse("25/03/2017"),
                DiasSemana = "2ª, 4ª, 6ª",
                HorarioInicio = DateTime.Parse("7:30"),
                HorarioFim = DateTime.Parse("11:30"),
            };
            contexto.Turma.Add(turma);

            var turma2 = new Turma(){
                IdCurso = curso.Id,
                DataInicio = DateTime.Parse("17/02/2017"),
                DataFim = DateTime.Parse("21/04/2017"),
                DiasSemana = "Sábado",
                HorarioInicio = DateTime.Parse("8:00"),
                HorarioFim = DateTime.Parse("17:00"),

            };
            contexto.Turma.Add(turma2);

            var turma3 = new Turma(){
                IdCurso = curso2.Id,
                DataInicio = DateTime.Parse("15/02/2017"),
                DataFim = DateTime.Parse("25/03/2017"),
                DiasSemana = "3ª, 5ª",
                HorarioInicio = DateTime.Parse("18:00"),
                HorarioFim = DateTime.Parse("22:00"),
            };
            contexto.Turma.Add(turma3);
            contexto.SaveChanges();
        }
    }
}