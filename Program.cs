using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CatalogoCursos.Dados;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatalogoCursos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ambiente = BuildWebHost(args);
            using(var escopo = ambiente.Services.CreateScope()){
                var servico = escopo.ServiceProvider;
                try{
                    var contexto = servico.GetRequiredService<CatalogoContext>();
                    IniciarBanco.Inicializar(contexto);
                }catch(Exception e){
                    var saida = servico.GetRequiredService<Logger<Program>>();
                    saida.LogError(e.Message, "Erro ao criar o banco.");
                }
            }
            ambiente.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
