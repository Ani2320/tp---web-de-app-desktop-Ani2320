using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TP_Web_Conversor.Models;

namespace TP_Web_Conversor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        public IActionResult SesionIniciada()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(string Usuario, string Pass)
        {
            ViewResult vista = View("SesionIniciada");
            if (UsuarioDAO.getInstancia().getUsuarioByUser(Usuario) != null)
            {
                if (UsuarioDAO.getInstancia().getUsuarioByUser(Usuario).password.Equals(Pass))
                {
                    ViewBag.usName = Usuario;
                    return vista;
                }
                else
                {
                    ViewBag.errorLogin = "La contraseña ingresada es incorrecta";
                    return View();
                }
            }
            ViewBag.errorLogin = "El usuario ingresado no existe, si quiere registrarse apriete el boton <<Registrarse>>";
            return View();
        }

        [HttpPost]
        public IActionResult Registrarse(string Usuario, string Pass, string ConfirmPass)
        {
            ViewResult vista = View("IniciarSesion");
            if (UsuarioDAO.getInstancia().getUsuarioByUser(Usuario) == null)
            {
                if (Pass.Equals(ConfirmPass))
                {
                    UsuarioDAO.getInstancia().add(new Usuario(Usuario, Pass));
                    ViewBag.registerMessage = "El registro de usuario se ha realizado correctamente:" +
                        "\n Inicia sesion para acceder a la Aplicación de Desktop";
                    return vista;
                }
                else
                {
                    ViewBag.errorRegister = "Las contraseñas ingresadas no coinciden";
                    return View();
                }
            }
            ViewBag.errorRegister = "El usuario ingresado ya existe"; 
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}