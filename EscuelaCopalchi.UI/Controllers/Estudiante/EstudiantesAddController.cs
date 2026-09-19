using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscuelaCopalchi.UI.Models;
using EscuelaCopalchi.UI.Models.Estudiantes;

namespace EscuelaCopalchi.UI.Controllers
{
    public class EstudiantesAddController : Controller
    {
        private readonly EstudianteRepository repository;

        public EstudiantesAddController()
        {
            repository = new EstudianteRepository();
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View("Crear");
        }

        [HttpPost]
        public ActionResult Registrar(Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Crear", estudiante);
                }

                string resultado =
                    repository.Guardar(estudiante);

                TempData["Success"] =
                    "Estudiante registrado correctamente.";

                return RedirectToAction("Crear");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Crear");
            }
        }
    }
}


