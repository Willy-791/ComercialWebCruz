using ComercialWebDAL;
using ComercialWebEN;

namespace ComercialWebBL
{
    public class RegistroVentaBL
    {
        public async Task<int> GuardarAsync(RegistroVentaEN pRegistroVenta)
        {
            ProductoBL productoBL = new ProductoBL();

            var producto = await productoBL.ObtenerPorIdAsync(
                new ProductoEN { IdProducto = pRegistroVenta.IdProducto });

            if (producto.Stock < pRegistroVenta.Cantidad)
                throw new Exception("Stock insuficiente");

            pRegistroVenta.FechaVenta = DateTime.Now;

            int result = await RegistroVentaDAL.GuardarAsync(pRegistroVenta);

            await productoBL.ActualizarStockAsync(
                pRegistroVenta.IdProducto,
                -pRegistroVenta.Cantidad);

            return result;
        }

        public async Task<int> ModificarAsync(RegistroVentaEN pRegistroVenta)
        {
           // Aquí puedes mejorar luego para ajustar stock dinámicamente basures
            return await RegistroVentaDAL.ModificarAsync(pRegistroVenta);
        }

        public async Task<int> EliminarAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.EliminarAsync(pRegistroVenta);
        }

        public async Task<RegistroVentaEN> ObtenerPorIdAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.ObtenerPorIdAsync(pRegistroVenta);
        }

        public async Task<List<RegistroVentaEN>> ObtenerTodosAsync()
        {
            return await RegistroVentaDAL.ObtenerTodosAsync();
        }

        public async Task<List<RegistroVentaEN>> BuscarAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.BuscarAsync(pRegistroVenta);
        }
    }
}