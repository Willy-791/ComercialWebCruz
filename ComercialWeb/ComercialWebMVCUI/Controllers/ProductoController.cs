using ComercialWebBL;
using ComercialWebDAL;
using ComercialWebEN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComercialWebMVCUI.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL productobl = new ProductoBL();
        MarcaBL marcaBL = new MarcaBL();
        CategoriaBL categoriaBL = new CategoriaBL();

        // GET: ProductoController
        public async Task<IActionResult> Index(ProductoEN pProducto = null)
        {
            if (pProducto == null)
                pProducto = new ProductoEN();

            if (pProducto.Top_Aux == 0)
                pProducto.Top_Aux = 10;
            else if (pProducto.Top_Aux == -1)
                pProducto.Top_Aux = 0;

            var productos = await productobl.BuscarAsync(pProducto);

            ViewBag.Marcas = await marcaBL.ObtenerTodosAsync();
            ViewBag.Categorias = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Top = pProducto.Top_Aux;

            return View(productos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            if (IdProducto == 0)
                return RedirectToAction(nameof(Index));

            var producto = await productobl.ObtenerPorIdAsync(
                new ProductoEN { IdProducto = IdProducto });

            if (producto == null)
                return RedirectToAction(nameof(Index));

            return View(producto);
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Marca = await marcaBL.ObtenerTodosAsync();
            ViewBag.Categoria = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoEN pProducto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Marca = await marcaBL.ObtenerTodosAsync();
                ViewBag.Categoria = await categoriaBL.ObtenerTodosAsync();
                return View(pProducto);
            }
            try
            {
                await productobl.GuardarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Marca = await marcaBL.ObtenerTodosAsync();
                ViewBag.Categoria = await categoriaBL.ObtenerTodosAsync();
                return View(pProducto);
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            var producto = await productobl.ObtenerPorIdAsync(
                new ProductoEN { IdProducto = IdProducto });

            ViewBag.Marca = await marcaBL.ObtenerTodosAsync();
            ViewBag.Categoria = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoEN pProducto)
        {
            try
            {
                await productobl.ModificarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Marca = await marcaBL.ObtenerTodosAsync();
                ViewBag.Categoria = await categoriaBL.ObtenerTodosAsync();
                return View(pProducto);
            }
           
        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            var producto = await productobl.ObtenerPorIdAsync(
                new ProductoEN { IdProducto = IdProducto });

            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductoEN pProducto)
        {
            try
            {
                await productobl.EliminarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }

        // 🔹 EXTRA: Actualizar Stock
        public async Task<IActionResult> ActualizarStock(int idProducto)
        {
            var producto = await productobl.ObtenerPorIdAsync(
                new ProductoEN { IdProducto = idProducto });

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarStock(int idProducto, int cantidad)
        {
            try
            {
                await productobl.ActualizarStockAsync(idProducto, cantidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // 🔹 EXTRA: Productos con bajo stock
        public async Task<IActionResult> BajoStock(int stockMinimo = 5)
        {
            var productos = await productobl.ObtenerBajoStockAsync(stockMinimo);
            return View(productos);
        }
    }
}
