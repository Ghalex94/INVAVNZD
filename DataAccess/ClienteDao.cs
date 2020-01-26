using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DataAccess
{
    public class ClienteDao:ConnectionToMySql
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
                        command.CommandText = "SELECT distinct id_cli, dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli,telf_cel,fec_nac,correo,tipo,case when tipo = 0 then 'Juridica' when tipo = 1 then 'Natural' end as tipo2, estado,case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_cliente order by estado desc";
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
        public void insertarCliente(string dni_cli, string nom_cli, string ape_cli, string ruc_cli, string raz_soc, string dir_cli, string telf_cel, DateTime fec_nac, string correo, int tipo, int estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into tb_cliente(dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli,telf_cel,fec_nac,correo,tipo, estado) values(@dni_cli, @nom_cli, @ape_cli, @ruc_cli, @raz_soc, @dir_cli,@telf_cel,@fec_nac,@correo,@tipo, @estado)";
                        command.Parameters.AddWithValue("@dni_cli", dni_cli);
                        command.Parameters.AddWithValue("@nom_cli", nom_cli);
                        command.Parameters.AddWithValue("@ape_cli", ape_cli);
                        command.Parameters.AddWithValue("@ruc_cli", ruc_cli);
                        command.Parameters.AddWithValue("@raz_soc", raz_soc);
                        command.Parameters.AddWithValue("@dir_cli", dir_cli);
                        command.Parameters.AddWithValue("@telf_cel", telf_cel);
                        command.Parameters.AddWithValue("@fec_nac", fec_nac);
                        command.Parameters.AddWithValue("@correo", correo);
                        command.Parameters.AddWithValue("@tipo", tipo);
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
        public void actualizarUsuario(string dni_cli, string nom_cli, string ape_cli, string ruc_cli, string raz_soc, string dir_cli, string telf_cel, DateTime fec_nac, string correo, int tipo, int estado, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_cliente set dni_cli=@dni_cli, nom_cli=@nom_cli, ape_cli=@ape_cli, ruc_cli=@ruc_cli, raz_soc=@raz_soc, dir_cli=@dir_cli,telf_cel=@telf_cel,fec_nac=@fec_nac,correo=@correo,tipo=@tipo, estado=@estado where id_cli = @id";
                        command.Parameters.AddWithValue("@dni_cli", dni_cli);
                        command.Parameters.AddWithValue("@nom_cli", nom_cli);
                        command.Parameters.AddWithValue("@ape_cli", ape_cli);
                        command.Parameters.AddWithValue("@ruc_cli", ruc_cli);
                        command.Parameters.AddWithValue("@raz_soc", raz_soc);
                        command.Parameters.AddWithValue("@dir_cli", dir_cli);
                        command.Parameters.AddWithValue("@telf_cel", telf_cel);
                        command.Parameters.AddWithValue("@fec_nac", fec_nac);
                        command.Parameters.AddWithValue("@correo", correo);
                        command.Parameters.AddWithValue("@tipo", tipo);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.Parameters.AddWithValue("@id", id);
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
        public void deshabilitarCliente(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_cliente SET estado = 0 WHERE id_cli = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario Deshabilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void habilitarCliente(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_cliente SET estado = 1 WHERE id_cli = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Usuario Habilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }

        /**/
        public void filtrarDNI(string dni, DataGridView dgv)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_cli, dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli,telf_cel,fec_nac,correo,tipo,case when tipo = 0 then 'Juridica' when tipo = 1 then 'Natural' end as tipo2, estado,case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_cliente WHERE dni_cli like '%"+dni+"%'";
                        command.ExecuteNonQuery();

                        System.Data.DataTable dt = new System.Data.DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;

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
        public void filtrarRUC(string ruc, DataGridView dgv)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_cli, dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli,telf_cel,fec_nac,correo,tipo,case when tipo = 0 then 'Juridica' when tipo = 1 then 'Natural' end as tipo2, estado,case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_cliente WHERE ruc_cli like '%" + ruc + "%'";
                        command.ExecuteNonQuery();

                        System.Data.DataTable dt = new System.Data.DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;

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
        public void filtrarCliente(string cliente, DataGridView dgv)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_cli, dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli,telf_cel,fec_nac,correo,tipo,case when tipo = 0 then 'Juridica' when tipo = 1 then 'Natural' end as tipo2, estado,case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_cliente WHERE nom_cli like '%" + cliente + "%'";
                        command.ExecuteNonQuery();

                        System.Data.DataTable dt = new System.Data.DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;

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
        public void filtrarRazonSocial(string razonsocial, DataGridView dgv)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT distinct id_cli, dni_cli, nom_cli, ape_cli, ruc_cli, raz_soc, dir_cli,telf_cel,fec_nac,correo,tipo,case when tipo = 0 then 'Juridica' when tipo = 1 then 'Natural' end as tipo2, estado,case when estado = 0 then 'Deshabilitado' when estado = 1 then 'Habilitado' end as estado2 from tb_cliente WHERE raz_soc like '%" + razonsocial + "%'";
                        command.ExecuteNonQuery();

                        System.Data.DataTable dt = new System.Data.DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = command;

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
    }
}
