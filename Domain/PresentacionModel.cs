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
        
        public void MostrarUSuarios(DataGridView dgv)
        {
            presDao.mostrarTabla(dgv);
        }
        public void InsertarUsuario(string presentacion, int estado)
        {
            presDao.insertarPresentacion(presentacion, estado);
        }
        public void ActualizarUsuario(string presentacion, int id)
        {
            presDao.actualizarPresentacion(presentacion, id);
        }
        public void DeshabilitarUsuario(int id)
        {
            presDao.deshabilitarPresentacion(id);
        }
        public void HabilitarUsuario(int id)
        {
            presDao.habilitarPresentacion(id);
        }
    }
}
