using System.Linq;
using System.Web.Mvc;
using CapaNegocioDatos;

namespace PW3.arq_2capas.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly ZooEntities _contexto = new ZooEntities();

        public ActionResult Index(bool animalCreado = false)
        {
            ViewBag.AnimalCreado = animalCreado;
            var animales = _contexto.Animals.ToList();

            return View(animales);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _contexto.Animals.Add(animal);
                _contexto.SaveChanges();

                return RedirectToAction("Index", new { animalCreado = true });

            }
            return View(animal);
        }
    }
}
