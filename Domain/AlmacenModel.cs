using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Windows.Forms;

namespace Domain
{
    
    public class AlmacenModel
    {
        AlmacenDao almacenDao = new AlmacenDao();
        public void MostrarTabla(DataGridView dgv)
        {
            almacenDao.mostrarTabla(dgv);
        }
        public void MostrarCombobox(ComboBox cbx)
        {
            almacenDao.mostrarCombobox(cbx);
        }
        public void InsertarAlmacen(string nombre, int estado)
        {
            almacenDao.insertarAlmacen(nombre, estado);
        }
        public void ActualizarAlmacen(string nombre, int id)
        {
            almacenDao.actualizarAlmacen(nombre, id);
        }
        public void DeshabilitarAlmacen(int id)
        {
            almacenDao.deshabilitarAlmacen(id);
        }
        public void HabilitarAlmacen(int id)
        {
            almacenDao.habilitarAlmacen(id);
        }
    }
}
