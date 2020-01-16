using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Common.Cache;

namespace DataAccess
{
    public class ProductoDao:ConnectionToMySql
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
                        command.CommandText = "SELECT distinct pr.id_prod, pr.cod_bar, pr.producto, pr.det_prod, pr.cant_total, pr.fecha_vencimiento, pr.lote, pr.laboratorio, pr.composicion,pr.id_presentacion, pst.presentacion, pr.estado, case when pr.estado = 0 then 'Deshabilitado' when pr.estado = 1 then 'Habilitado' end as estado2 from tb_producto pr inner join  tb_presentacion pst  on pr.id_presentacion=pst.id_presentacion order by estado desc";
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
        public void insertarProducto(string cod_bar, string producto, string det_prod,double cant_total,DateTime fecha_vencimiento, string lote,string laboratorio,string composicion,int id_presentacion,int estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into tb_producto(cod_bar, producto, det_prod, cant_total, fecha_vencimiento, lote, laboratorio, composicion, id_presentacion, estado)values(@cod_bar, @producto, @det_prod, @cant_total, @fecha_vencimiento, @lote, @laboratorio, @composicion, @id_presentacion, @estado)";
                        command.Parameters.AddWithValue("@cod_bar", cod_bar);
                        command.Parameters.AddWithValue("@producto", producto);
                        command.Parameters.AddWithValue("@det_prod", det_prod);
                        command.Parameters.AddWithValue("@cant_total", cant_total);
                        command.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                        command.Parameters.AddWithValue("@lote", lote);
                        command.Parameters.AddWithValue("@laboratorio", laboratorio);
                        command.Parameters.AddWithValue("@composicion", composicion);
                        command.Parameters.AddWithValue("@id_presentacion", id_presentacion);
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
        public void actualizarProducto(string cod_bar, string producto, string det_prod, double cant_total, DateTime fecha_vencimiento, string lote, string laboratorio, string composicion, int id_presentacion, int estado,int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_producto SET cod_bar=@cod_bar, producto=@producto, det_prod=@det_prod, cant_total=@cant_total, fecha_vencimiento=@fecha_vencimiento, lote=@lote, laboratorio=@laboratorio, composicion=@composicion, id_presentacion=@id_presentacion, estado=@estado WHERE id_prod = @id";
                        command.Parameters.AddWithValue("@cod_bar", cod_bar);
                        command.Parameters.AddWithValue("@producto", producto);
                        command.Parameters.AddWithValue("@det_prod", det_prod);
                        command.Parameters.AddWithValue("@cant_total", cant_total);
                        command.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                        command.Parameters.AddWithValue("@lote", lote);
                        command.Parameters.AddWithValue("@laboratorio", laboratorio);
                        command.Parameters.AddWithValue("@composicion", composicion);
                        command.Parameters.AddWithValue("@id_presentacion", id_presentacion);
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
        public void deshabilitarProducto(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_producto SET estado = 0 WHERE id_prod = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Producto Deshabilitado");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
        }
        public void habilitarProducto(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "update tb_producto SET estado = 1 WHERE id_prod = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Producto Habilitado");
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
