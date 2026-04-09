using ComercialWebBL;

using ComercialWebEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ComercialWebMVCUI.Controllers
{
    public class ClienteController : Controller
    {
        ClienteBL clienteBL = new ClienteBL();
        ResidenciaBL residenciaBL = new ResidenciaBL();
        RolBL rolBL = new RolBL();
        // GET: ClienteController
        public async Task<IActionResult> Index(ClienteEN pCliente = null)
        {
            if (pCliente == null)
                pCliente = new ClienteEN();
            if (pCliente.Top_Aux == 0)
                pCliente.Top_Aux = 10;
            else
                if (pCliente.Top_Aux == -1)
                    pCliente.Top_Aux = 0;

            var taksBuscar = await clienteBL.BuscarIncluirResidenciasAsync(pCliente);
            var taskObtenerResidencias = residenciaBL.ObtenerTodosAsync();

            ViewBag.Top = pCliente.Top_Aux;
            ViewBag.Residencias = await taskObtenerResidencias;

            return View(taksBuscar);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int IdCliente)
        {
            if (IdCliente == 0)
                return RedirectToAction(nameof(Index));

            var lista = await clienteBL.BuscarIncluirResidenciasAsync(
                new ClienteEN { IdCliente = IdCliente });

            var cliente = lista.FirstOrDefault();

            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }


        // GET: ClienteController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Residencias = await residenciaBL.ObtenerTodosAsync();
            ViewBag.Roles = await rolBL.ObtenerTodosAsync(); 
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteEN pCliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Residencias = await residenciaBL.ObtenerTodosAsync();
                return View(pCliente);
            }

            try
            {
                await clienteBL.GuardarAsync(pCliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Residencias = await residenciaBL.ObtenerTodosAsync();
                return View(pCliente);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int IdCliente)
        {
            var cliente = await clienteBL.ObtenerPorIdAsync(
                new ClienteEN { IdCliente = IdCliente });

            ViewBag.Residencias = await residenciaBL.ObtenerTodosAsync();
            ViewBag.Roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Error = "";

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteEN pCliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Residencias = await residenciaBL.ObtenerTodosAsync();
                return View(pCliente);
            }

            try
            {
                await clienteBL.ModificarAsync(pCliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCliente);
            }
        }
        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(int IdCliente)
        {
            if (IdCliente == 0)
                return RedirectToAction(nameof(Index));

            var lista = await clienteBL.BuscarIncluirResidenciasAsync(
                new ClienteEN { IdCliente = IdCliente });

            var cliente = lista.FirstOrDefault();

            if (cliente == null)
                return RedirectToAction(nameof(Index));

            return View(cliente);
        }


        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClienteEN cliente)
        {
            try
            {
                await clienteBL.EliminarAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }
    }
}
