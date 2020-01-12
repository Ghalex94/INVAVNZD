using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        UserDao userdao = new UserDao();

        public bool LoginUser(string user, string pass)
        {
            return userdao.Login(user, pass);
        }
        public void MostrarUSuarios(DataGridView dgv)
        {
            userdao.mostrarTabla(dgv);
        }
        public void FiltrarNombre(string nombre, DataGridView dgv)
        {
            userdao.filtrarNombre(nombre, dgv);
        }

        public void FiltrarUsuario(string usuario, DataGridView dgv)
        {
            userdao.filtrarUsuario(usuario, dgv);
        }
        public void InsertarUsuario(string nombre, string usu, string pass, int tipo, string permisos, int estado) {
            userdao.insertarUsuario(nombre,usu,pass,tipo,permisos,estado);
        }
        public void ActualizarUsuario(string nombre, string usu, string pass, int tipo, string permisos,int id)
        {
            userdao.actualizarUsuario(nombre, usu, pass, tipo, permisos, id);
        }
        public void DeshabilitarUsuario(int id)
        {
            userdao.deshabilitarUsuario(id);
        }
        public void HabilitarUsuario(int id)
        {
            userdao.habilitarUsuario(id);
        }
    }   
}  