using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace Domain
{
    public class DistribuidorModel
    {
        DistribuidorDao distribuidorDao = new DistribuidorDao();
        public void MostrarTabla(DataGridView dgv)
        {
            distribuidorDao.mostrarTabla(dgv);
        }
        public void MostrarComboBox(ComboBox cbx)
        {
            distribuidorDao.mostrarCombobox(cbx);
        }
        public void InsertarDistribuidor(string nom_distri, string ruc_distri, int tiempo_espera, string direccion1, string direccion2, string telef1, string telef2, string contacto, string telef_contacto, int estado)
        {
            distribuidorDao.insertarDistribudor(nom_distri, ruc_distri, tiempo_espera, direccion1, direccion2, telef1, telef2, contacto, telef_contacto,estado);
        }
        public void ActualizarDistrbuidorr(string nom_distri, string ruc_distri, int tiempo_espera, string direccion1, string direccion2, string telef1, string telef2, string contacto, string telef_contacto, int estado, int id_dist)
        {
            distribuidorDao.actualizarDistribuidor(nom_distri, ruc_distri, tiempo_espera, direccion1, direccion2, telef1, telef2, contacto, telef_contacto, estado, id_dist);
        }
        public void HabilitarDistribuidor(int id)
        {
            distribuidorDao.habilitarDistribuidor(id);
        }
        public void DeshabilitarDistribuidor(int id)
        {
            distribuidorDao.deshabilitarDistribuidor(id);
        }
    }
}
