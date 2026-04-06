using ComercialWebBL;
using ComercialWebDAL;
using ComercialWebEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ComercialWebMVCUI.Controllers
{
    public class MarcaController : Controller
    {
        MarcaBL marcaBL = new MarcaBL();

        // GET: MarcaController
        public async Task<IActionResult> Index(MarcaEN pMarca = null)
        {
            if (pMarca == null)
                pMarca = new MarcaEN();
            if (pMarca.Top_Aux == 0)
                pMarca.Top_Aux = 10;
            else if (pMarca.Top_Aux == -1)
                pMarca.Top_Aux = 0;

            var marcas = await marcaBL.BuscarAsync(pMarca);
            ViewBag.Top = pMarca.Top_Aux;
            return View(marcas);
        }


        // GET: MarcaController/Details/5
        public async Task<IActionResult> Details(int IdMarca)
        {
            if (IdMarca == 0)
                return RedirectToAction(nameof(Index));

            var marca = await marcaBL.ObtenerPorIdAsync(
                new MarcaEN { IdMarca = IdMarca });

            if (marca == null)
                return RedirectToAction(nameof(Index));

            return View(marca);
        }
        // GET: MarcaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: MarcaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaEN pMarca)
        {
            try
            {
                await marcaBL.GuardarAsync(pMarca);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Error al guardar la marca. Por favor, inténtelo de nuevo.";
                return View(pMarca);
            }
        }


        // GET: MarcaController/Edit/5
        public async Task<IActionResult> Edit(int IdMarca)
        {
            if (IdMarca == 0)
                return RedirectToAction(nameof(Index));

            var marca = await marcaBL.ObtenerPorIdAsync(
                new MarcaEN { IdMarca = IdMarca });

            if (marca == null)
                return RedirectToAction(nameof(Index));

            return View(marca);
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MarcaEN pMarca)
        {
            try
            {
                if(!Request.Form.ContainsKey("Estado"))
                    {
                    pMarca.Estado = 0;
                }
                await marcaBL.ModificarAsync(pMarca);
                return RedirectToAction(nameof(Index));
     
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMarca);
            }
        }

        // GET: MarcaController/Delete/5
        public async Task<IActionResult> Delete(int IdMarca)
        {
            var marca = await marcaBL.ObtenerPorIdAsync(new MarcaEN {  IdMarca = IdMarca });
            return View(marca);
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(MarcaEN pMarca)
        {
            try
            {
                await marcaBL.EliminarAsync(pMarca);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMarca);
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                context.Result = RedirectToAction("Login", "login");
            }
        }
    }
}
