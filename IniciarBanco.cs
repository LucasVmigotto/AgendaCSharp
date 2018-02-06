using System;
using System.Linq;
using Agenda.Data;
using Agenda.Models;

namespace Agenda
{
    public class IniciarBanco
    {
        public static void Inicializar(AgendaContexto contexto){
            contexto.Database.EnsureCreated();

            if(contexto.Contato.Any()){
                return;
            }

            contexto.Add(new Contato("Lucas", "Vidor Migotto", DateTime.Now));

            contexto.SaveChanges();
        }
    }
}