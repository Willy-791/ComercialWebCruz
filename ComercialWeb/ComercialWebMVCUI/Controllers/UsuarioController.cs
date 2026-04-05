using ComercialWebBL;

using ComercialWebEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComercialWebMVCUI.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        RolBL rolBL = new RolBL();
        // GET: UsuarioController
        public async Task<IActionResult> Index(UsuarioEN pUsuario = null)
        {
            if (pUsuario == null)
                pUsuario = new UsuarioEN();
            if (pUsuario.Top_Aux == 0)
                pUsuario.Top_Aux = 10;
            else
                if (pUsuario.Top_Aux == -1)
                    pUsuario.Top_Aux = 0;

            var taksBuscar = await usuarioBL.BuscarIncluirRolesAsync(pUsuario);
            var taskObtenerRoles = rolBL.ObtenerTodosAsync();

            ViewBag.Top = pUsuario.Top_Aux;
            ViewBag.Roles = await taskObtenerRoles;

            return View(taksBuscar);
        }
        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: UsuarioController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: UsuarioController/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioEN pUsuario)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = await rolBL.ObtenerTodosAsync();
                return View(pUsuario);
            }

            try
            {
                await usuarioBL.GuardarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBL.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }

        public async Task<IActionResult> Edit(int IdUsuario)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(new UsuarioEN { IdUsuario = IdUsuario });
            ViewBag.Error = "";
            return View(usuario);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioEN pUsuario)
        {
            try
            {
                await usuarioBL.ModificarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pUsuario);
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(new UsuarioEN { IdUsuario = IdUsuario });
            return View(usuario);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UsuarioEN pUsuario)
        {
            try
            {
                await usuarioBL.EliminarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pUsuario);
            }
        }
    }
}
