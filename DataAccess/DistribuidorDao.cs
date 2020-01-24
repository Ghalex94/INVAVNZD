using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace DataAccess
{
    public class DistribuidorDao:ConnectionToMySql
    {
        public void mostrarTabla(DataGridView dgv)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select id_dist,nom_distri,ruc_distri,tiempo_espera,direccion1,direccion2,telef1,telef2,contacto,telef_contacto,estado,case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_distribuidor order by estado desc";
                        command.CommandType = System.Data.CommandType.Text;

                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;
                        System.Data.DataTable dt = new System.Data.DataTable();

                        adapter.Fill(dt);
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        public void mostrarCombobox(ComboBox cbx)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_dist,nom_distri, estado from tb_distribuidor where estado=1 order by estado desc";
                        command.CommandType = System.Data.CommandType.Text;

                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;
                        System.Data.DataTable dt = new System.Data.DataTable();

                        adapter.Fill(dt);

                        cbx.ValueMember = "id_dist";
                        cbx.DisplayMember = "nom_distri";
                        cbx.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        public void insertarDistribudor(string nom_distri, string ruc_distri, int tiempo_espera, string direccion1, string direccion2, string telef1, string telef2, string contacto, string telef_contacto, int estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into tb_distribuidor(nom_distri,ruc_distri,tiempo_espera,direccion1,direccion2,telef1,telef2,contacto,telef_contacto,estado) values(@nom_distri,@ruc_distri,@tiempo_espera,@direccion1,@direccion2,@telef1,@telef2,@contacto,@telef_contacto,@estado)";
                        command.Parameters.AddWithValue("@nom_distri", nom_distri);
                        command.Parameters.AddWithValue("@ruc_distri", ruc_distri);
                        command.Parameters.AddWithValue("@tiempo_espera", tiempo_espera);
                        command.Parameters.AddWithValue("@direccion1", direccion1);
                        command.Parameters.AddWithValue("@direccion2", direccion2);
                        command.Parameters.AddWithValue("@telef1", telef1);
                        command.Parameters.AddWithValue("@telef2", telef2);
                        command.Parameters.AddWithValue("@contacto", contacto);
                        command.Parameters.AddWithValue("@telef_contacto", telef_contacto);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.ExecuteNonQuery();

                        //MessageBox.Show("Registro Ingresado con Exito");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void actualizarDistribuidor(string nom_distri, string ruc_distri, int tiempo_espera, string direccion1, string direccion2, string telef1, string telef2, string contacto, string telef_contacto, int estado,int id_dist)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_distribuidor set nom_distri=@nom_distri,ruc_distri=@ruc_distri,tiempo_espera=@tiempo_espera,direccion1=@direccion1,direccion2=@direccion2,telef1=@telef1,telef2=@telef2,contacto=@contacto,telef_contacto=@telef_contacto,estado=@estado where id_dist=@id_dist";
                        command.Parameters.AddWithValue("@nom_distri", nom_distri);
                        command.Parameters.AddWithValue("@ruc_distri", ruc_distri);
                        command.Parameters.AddWithValue("@tiempo_espera", tiempo_espera);
                        command.Parameters.AddWithValue("@direccion1", direccion1);
                        command.Parameters.AddWithValue("@direccion2", direccion2);
                        command.Parameters.AddWithValue("@telef1", telef1);
                        command.Parameters.AddWithValue("@telef2", telef2);
                        command.Parameters.AddWithValue("@contacto", contacto);
                        command.Parameters.AddWithValue("@telef_contacto", telef_contacto);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.Parameters.AddWithValue("@id_dist", id_dist);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Registro Actualizado con Exito");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void deshabilitarDistribuidor(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_distribuidor SET estado = 0 WHERE id_dist = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Distribuidor Deshabilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void habilitarDistribuidor(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_distribuidor SET estado = 1 WHERE id_dist = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Distribuidor Habilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }

    }
}
