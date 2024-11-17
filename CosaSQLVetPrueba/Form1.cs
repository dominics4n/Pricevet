using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CosaSQLVetPrueba
{
    public partial class Form1 : MaterialForm
    {
        BindingSource CuentasBindingSource = new BindingSource();
        BindingSource UltimaCuentaBindingSource = new BindingSource();
        BindingSource VentasBindingSource = new BindingSource();
        BindingSource InventarioBindingSource = new BindingSource();
        BindingSource ProveedorBindingSource = new BindingSource();
        BindingSource ProveedorMiniBindingSource = new BindingSource();
        BindingSource ProductosProveedoresBindingSource = new BindingSource();
        BindingSource ProductosCuentaBindingSource = new BindingSource();
        BindingSource ProductosPreviewBindingSource = new BindingSource();
        BindingSource UltimaVentaBindingSource = new BindingSource();
        BindingSource NuevaCuentaBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey300, Primary.Pink400, Primary.Pink500, Accent.Pink700, TextShade.BLACK);

            TablasDAO tablasDAO = new TablasDAO();

            CuentasBindingSource.DataSource = tablasDAO.getAllCuentas();
            dataGridView1.DataSource = CuentasBindingSource;

            InventarioBindingSource.DataSource = tablasDAO.getInventarioJobject();
            dataGridView3.DataSource = InventarioBindingSource;

            ProveedorBindingSource.DataSource = tablasDAO.getProveedorJobject();
            dataGridView4.DataSource = ProveedorBindingSource;

            ProveedorMiniBindingSource.DataSource = tablasDAO.getProveedorIDNombre();
            dataGridView5.DataSource = ProveedorMiniBindingSource;

            ProductosCuentaBindingSource.DataSource = tablasDAO.buscarInventario(materialTextBox8.Text);
            dataGridView8.DataSource = ProductosCuentaBindingSource;

            UltimaCuentaBindingSource.DataSource = tablasDAO.getUltimaCuenta();
            dataGridView10.DataSource = UltimaCuentaBindingSource;

            UltimaVentaBindingSource.DataSource = tablasDAO.getUltimaVenta();
            dataGridView7.DataSource = UltimaVentaBindingSource;

            float totalfl = tablasDAO.updateTotal("total");
            float subtotalfl = tablasDAO.updateTotal("subtotal");
            float descuentofl = totalfl - subtotalfl;
            float ivafl = totalfl * 16 / 100;
            string totalstring = string.Format("{0:N2}", totalfl);
            string subtotalstring = string.Format("{0:N2}", subtotalfl);
            string descuentostring = string.Format("{0:N2}", descuentofl); ;
            string ivastring = string.Format("{0:N2}", ivafl); ;
            label_total.Text = totalstring; label_descuento.Text = descuentostring;
            label_subtotal.Text = subtotalstring; label_iva.Text = ivastring;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//DataGrid Cuentas tab Registro de venta
            //Obtener numero de fila seleccionada
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;

            TablasDAO tablasDAO = new TablasDAO();
            VentasBindingSource.DataSource = tablasDAO.getVentasDetalleJoin((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView2.DataSource = VentasBindingSource;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            TablasDAO tablasDAO = new TablasDAO();

            CuentasBindingSource.DataSource = tablasDAO.searchCuentas(materialTextBox1.Text, materialTextBox4.Text);
            dataGridView1.DataSource = CuentasBindingSource;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {//Boton Inventario
            TablasDAO tablasDAO = new TablasDAO();

            InventarioBindingSource.DataSource = tablasDAO.searchInventarioJobject(materialTextBox6.Text, materialTextBox5.Text, materialTextBox7.Text);
            dataGridView3.DataSource = InventarioBindingSource;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {//Boton Proveedores
            TablasDAO tablasDAO = new TablasDAO();

            ProveedorBindingSource.DataSource = tablasDAO.searchProveedorJobject(materialTextBox2.Text);
            dataGridView4.DataSource = ProveedorBindingSource;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {//Boton Productos Proveedores
            TablasDAO tablasDAO = new TablasDAO();

            ProveedorMiniBindingSource.DataSource = tablasDAO.searchProveedorIDNombre(materialTextBox3.Text);
            dataGridView5.DataSource = ProveedorMiniBindingSource;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//Grid Proveedores
            //Obtener numero de fila seleccionada
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;

            TablasDAO tablasDAO = new TablasDAO();
            ProductosProveedoresBindingSource.DataSource = tablasDAO.getProductosProveedores((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView6.DataSource = ProductosProveedoresBindingSource;
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            TablasDAO tablasDAO = new TablasDAO();

            ProductosCuentaBindingSource.DataSource = tablasDAO.buscarInventario(materialTextBox8.Text);
            dataGridView8.DataSource = ProductosCuentaBindingSource;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;

            TablasDAO tablasDAO = new TablasDAO();
            ProductosPreviewBindingSource.DataSource = tablasDAO.getProductoPreview((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView9.DataSource = ProductosPreviewBindingSource;
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void materialDrawer1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {

            int IDproducto = (int)dataGridView9.Rows[0].Cells[0].Value;
            int IDCuenta = (int)dataGridView10.Rows[0].Cells[0].Value;
            float precio = (float)dataGridView9.Rows[0].Cells[3].Value;
            int descuentoint = (int)dataGridView9.Rows[0].Cells[4].Value;
            float descuento = (float)descuentoint;
            string productoname = (string)dataGridView9.Rows[0].Cells[1].Value;
            int Cantidad = 1;
            Int32.TryParse(materialTextBox9.Text, out Cantidad);

            TablasDAO tablasDAO = new TablasDAO();

            int updateventas = tablasDAO.updateUltimaVenta(productoname, IDCuenta, Cantidad, precio, descuento);
            int updateventascuentas = tablasDAO.updateventahascuenta(IDproducto);

            VentasBindingSource.DataSource = tablasDAO.getVentasDetalleJoin(IDCuenta);
            dataGridView7.DataSource = VentasBindingSource;

            float totalfl = tablasDAO.updateTotal("total");
            float subtotalfl = tablasDAO.updateTotal("subtotal");
            float descuentofl = totalfl - subtotalfl;
            float ivafl = totalfl * 16 / 100;
            string totalstring = string.Format("{0:N2}", totalfl);
            string subtotalstring = string.Format("{0:N2}", subtotalfl);
            string descuentostring = string.Format("{0:N2}", descuentofl); ;
            string ivastring = string.Format("{0:N2}", ivafl); ;
            label_total.Text = totalstring; label_descuento.Text = descuentostring;
            label_subtotal.Text = subtotalstring; label_iva.Text = ivastring;

            UltimaCuentaBindingSource.DataSource = tablasDAO.getUltimaCuenta();
            dataGridView10.DataSource = UltimaCuentaBindingSource;
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel13_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            int IDcuenta = (int)dataGridView10.Rows[0].Cells[0].Value;
            string MetodoPago = "Efectivo";
            TablasDAO tablasDAO = new TablasDAO();

            int updatecuenta = tablasDAO.updateUltimaCuenta(IDcuenta, MetodoPago);
            UltimaCuentaBindingSource.DataSource = tablasDAO.getUltimaCuenta();
            dataGridView10.DataSource = UltimaCuentaBindingSource;
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            int IDcuenta = (int)dataGridView10.Rows[0].Cells[0].Value;
            string MetodoPago = "Tarjeta";
            TablasDAO tablasDAO = new TablasDAO();

            int updatecuenta = tablasDAO.updateUltimaCuenta(IDcuenta, MetodoPago);
            UltimaCuentaBindingSource.DataSource = tablasDAO.getUltimaCuenta();
            dataGridView10.DataSource = UltimaCuentaBindingSource;
        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void materialLabel15_Click(object sender, EventArgs e)
        {

        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            TablasDAO tablasDAO = new TablasDAO();
            int updatecuenta = tablasDAO.insertCuenta();
            UltimaCuentaBindingSource.DataSource = tablasDAO.getUltimaCuenta();
            dataGridView10.DataSource = UltimaCuentaBindingSource;
            UltimaVentaBindingSource.DataSource = tablasDAO.getUltimaVenta();
            dataGridView7.DataSource = UltimaVentaBindingSource;
        }
    }
}
