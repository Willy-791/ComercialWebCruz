using ComercialWebDAL;
using ComercialWebEN;

namespace ComercialWebBL
{
    public class RegistroPrestamoBL
    {
        public async Task<int> GuardarAsync(RegistroPrestamoEN pPrestamo)
        {
            ProductoBL productoBL = new ProductoBL();

            var producto = await productoBL.ObtenerPorIdAsync(
                new ProductoEN { IdProducto = pPrestamo.IdProducto });

            if (producto.Stock < pPrestamo.Cantidad)
                throw new Exception("Stock insuficiente para préstamo");

            pPrestamo.FechaInicio = DateTime.Now;

            int result = await RegistroPrestamoDAL.GuardarAsync(pPrestamo);

            // 🔥 RESTA STOCK
            await productoBL.ActualizarStockAsync(
                pPrestamo.IdProducto,
                -pPrestamo.Cantidad);

            return result;
        }

        public async Task<int> ModificarAsync(RegistroPrestamoEN pPrestamo)
        {
            return await RegistroPrestamoDAL.ModificarAsync(pPrestamo);
        }

        public async Task<int> EliminarAsync(RegistroPrestamoEN pPrestamo)
        {
            return await RegistroPrestamoDAL.EliminarAsync(pPrestamo);
        }

        public async Task<RegistroPrestamoEN> ObtenerPorIdAsync(RegistroPrestamoEN pPrestamo)
        {
            return await RegistroPrestamoDAL.ObtenerPorIdAsync(pPrestamo);
        }

        public async Task<List<RegistroPrestamoEN>> ObtenerTodosAsync()
        {
            return await RegistroPrestamoDAL.ObtenerTodosAsync();
        }

        public async Task<List<RegistroPrestamoEN>> BuscarAsync(RegistroPrestamoEN pPrestamo)
        {
            return await RegistroPrestamoDAL.BuscarAsync(pPrestamo);
        }
    }
}