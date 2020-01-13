using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace Domain
{
    public class PresentacionModel
    {
        PresentacionDao presDao = new PresentacionDao();
        
        public void MostrarPresentacion(DataGridView dgv)
        {
            presDao.mostrarTabla(dgv);
        }
        public void InsertarPresentacion(string presentacion, int estado)
        {
            presDao.insertarPresentacion(presentacion, estado);
        }
        public void ActualizarPresentacion(string presentacion, int id)
        {
            presDao.actualizarPresentacion(presentacion, id);
        }
        public void DeshabilitarPresentacion(int id)
        {
            presDao.deshabilitarPresentacion(id);
        }
        public void HabilitarPresentacion(int id)
        {
            presDao.habilitarPresentacion(id);
        }
    }
}
