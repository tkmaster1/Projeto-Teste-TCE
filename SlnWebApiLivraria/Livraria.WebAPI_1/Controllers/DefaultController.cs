using Livraria.Application.Interface;
using Livraria.Application.ViewModels;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Livraria.WebAPI_1.Controllers
{
    [RoutePrefix("api/livrariapi")]
    public class DefaultController : ApiController
    {        
        [HttpGet]
        [Route("datahora/consulta")]
        public HttpResponseMessage GetDataHoraServidor()
        {
            try
            {
                var dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                return Request.CreateResponse(HttpStatusCode.OK, dataHora);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("Consulta/BuscarPorId/{id:int?}")]
        [HttpGet]
        public HttpResponseMessage BuscarPorId(int id)
        {
            try
            {
                //List<LivroViewModel> listLivros = new List<LivroViewModel>();

                //var livros = _livroApplicationService.BuscarPorId(id);
                //if (livros == null)
                //{
                //   throw new Exception("Livro não encontrado.");
                //}

                //return Request.CreateResponse(HttpStatusCode.OK, livros.ToArray());
                return Request.CreateResponse(HttpStatusCode.OK, "entrou aqui");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //[HttpGet]
        //[Route("consulta/cliente/{id:int}")]
        //public HttpResponseMessage GetClientePorId(int id)
        //{
        //    try
        //    {
        //        var clientes = new[] {
        //    new { Id = 1, Nome = "Pedro", DataNascimento = new DateTime(1954, 2, 1) },
        //    new { Id = 2, Nome = "Paulo", DataNascimento = new DateTime(1944, 4, 12) },
        //    new { Id = 3, Nome = "Fernando", DataNascimento = new DateTime(1963, 5, 9) },
        //    new { Id = 4, Nome = "Maria", DataNascimento = new DateTime(1984, 4, 30) },
        //    new { Id = 5, Nome = "João", DataNascimento = new DateTime(1990, 3, 14) },
        //    new { Id = 6, Nome = "Joana", DataNascimento = new DateTime(1974, 6, 19) }
        //};

        //        var cliente = clientes.Where(x => x.Id == id).FirstOrDefault();

        //        if (cliente == null) throw new Exception("Cliente não encontrado");

        //        return Request.CreateResponse(HttpStatusCode.OK, cliente);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
    }
}
