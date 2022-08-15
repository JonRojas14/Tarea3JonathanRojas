using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TareaNo._3_Jonathan_Rojas_3101.Data;
using TareaNo._3_Jonathan_Rojas_3101.Models;

namespace TareaNo._3_Jonathan_Rojas_3101.Controllers
{
    public class CitasControllercs : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public CitasControllercs(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult CitasAgendadas()
        {
            IEnumerable<Citas> listCitas = _context.Cita; //crea una lista del modelo citas
            return View(listCitas); //retorna la vista 
        }

        // GET 
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Citas citas)
        {
            if (_context.Cita.Any(m => m.Especialidad == citas.Especialidad) && _context.Cita.Any(m => m.Estado == "Activa"))
            {
                ModelState.AddModelError("", "No se puede agendar una cita de la misma especialidad si tiene una activa. Por favor tambien considere que no se puede agendar una cita con un especialista a la misma hora si este ya tiene otra cita.");
            }
            else
            {
                    TimeSpan start = new TimeSpan(08, 00, 00);
                    TimeSpan end = new TimeSpan(16, 00, 00);
                    TimeSpan horaCita = citas.Cita.TimeOfDay;

                    if (horaCita < start || horaCita > end)
                    {
                        ModelState.AddModelError("", "No se pueden agendar citas antes de las 8:00 am o despues de las 4:00 pm ");
                    }
                    else
                    {
                        if (citas.Cita.DayOfWeek != DayOfWeek.Saturday && citas.Cita.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (ModelState.IsValid)
                            {
                                _context.Cita.Add(citas);
                                _context.SaveChanges();

                                return RedirectToAction("CitasAgendadas");
                            }
                        }
                        else
                        {
                            ViewBag.Message = "No se pueden agendar citas los sabados o domingos.";
                        }
                    
                    
                    }

            }
            
            return View();

        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var citas = _context.Cita.Find(id);

            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);

        }

        //Post Delete
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCita(int? id)
        {

            var edificio = _context.Cita.Find(id);

            if (edificio == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(edificio);
            _context.SaveChanges();

            return RedirectToAction("CitasAgendadas");

        }

        //Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            //obtener el edificio
            var cita = _context.Cita.Find(id);

            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);

        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Citas citaestado)
        {

            if (ModelState.IsValid)
            {
                _context.Cita.Update(citaestado);
                _context.SaveChanges();

                return RedirectToAction("CitasAgendadas");
            }

            return View();

        }

    }
}
