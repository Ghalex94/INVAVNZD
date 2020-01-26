using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Windows.Forms;

namespace Domain
{
    public class ClienteModel
    {
        ClienteDao clienteDao = new ClienteDao();
        public void MostrarTabla(DataGridView dgv)
        {
            clienteDao.mostrarTabla(dgv);
        }
        public void InsertarCliente(string dni_cli, string nom_cli, string ape_cli, string ruc_cli, string raz_soc, string dir_cli, string telf_cel, DateTime fec_nac, string correo, int tipo, int estado)
        {
            clienteDao.insertarCliente(dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli, telf_cel, fec_nac, correo, tipo, estado);
        }
        public void ActualizarCliente(string dni_cli, string nom_cli, string ape_cli, string ruc_cli, string raz_soc, string dir_cli, string telf_cel, DateTime fec_nac, string correo, int tipo, int estado, int id)
        {
            clienteDao.actualizarUsuario(dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli, telf_cel, fec_nac, correo, tipo, estado, id);
        }
        public void DeshabilitarCliente(int id)
        {
            clienteDao.deshabilitarCliente(id);
        }
        public void HabilitarCliente(int id)
        {
            clienteDao.habilitarCliente(id);
        }
        public void FiltrarDNI(string dni, DataGridView dgv)
        {
            clienteDao.filtrarDNI(dni, dgv);
        }
        public void FiltrarRUC(string ruc, DataGridView dgv)
        {
            clienteDao.filtrarRUC(ruc, dgv);
        }
        public void FiltrarCliente(string cliente, DataGridView dgv)
        {
            clienteDao.filtrarCliente(cliente, dgv);
        }
        public void FiltrarRazonSocial(string razonsocial, DataGridView dgv)
        {
            clienteDao.filtrarRazonSocial(razonsocial, dgv);
        }
    }
}
