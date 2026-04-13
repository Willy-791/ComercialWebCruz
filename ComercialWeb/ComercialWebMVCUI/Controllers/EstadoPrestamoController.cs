using ComercialWebBL;
using ComercialWebDAL;
using ComercialWebEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ComercialWebMVCUI.Controllers
{
    public class EstadoPrestamoController : Controller
    {
        EstadoPrestamoBL estadoPrestamoBL = new EstadoPrestamoBL();

        // GET: EstadoPrestamoController
        public async Task<IActionResult> Index(EstadoPrestamoEN pEstadoPrestamo = null)
        {
            if (pEstadoPrestamo == null)
                pEstadoPrestamo = new EstadoPrestamoEN();

            if (pEstadoPrestamo.Top_Aux == 0)
                pEstadoPrestamo.Top_Aux = 10;
            else if (pEstadoPrestamo.Top_Aux == -1)
                pEstadoPrestamo.Top_Aux = 0;

            var estados = await estadoPrestamoBL.BuscarAsync(pEstadoPrestamo);
            ViewBag.Top = pEstadoPrestamo.Top_Aux;

            return View(estados);
        }

        // GET: Details
        public async Task<IActionResult> Details(int IdEstadoPrestamo)
        {
            if (IdEstadoPrestamo == 0)
                return RedirectToAction(nameof(Index));

            var estado = await estadoPrestamoBL.ObtenerPorIdAsync(
                new EstadoPrestamoEN { IdEstadoPrestamo = IdEstadoPrestamo });

            if (estado == null)
                return RedirectToAction(nameof(Index));

            return View(estado);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoPrestamoEN pEstadoPrestamo)
        {
            try
            {
                await estadoPrestamoBL.GuardarAsync(pEstadoPrestamo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Error al guardar el estado de préstamo.";
                return View(pEstadoPrestamo);
            }
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int IdEstadoPrestamo)
        {
            if (IdEstadoPrestamo == 0)
                return RedirectToAction(nameof(Index));

            var estado = await estadoPrestamoBL.ObtenerPorIdAsync(
                new EstadoPrestamoEN { IdEstadoPrestamo = IdEstadoPrestamo });

            if (estado == null)
                return RedirectToAction(nameof(Index));

            return View(estado);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EstadoPrestamoEN pEstadoPrestamo)
        {
            try
            {
                await estadoPrestamoBL.ModificarAsync(pEstadoPrestamo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEstadoPrestamo);
            }
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int IdEstadoPrestamo)
        {
            var estado = await estadoPrestamoBL.ObtenerPorIdAsync(
                new EstadoPrestamoEN { IdEstadoPrestamo = IdEstadoPrestamo });

            return View(estado);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EstadoPrestamoEN pEstadoPrestamo)
        {
            try
            {
                await estadoPrestamoBL.EliminarAsync(pEstadoPrestamo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEstadoPrestamo);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                context.Result = RedirectToAction("Login", "Login");
            }
        }
    }
}
