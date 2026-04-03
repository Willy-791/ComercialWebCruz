using ComercialWebBL;
using ComercialWebDAL;
using ComercialWebEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComercialWebMVCUI.Controllers
{

    public class RolController : Controller
    {
        RolBL rolbl = new RolBL();

        // GET: RolController
        public async Task<IActionResult> Index(RolEN pRol = null)
        {
            if (pRol == null)
                pRol = new RolEN();
            if (pRol.Top_Aux == 0)
                pRol.Top_Aux = 10;
            else if (pRol.Top_Aux == -1)
                pRol.Top_Aux = 0;

            var roles = await rolbl.BuscarAsync(pRol);
            ViewBag.Top = pRol.Top_Aux;
            return View(roles);
        }

        // GET: RolController/Details/5
        public async Task<IActionResult> Details(int IdRol)
        {
            var rol = await rolbl.ObtenerPorIdAsync(new RolEN { IdRol = IdRol });
            return View(rol);
        }

        // GET: RolController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolEN pRol)
        {
            try
            {
                await rolbl.GuardarAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }

        // GET: RolController/Edit/5
        public async Task<IActionResult> Edit(int IdRol)
        {
            var rol = await rolbl.ObtenerPorIdAsync(new RolEN { IdRol = IdRol });
            ViewBag.Error = "";
            return View(rol);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolEN pRol)
        {
            try
            {
                await rolbl.ModificarAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(int IdRol)
        {
            var rol = await rolbl.ObtenerPorIdAsync(new RolEN { IdRol = IdRol });
            return View(rol);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RolEN pRol)
        {
            try
            {
                await rolbl.EliminarAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }
    }
}
