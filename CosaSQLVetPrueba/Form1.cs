using MaterialSkin;
using MaterialSkin.Controls;

namespace CosaSQLVetPrueba
{
    public partial class Form1 : MaterialForm
    {
        BindingSource CuentasBindingSource = new BindingSource();
        BindingSource VentasBindingSource = new BindingSource();
        BindingSource InventarioBindingSource = new BindingSource();
        BindingSource ProveedorBindingSource = new BindingSource();
        BindingSource ProveedorMini = new BindingSource();
        BindingSource ProductosProveedoresBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Pink700, Primary.Blue500, Accent.Green100, TextShade.BLACK);

            TablasDAO tablasDAO = new TablasDAO();

            CuentasBindingSource.DataSource = tablasDAO.getAllCuentas();
            dataGridView1.DataSource = CuentasBindingSource;

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

            CuentasBindingSource.DataSource = tablasDAO.getAllCuentas();
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

            InventarioBindingSource.DataSource = tablasDAO.getInventarioJobject();
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

            ProveedorBindingSource.DataSource = tablasDAO.getProveedorJobject();
            dataGridView4.DataSource = ProveedorBindingSource;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {//Boton Productos Proveedores
            TablasDAO tablasDAO = new TablasDAO();

            ProveedorMini.DataSource = tablasDAO.getProveedorIDNombre();
            dataGridView5.DataSource = ProveedorMini;
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
    }
}
