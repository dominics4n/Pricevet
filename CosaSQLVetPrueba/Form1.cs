using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.ImageFilters;
using Org.BouncyCastle.Ocsp;
using System.Reflection.PortableExecutable;

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
        BindingSource MaxVentasBindigSource = new BindingSource();
        BindingSource MaxIngresoBindigSource = new BindingSource();
        BindingSource ProductosModBindingSource = new BindingSource();
        BindingSource ProductoSelectBindingSource = new BindingSource();

        public void estadisticaspro()
        {
            TablasDAO tablasDAO = new TablasDAO();
            MaxIngresoBindigSource.DataSource = tablasDAO.getMaxDineros();
            dataGridView12.DataSource = MaxIngresoBindigSource;
            MaxVentasBindigSource.DataSource = tablasDAO.getMaxventas();
            dataGridView11.DataSource = MaxVentasBindigSource;

            int unoventas = (int)dataGridView11.Rows[0].Cells[1].Value;
            int dosventas = (int)dataGridView11.Rows[1].Cells[1].Value;
            int tresventas = (int)dataGridView11.Rows[2].Cells[1].Value;
            int fourventas = (int)dataGridView11.Rows[3].Cells[1].Value;
            int fiveventas = (int)dataGridView11.Rows[4].Cells[1].Value;

            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView11.Rows[0].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)unoventas],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView11.Rows[1].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [dosventas],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView11.Rows[2].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)tresventas],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView11.Rows[3].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)fourventas],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView11.Rows[4].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)fiveventas],
                    MaxBarWidth = double.MaxValue
                }
            };

            float unoingreso = (float)dataGridView12.Rows[0].Cells[1].Value;
            float dosingreso = (float)dataGridView12.Rows[1].Cells[1].Value;
            float tresingreso = (float)dataGridView12.Rows[2].Cells[1].Value;
            float fouringreso = (float)dataGridView12.Rows[3].Cells[1].Value;
            float fiveingreso = (float)dataGridView12.Rows[4].Cells[1].Value;

            cartesianChart2.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView12.Rows[0].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)unoingreso],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView12.Rows[1].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [dosingreso],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView12.Rows[2].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)tresingreso],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView12.Rows[3].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)fouringreso],
                    MaxBarWidth = double.MaxValue
                },
                new ColumnSeries<double>
                {
                    Name = (string)dataGridView12.Rows[4].Cells[0].Value,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(SKColors.DeepPink),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                    Values = [(double)fiveingreso],
                    MaxBarWidth = double.MaxValue
                }

            };

            cartesianChart1.XAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = new string[] { " " }
                }
            };

            cartesianChart2.XAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = new string[] { " " }
                }
            };
            cartesianChart2.YAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labeler = Labelers.Currency
                }
            };

            tablasDAO.getEstadisticas();
            int prodvendidosint = tablasDAO.getEstadisticas();
            float dinerostotalfl = tablasDAO.DAOtotalingresosfl;
            string prodmenosvendido = tablasDAO.DAOmenosventas;
            string prodmenosdineros = tablasDAO.DAOmenosdineros;

            string prodvendidostxt = prodvendidosint.ToString();
            string dinerostotaltxt = string.Format("{0:N2}", dinerostotalfl);
            label_totalventas.Text = prodvendidostxt; label_totaldinero.Text = dinerostotaltxt;
            label_menosvendido.Text = prodmenosvendido; label_menosdinero.Text = prodmenosdineros;
        }

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
            string descuentostring = string.Format("{0:N2}", descuentofl);
            string ivastring = string.Format("{0:N2}", ivafl);
            label_total.Text = totalstring; label_descuento.Text = descuentostring;
            label_subtotal.Text = subtotalstring; label_iva.Text = ivastring;

            estadisticaspro();

            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
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

            int updateventas = tablasDAO.updateUltimaVenta(productoname, IDCuenta, Cantidad, precio, descuento, IDproducto);
            int updateventascuentas = tablasDAO.updateventahascuenta(IDproducto);
            int updateexistencias = tablasDAO.updateExistenciasminus(IDproducto, Cantidad);

            VentasBindingSource.DataSource = tablasDAO.getVentasDetalleJoin(IDCuenta);
            dataGridView7.DataSource = VentasBindingSource;

            float totalfl = tablasDAO.updateTotal("total");
            float subtotalfl = tablasDAO.updateTotal("subtotal");
            float descuentofl = totalfl - subtotalfl;
            float ivafl = totalfl * 16 / 100;
            string totalstring = string.Format("{0:N2}", totalfl);
            string subtotalstring = string.Format("{0:N2}", subtotalfl);
            string descuentostring = string.Format("{0:N2}", descuentofl);
            string ivastring = string.Format("{0:N2}", ivafl);
            label_total.Text = totalstring; label_descuento.Text = descuentostring;
            label_subtotal.Text = subtotalstring; label_iva.Text = ivastring;

            UltimaCuentaBindingSource.DataSource = tablasDAO.getUltimaCuenta();
            dataGridView10.DataSource = UltimaCuentaBindingSource;

            ProductosCuentaBindingSource.DataSource = tablasDAO.buscarInventario(materialTextBox8.Text);
            dataGridView8.DataSource = ProductosCuentaBindingSource;

            estadisticaspro();
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
            estadisticaspro();
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

            label_total.Text = "0"; label_descuento.Text = "0";
            label_subtotal.Text = "0"; label_iva.Text = "0";

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel19_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        
        private void materialTextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialTextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            TablasDAO tablasDAO = new TablasDAO();
            //
            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
            //
        }

        private void dataGridView14_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;

            TablasDAO tablasDAO = new TablasDAO();
            ProductoSelectBindingSource.DataSource = tablasDAO.getProductoSelect((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView13.DataSource = ProductoSelectBindingSource;
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            int IDproducto = (int)dataGridView13.Rows[0].Cells[0].Value;
            int Cantidad = 1;
            Int32.TryParse(txt_update_existencias.Text, out Cantidad);

            TablasDAO tablasDAO = new TablasDAO();

            int updateexistencias = tablasDAO.updateExistencias(Cantidad, IDproducto);

            ProductoSelectBindingSource.DataSource = tablasDAO.getProductoSelect(IDproducto);
            dataGridView13.DataSource = ProductoSelectBindingSource;

            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            int IDproducto = (int)dataGridView13.Rows[0].Cells[0].Value;
            float CostPublico = 1;
            float.TryParse(txt_update_publico.Text, out CostPublico);

            TablasDAO tablasDAO = new TablasDAO();

            int updatecostopublico = tablasDAO.updatepublic_cost(CostPublico, IDproducto);

            ProductoSelectBindingSource.DataSource = tablasDAO.getProductoSelect(IDproducto);
            dataGridView13.DataSource = ProductoSelectBindingSource;

            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            int IDproducto = (int)dataGridView13.Rows[0].Cells[0].Value;
            float CostFarmacia = 1;
            float.TryParse(txt_update_farmacia.Text, out CostFarmacia);

            TablasDAO tablasDAO = new TablasDAO();

            int updatecostofarmacia = tablasDAO.updatemedic_cost(CostFarmacia, IDproducto);

            ProductoSelectBindingSource.DataSource = tablasDAO.getProductoSelect(IDproducto);
            dataGridView13.DataSource = ProductoSelectBindingSource;

            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            int IDproducto = (int)dataGridView13.Rows[0].Cells[0].Value;
            int Descuento = 1;
            Int32.TryParse(txt_update_descuento.Text, out Descuento);

            TablasDAO tablasDAO = new TablasDAO();

            int updatedescuento = tablasDAO.updateDescuento(Descuento, IDproducto);

            ProductoSelectBindingSource.DataSource = tablasDAO.getProductoSelect(IDproducto);
            dataGridView13.DataSource = ProductoSelectBindingSource;

            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            TablasDAO tablasDAO = new TablasDAO();

            ProveedorMiniBindingSource.DataSource = tablasDAO.searchProveedorIDNombre(materialTextBox22.Text);
            dataGridView15.DataSource = ProveedorMiniBindingSource;
        }
        public int ProveedorIDsearch = 1;
        public string ProveedorNamesearch = "FYNSA";
        private void dataGridView15_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;
            ProveedorIDsearch  = (int)dataGridView.Rows[rowClicked].Cells[0].Value;
            ProveedorNamesearch = (string)dataGridView.Rows[rowClicked].Cells[1].Value;
            label_proveedor_seleccionado.Text = ProveedorNamesearch;
        }
        private void materialButton14_Click(object sender, EventArgs e)
        {
            string newNameProd = txt_new_name.Text;
            string newPresentacion = txt_new_presentacion.Text;
            string newProveedorName = ProveedorNamesearch;
            int newProveedorID = ProveedorIDsearch;
            float newPublicosto = 1;
            float.TryParse(txt_new_publico.Text, out newPublicosto);
            float newMedicosto = 1;
            float.TryParse(txt_new_farmacia.Text, out newMedicosto);
            int newCantidad = 1;
            Int32.TryParse(txt_new_existencias.Text, out newCantidad);
            int newDescuento = 0;
            Int32.TryParse(txt_new_descuento.Text, out newDescuento);

            TablasDAO tablasDAO = new TablasDAO();

            int insertProducto = tablasDAO.addProducto(newNameProd, newPresentacion, newProveedorName, newProveedorID, newPublicosto, newMedicosto, newCantidad, newDescuento);

            ProductosModBindingSource.DataSource = tablasDAO.buscarProductosMod(materialTextBox11.Text);
            dataGridView14.DataSource = ProductosModBindingSource;
            estadisticaspro();
        }
    }
}
