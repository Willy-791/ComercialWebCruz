using ComercialWebBL;
using ComercialWebEN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ResidenciaController : Controller
{
    ResidenciaBL residenciaBL = new ResidenciaBL();

    public async Task<IActionResult> Index()
    {
        var lista = await residenciaBL.ObtenerTodosAsync();
        return View(lista);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ResidenciaEN p)
    {
        if (ModelState.IsValid)
        {
            await residenciaBL.GuardarAsync(p);
            return RedirectToAction("Index");
        }
        return View(p);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var res = await residenciaBL.ObtenerPorIdAsync(new ResidenciaEN { IdResidencia = id });
        return View(res);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ResidenciaEN p)
    {
        await residenciaBL.ModificarAsync(p);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var res = await residenciaBL.ObtenerPorIdAsync(new ResidenciaEN { IdResidencia = id });
        return View(res);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ResidenciaEN p)
    {
        await residenciaBL.EliminarAsync(p);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var res = await residenciaBL.ObtenerPorIdAsync(new ResidenciaEN { IdResidencia = id });
        return View(res);
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (HttpContext.Session.GetInt32("IdUsuario") == null)
        {
            context.Result = RedirectToAction("Login", "login");
        }
    }
}