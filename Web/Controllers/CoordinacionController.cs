using System.Linq;
using System.Web.Mvc;
using CapaNegocioDatos;
using CapaNegocioDatos.Servicios;
using PW3.arq_2capas.Models.Coordinacion;

namespace PW3.arq_2capas.Controllers
{
    public class CoordinacionController : Controller
    {
        private readonly ZooEntities _contexto = new ZooEntities();
        private readonly AnimalServicio _servicio = new AnimalServicio();

        public ActionResult Index()
        {
            var planesCuidados = _contexto.PlanCuidadoes
                                          .Include("Animal")
                                          .Include("Cuidador")
                                          .ToList();

            return View(planesCuidados);
        }

        public ActionResult Create()
        {
            CargarListados();

            return View();
        }

        [HttpPost]
        public ActionResult Create(PlanViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resultado = _servicio.CoordinarPlanCuidado(model.DiaDeLaSemana, model.IdAnimal, model.IdCuidador);

                if (resultado.Exito)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.MensajeError = resultado.Mensaje;
            }

            CargarListados();
            return View(model);
        }

        private void CargarListados()
        {
            ViewBag.Animales = _contexto.Animals.ToList();
            ViewBag.Cuidadores = _contexto.Cuidadors.ToList();
        }
    }
}