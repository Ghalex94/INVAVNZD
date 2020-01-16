using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Producto
{
    public partial class FProductoActualizar : Form
    {
        public FProductoActualizar(string cod_bar, string producto, string det_prod, double cant_total, DateTime fecha_vencimiento, string lote, string laboratorio, string composicion, int id_presentacion, int estado, int id)
        {
            InitializeComponent();
        }
    }
}
