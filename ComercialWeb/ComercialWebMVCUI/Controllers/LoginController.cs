using ComercialWebBL;
using ComercialWebEN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    UsuarioBL usuarioBL = new UsuarioBL();
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]

    [AllowAnonymous]
    public async Task<IActionResult> Login(UsuarioEN pUsuario)
    {
        try
        {
            var usuario = await usuarioBL.LoginAsync(pUsuario);

            if (usuario != null && usuario.IdUsuario > 0)
            {
                HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
                HttpContext.Session.SetString("Login", usuario.Login);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Login o contraseña incorrectos";
            return View();

        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}