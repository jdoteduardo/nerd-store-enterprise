using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.ErroCode = id;
                modelErro.Titulo = "Ocorreu um erro interno no servidor!";
                modelErro.Mensagem = "Tente novamente mais tarde ou contate o nosso suporte.";
            }
            else if (id == 404)
            {
                modelErro.ErroCode = id;
                modelErro.Titulo = "Página não encontrada!";
                modelErro.Mensagem = "A página que você está procurando não existe! <br />Em caso de dúvidas entre em contato com o nosso suporte.";
            }
            else if (id == 403)
            {
                modelErro.ErroCode = id;
                modelErro.Titulo = "Acesso negado!";
                modelErro.Mensagem = "Você não tem permissão para acessar esta página.";
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
