using Microsoft.AspNetCore.Mvc;
using ComercialWebEN;
using ComercialWebBL;

public class RegistroVentaController : Controller
{
    RegistroVentaBL ventaBL = new RegistroVentaBL();
    ClienteBL clienteBL = new ClienteBL();
    ProductoBL productoBL = new ProductoBL();

    public async Task<IActionResult> Index(RegistroVentaEN pRegistroVenta = null)
    {
        if (pRegistroVenta == null)
            pRegistroVenta = new RegistroVentaEN();

        if (pRegistroVenta.Top_Aux == 0)
            pRegistroVenta.Top_Aux = 10;
        else if (pRegistroVenta.Top_Aux == -1)
            pRegistroVenta.Top_Aux = 0;

        var lista = await ventaBL.BuscarAsync(pRegistroVenta);

        ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
        ViewBag.Productos = await productoBL.ObtenerTodosAsync();
        ViewBag.Top = pRegistroVenta.Top_Aux;

        return View(lista);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
        ViewBag.Productos = await productoBL.ObtenerTodosAsync();
        ViewBag.Error = "";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RegistroVentaEN pRegistroVenta)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
                ViewBag.Productos = await productoBL.ObtenerTodosAsync();
                return View(pRegistroVenta);
            }

            await ventaBL.GuardarAsync(pRegistroVenta);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
            ViewBag.Productos = await productoBL.ObtenerTodosAsync();
            return View(pRegistroVenta);
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var venta = await ventaBL.ObtenerPorIdAsync(
            new RegistroVentaEN { IdRegistroVenta = id });

        return View(venta);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var venta = await ventaBL.ObtenerPorIdAsync(
            new RegistroVentaEN { IdRegistroVenta = id });

        return View(venta);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(RegistroVentaEN pRegistroVenta)
    {
        await ventaBL.EliminarAsync(pRegistroVenta);
        return RedirectToAction(nameof(Index));
    }
    // GET
    public async Task<IActionResult> Edit(int id)
    {
        var venta = await ventaBL.ObtenerPorIdAsync(
            new RegistroVentaEN { IdRegistroVenta = id });

        ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
        ViewBag.Productos = await productoBL.ObtenerTodosAsync();

        return View(venta);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RegistroVentaEN pRegistroVenta)
    {
        try
        {
            await ventaBL.ModificarAsync(pRegistroVenta);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
            ViewBag.Productos = await productoBL.ObtenerTodosAsync();
            return View(pRegistroVenta);
        }
    }
}
