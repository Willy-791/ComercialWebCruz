using Microsoft.AspNetCore.Mvc;
using ComercialWebEN;
using ComercialWebBL;

public class RegistroPrestamoController : Controller
{
    RegistroPrestamoBL prestamoBL = new RegistroPrestamoBL();
    ClienteBL clienteBL = new ClienteBL();
    ProductoBL productoBL = new ProductoBL();
    EstadoPrestamoBL estadoBL = new EstadoPrestamoBL();

    public async Task<IActionResult> Index(RegistroPrestamoEN pPrestamo = null)
    {
        if (pPrestamo == null)
            pPrestamo = new RegistroPrestamoEN();

        if (pPrestamo.Top_Aux == 0)
            pPrestamo.Top_Aux = 10;
        else if (pPrestamo.Top_Aux == -1)
            pPrestamo.Top_Aux = 0;

        var lista = await prestamoBL.BuscarAsync(pPrestamo);

        ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
        ViewBag.Productos = await productoBL.ObtenerTodosAsync();
        ViewBag.Estados = await estadoBL.ObtenerTodosAsync();
        ViewBag.Top = pPrestamo.Top_Aux;

        return View(lista);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
        ViewBag.Productos = await productoBL.ObtenerTodosAsync();
        ViewBag.Estados = await estadoBL.ObtenerTodosAsync();
        ViewBag.Error = "";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RegistroPrestamoEN pPrestamo)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
                ViewBag.Productos = await productoBL.ObtenerTodosAsync();
                ViewBag.Estados = await estadoBL.ObtenerTodosAsync();
                return View(pPrestamo);
            }

            await prestamoBL.GuardarAsync(pPrestamo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
            ViewBag.Productos = await productoBL.ObtenerTodosAsync();
            ViewBag.Estados = await estadoBL.ObtenerTodosAsync();
            return View(pPrestamo);
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        var prestamo = await prestamoBL.ObtenerPorIdAsync(
            new RegistroPrestamoEN { IdRegistroPrestamo = id });

        return View(prestamo);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var prestamo = await prestamoBL.ObtenerPorIdAsync(
            new RegistroPrestamoEN { IdRegistroPrestamo = id });

        return View(prestamo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(RegistroPrestamoEN pPrestamo)
    {
        await prestamoBL.EliminarAsync(pPrestamo);
        return RedirectToAction(nameof(Index));
    }

    // GET
    public async Task<IActionResult> Edit(int id)
    {
        var prestamo = await prestamoBL.ObtenerPorIdAsync(
            new RegistroPrestamoEN { IdRegistroPrestamo = id });

        ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
        ViewBag.Productos = await productoBL.ObtenerTodosAsync();
        ViewBag.Estados = await estadoBL.ObtenerTodosAsync();

        return View(prestamo);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RegistroPrestamoEN pPrestamo)
    {
        try
        {
            await prestamoBL.ModificarAsync(pPrestamo);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            ViewBag.Clientes = await clienteBL.ObtenerTodosAsync();
            ViewBag.Productos = await productoBL.ObtenerTodosAsync();
            ViewBag.Estados = await estadoBL.ObtenerTodosAsync();
            return View(pPrestamo);
        }
    }
}