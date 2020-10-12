using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dev.App.Modulos.Produtos.Controllers
{
  [Area("Produtos")]
  public class CadastroController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Busca()
    {
      return View();
    }
  }
}