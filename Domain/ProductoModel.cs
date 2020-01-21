using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace Domain
{
    public class ProductoModel
    {
        ProductoDao productoDao = new ProductoDao();
        public void MostrarProducto(DataGridView dgv)
        {
            productoDao.mostrarTabla(dgv);
        }
        public void Filtrar_Por_CodBarra(string codBarra, DataGridView dgv)
        {
            productoDao.filtrarCodBarra(codBarra, dgv);
        }
        public void Filtrar_Por_Producto(string producto,DataGridView dgv)
        {
            productoDao.filtrarProducto(producto, dgv);
        }
        public void Filtrar_Por_Detalle(string detalle,DataGridView dgv)
        {
            productoDao.filtrarDetalle(detalle, dgv);
        }
        public void InsertarProducto(string cod_bar, string producto, string det_prod, double cant_total, DateTime fecha_vencimiento, string lote, string laboratorio, string composicion, int id_presentacion, int estado)
        {
            productoDao.insertarProducto(cod_bar, producto, det_prod, cant_total, fecha_vencimiento, lote, laboratorio, composicion, id_presentacion, estado);
        }
        public void ActualizarProducto(string cod_bar, string producto, string det_prod, double cant_total, DateTime fecha_vencimiento, string lote, string laboratorio, string composicion, int id_presentacion, int estado, int id)
        {
            productoDao.actualizarProducto(cod_bar, producto, det_prod, cant_total, fecha_vencimiento, lote, laboratorio, composicion, id_presentacion, estado, id);
        }
        public void DeshabilitarProducto(int id)
        {
            productoDao.deshabilitarProducto(id);
        }
        public void HabilitarProducto(int id)
        {
            productoDao.habilitarProducto(id);
        }
    }
}
