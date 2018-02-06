using System;
using System.Linq;
using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [Route("api/[Controller]")]
    public class ContatoController : Controller
    {
        JsonResult rs;
        readonly AgendaContexto contexto;

        private void ErrorException(Exception e)
        {
            rs = new JsonResult("");
            rs.ContentType = "application/json";
            rs.StatusCode = 404;
            rs.Value = "Um erro inesperado aconteceu! Descrição: " + e.Message;
        }

        private void NoDataFound()
        {
            rs = new JsonResult("");
            rs.ContentType = "application/json";
            rs.StatusCode = 204;
            rs.Value = "Não foram encontrados dados!";
        }

        private void Success()
        {
            rs.ContentType = "application/json";
            rs.StatusCode = 200;
        }

        private void Success(string message)
        {
            Success();
            rs.Value = message;
        }

        private void Error(string message)
        {
            rs.ContentType = "application/json";
            rs.StatusCode = 204;
            rs.Value = message;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                rs = new JsonResult(contexto.Contato.ToList());
                if (rs.Value == null)
                {
                    NoDataFound();
                }
                else
                {
                    Success();
                }
            }
            catch (Exception e)
            {
                ErrorException(e);
            }
            return Json(rs);
        }

        [HttpGet("{id}", Name = "ContatoAtual")]
        public IActionResult Get(int id)
        {
            try
            {
                rs = new JsonResult(contexto.Contato.ToList().Where(i => i.IdContato == id).FirstOrDefault());
                if (rs.Value == null)
                {
                    NoDataFound();
                }
                else
                {
                    Success();
                }
            }
            catch (Exception e)
            {
                ErrorException(e);
            }
            return Json(rs);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contato contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                contexto.Contato.Add(contato);
                rs = new JsonResult("");
                if (contexto.SaveChanges() > 0)
                {
                    Success("Sucesso ao salvar!");
                }
                else
                {
                    Error("Erro ao salvar!");
                }
            }
            catch (Exception e)
            {
                ErrorException(e);
            }
            return Json(rs);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contato contato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (contato == null || contato.IdContato != id)
                return BadRequest();

            var contatoRespectivo = contexto.Contato.ToList().Where(i => i.IdContato == id).FirstOrDefault();
            if (contatoRespectivo == null)
                return NotFound();

            try
            {
                contatoRespectivo.Nome = contato.Nome;
                contatoRespectivo.Sobrenome = contato.Sobrenome;
                contatoRespectivo.Email = contato.Email;
                contatoRespectivo.DataDeAniversario = contato.DataDeAniversario;
                contato.DataDeModificacao = DateTime.Now;
                rs = new JsonResult("");
                if (contexto.SaveChanges() > 0)
                {
                    Success("Sucesso ao alterar!");
                }
                else
                {
                    Error("Erro ao alterar!");
                }
            }
            catch (Exception e)
            {
                ErrorException(e);
            }
            return Json(rs);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletar = contexto.Contato.ToList().Where(i => i.IdContato == id).First();
                if (deletar == null)
                    NotFound();
                contexto.Contato.Remove(deletar);
                if (contexto.SaveChanges() > 0)
                {
                    Success("Sucesso ao deletar!");
                }
                else
                {
                    Error("Erro ao deletar!");
                }
            }
            catch (Exception e)
            {
                ErrorException(e);
            }
            return Json(rs);
        }
    }
}