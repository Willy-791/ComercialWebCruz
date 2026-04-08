using ComercialWebBL;
using ComercialWebEN;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ComercialWebMVCUI.Controllers
{
   
    public class ClienteController : Controller
    {
        ClienteBL clienteBL = new  ClienteBL();
        // GET: ClienteController
        public async Task<IActionResult> Index(ClienteEN pCliente = null)
        {
            if (pCliente == null)
                pCliente = new ClienteEN();
            if (pCliente.Top_Aux == 0)
                pCliente.Top_Aux = 10;
            else if (pCliente.Top_Aux == -1)
                pCliente.Top_Aux = 0;

            var clientes = await clienteBL.BuscarAsync(pCliente);
            ViewBag.Top = pCliente.Top_Aux;
            return View(clientes);
        }


        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
