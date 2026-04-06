using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComercialWebBL;
using ComercialWebEN;

namespace ComercialWebMVCUI.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBL categoriabl = new CategoriaBL();

        // GET: CategoriaController
        public async Task<IActionResult> Index(CategoriaEN pCategoria = null)
        {
            if (pCategoria == null)
                pCategoria = new CategoriaEN();

            if (pCategoria.Top_Aux == 0)
                pCategoria.Top_Aux = 10;
            else if (pCategoria.Top_Aux == -1)
                pCategoria.Top_Aux = 0;

            var categorias = await categoriabl.BuscarAsync(pCategoria);
            ViewBag.Top = pCategoria.Top_Aux;
            return View(categorias);
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int IdCategoria)
        {
            if (IdCategoria == 0)
                return RedirectToAction(nameof(Index));

            var categoria = await categoriabl.ObtenerPorIdAsync(
                new CategoriaEN { IdCategoria = IdCategoria });

            if (categoria == null)
                return RedirectToAction(nameof(Index));

            return View(categoria);
        }

        // GET: CategoriaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaEN pCategoria)
        {
            try
            {
                await categoriabl.GuardarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(int IdCategoria)
        {
            var categoria = await categoriabl.ObtenerPorIdAsync(
                new CategoriaEN { IdCategoria = IdCategoria });

            ViewBag.Error = "";
            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoriaEN pCategoria)
        {
            try
            {
                await categoriabl.ModificarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(int IdCategoria)
        {
            var categoria = await categoriabl.ObtenerPorIdAsync(
                new CategoriaEN { IdCategoria = IdCategoria });

            return View(categoria);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CategoriaEN pCategoria)
        {
            try
            {
                await categoriabl.EliminarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }
    }
}
