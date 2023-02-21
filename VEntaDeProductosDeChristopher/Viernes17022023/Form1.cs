using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Runtime.ConstrainedExecution;
using File = System.IO.File;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Viernes17022023
{
    public partial class Form1 : Form
    {
        int preci = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {

            txtCodigo.Text = string.Empty;
            cboProducto.Text = string.Empty;
            txtCantDispo.Text = string.Empty;
            lblpre.Text = string.Empty;
            txtCodigo.Focus();




        }

        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

            string producto = cboProducto.Text;
            if (producto.Equals("Arroz Libra")) preci = 25;
            if (producto.Equals("Azucar Libra")) preci = 21;
            if (producto.Equals("Frijoles Libra")) preci = 40;
            if (producto.Equals("Queso Libra")) preci = 100;
            if (producto.Equals("Pollo Libra")) preci = 69;
            if (producto.Equals("Carne De Cerdo Libra")) preci = 100;
            if (producto.Equals("Carne de Res Libra")) preci = 110;
            if (producto.Equals("Aceite Litro")) preci = 60;
            if (producto.Equals("Leche Litro")) preci = 40;
            if (producto.Equals("Sal")) preci = 12;
            if (producto.Equals("Chiltoma libra")) preci = 20;
            if (producto.Equals("Cebolla Libra")) preci = 30;
            if (producto.Equals("Espagueti")) preci = 30;
            if (producto.Equals("Adrenaline")) preci = 50;
            if (producto.Equals("Red Bull")) preci = 80;
            if (producto.Equals("Gaseosa 2L")) preci = 39;
            if (producto.Equals("Gaseosa 12onz")) preci = 15;
            if (producto.Equals("Paquete Escolar")) preci = 350;
            if (producto.Equals("CD")) preci = 25;
            lblpre.Text = preci.ToString("C");

        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Metodos ob = new Metodos();
                ob.CantiDispo = int.Parse(txtCantDispo.Text);
                ob.Precio1 = preci;
                ob.Producto1 = cboProducto.Text;
                double cod = double.Parse(txtCodigo.Text);

                if (txtCodigo.Text == "" || txtCantDispo.Text == "")
                {
                    MessageBox.Show("No puede ingresar valores en blancos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    for (int i = 0; i < RegistroDatos.Rows.Count; i++)
                    {
                        if (txtCodigo.Text == RegistroDatos.Rows[i].Cells[0].Value.ToString())
                        {

                            MessageBox.Show("Codigo repetido");
                            Limpiar();
                            return;

                        }
                    }

                    string[] Datos = new String[4];

                    Datos[0] = cod.ToString();
                    Datos[1] = ob.Producto1.ToString();
                    Datos[2] = ob.CantiDispo.ToString();
                    Datos[3] = ob.Precio1.ToString();
                    RegistroDatos.Rows.Add(Datos);
                    Limpiar();

                }
            }
            catch
            {
                MessageBox.Show("No puede ingresar valores en blancos");
            }
        }



            private void Form1_Load(object sender, EventArgs e)
        {
            RegistroDatos.AllowUserToAddRows = false;
            txtBuscar.Enabled = false;
            txtP.Enabled = false;
            txtC.Enabled = false;
            txtPreciooo.Enabled = false;
            txtPAgo.Enabled = false;
            RegistroDatos2.AllowUserToAddRows = false;
            dateTimePicker1.Visible = false;
            txtCDispo.Enabled= false;
            txtProducto.Enabled=false;
        }

        private void chBuscar_CheckedChanged(object sender, EventArgs e)
        {
            if (chBuscar.Checked == true)
            {
                txtBuscar.Enabled = true;
            }
        }
        int strFila = 0;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                RegistroDatos.DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                foreach (DataGridViewRow Row in RegistroDatos.Rows)
                {


                    strFila = Convert.ToInt32(Row.Index.ToString());
                    string valor = Convert.ToString(Row.Cells["Codigo"].Value);
                    string valor2 = Convert.ToString(Row.Cells["Producto"].Value);
                    if (valor == this.txtBuscar.Text || valor2 == this.txtBuscar.Text)
                    {
                        this.RegistroDatos.CurrentCell = null;

                        int f = RegistroDatos.RowCount;
                        for (int i = f - 1; i >= 0; i--)
                        {
                            this.RegistroDatos.CurrentCell = null;
                            this.RegistroDatos.Rows[i].Visible = false;
                            this.RegistroDatos.Rows[strFila].Visible = true;
                        }
                        RegistroDatos.Rows[strFila].DefaultCellStyle.BackColor = Color.Green;
                        chBuscar.Checked = false;
                        txtBuscar.Text = String.Empty;
                        txtBuscar.Enabled = false;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("𝓔𝓢𝓣𝓐 𝓢𝓔𝓖𝓤𝓡𝓞 𝓓𝓔 𝓢𝓐𝓛𝓘𝓡?",
                        "Venta De Producto",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void btnBorrarFila_Click(object sender, EventArgs e)
        {
            int NumRowseSelect;//Variable conmtadora
            NumRowseSelect = RegistroDatos.CurrentRow.Index;
            RegistroDatos.Rows.RemoveAt(NumRowseSelect);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCodigo.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Por favor solo ingrese numeros.");
                txtCodigo.Text = txtCodigo.Text.Remove(txtCodigo.Text.Length - 1);
            }

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCliente.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Solo ingrese letras!!");
                txtCliente.Text = txtCliente.Text.Remove(txtCliente.Text.Length - 1);
            }
        }
        public void clean()
        {

            int f = RegistroDatos.RowCount;
            for (int i = f - 1; i >= 0; i--)
            {
                RegistroDatos.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            for (int i = f - 1; i >= 0; i--)
            {
                this.RegistroDatos.CurrentCell = null;
                this.RegistroDatos.Rows[i].Visible = true;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clean();
        }

        public void Limpiar2()
        {

            txtCliente.Text = string.Empty;
            txtApellido.Text=string.Empty;
            txtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtPAgo.Text = string.Empty;
            txtCDispo.Text = string.Empty;
            cboTipoDpago.Text = string.Empty;
            lblTotal.Text = string.Empty;
            lblCambio.Text = string.Empty;
            lblPrecio.Text=string.Empty;
            txtCliente.Focus();




        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Metodos met = new Metodos();

            string fecha, apellidoClien, Tipago;
            double cantidad, precio;
            fecha = dateTimePicker1.Text;
            met.Cliente = txtCliente.Text;
            apellidoClien = txtApellido.Text;
            met.Producto1 = txtProducto.Text;
            cantidad = Convert.ToDouble(txtCantidad.Text);
            met.Pago = double.Parse(txtPAgo.Text);
            met.Total = double.Parse(lblTotal.Text);
            int CantAvender = int.Parse(txtCantidad.Text);
            int cantidadDisponible = int.Parse(txtCDispo.Text);



            precio = Convert.ToDouble(lblPrecio.Text);
            lblTotal.Text = met.TotalPrecio(precio, cantidad).ToString();
            Tipago = cboTipoDpago.Text;
            lblCambio.Text = met.Cambio(met.Total, met.Pago).ToString();
            if (CantAvender > cantidadDisponible)
            {
                MessageBox.Show("No hay suficiente cantidad disponible para la venta.", "Error de venta");
                cboProducto.SelectedIndex = -1;
                txtCantidad.Clear();
                cboTipoDpago.SelectedIndex = -1;
                return;
            }

            string[] fact = new string[10];

            fact[0] = met.Cliente.ToString();
            fact[1] = apellidoClien;
            fact[2] = txtProducto.Text;
            fact[3] = Convert.ToString(cantidad);
            fact[4] = cboTipoDpago.Text;
            fact[5] = met.Pago.ToString();
            fact[6] = Convert.ToString(precio);
            fact[7] = lblTotal.Text;
            fact[8] = dateTimePicker1.Text;

            RegistroDatos2.Rows.Add(fact);
            Limpiar2();

          /*  DataGridViewRow row = RegistroDatos2.CurrentRow;

            if (row != null)
            {
                //   row.Cells["CantidadDispo"].Value = txtC.Text;
            }*/

            txtCliente.Enabled = true;
            txtApellido.Enabled = true;
            txtCantidad.Enabled = true;
            cboTipoDpago.Enabled = true;
            RegistroDatos2.Enabled = true;
            dateTimePicker1.Visible = false;
            foreach (DataGridViewRow row in RegistroDatos.Rows)
            {
                if (row.Cells["Producto"].Value.ToString() == met.Producto1 )
                {
                    row.Cells["CantidadDispo"].Value = cantidadDisponible - CantAvender;
                    break;
                }

            }
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int indice = cboTipoFormato.SelectedIndex;


            switch (indice)
            {

                case 0:
                    objExcel.Application objAplicacion = new objExcel.Application();
                    Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

                    objAplicacion.Visible = false;



                    foreach (DataGridViewColumn columna in RegistroDatos2.Columns)
                    {
                        objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;
                        foreach (DataGridViewRow fila in RegistroDatos2.Rows)
                        {
                            objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
                        }
                    }

                    objLibro.SaveAs(ruta + "\\Registro.xlsx");
                    objLibro.Close();
                    MessageBox.Show("Se creo el archivo excel correctamente");

                    break;


                case 1:

                    PdfPTable pdfTable = new PdfPTable(RegistroDatos2.ColumnCount);

                    pdfTable.DefaultCell.Padding = 3;

                    pdfTable.WidthPercentage = 70;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;

                    foreach (DataGridViewColumn column in RegistroDatos2.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                        pdfTable.AddCell(cell);
                    }
                    foreach (DataGridViewRow row in RegistroDatos2.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value == null)
                            {

                            }
                            else
                            {
                                pdfTable.AddCell(cell.Value.ToString());

                            }


                        }
                    }

                    string folderPath = "C:\\Users\\user\\Desktop\\Pdf";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    using (FileStream stream = new FileStream(folderPath + "Registro.pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);

                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("Se creo el archivo pdf correctamente");
                    }
                    break;

            }
        }

        private void txtPAgo_KeyDown(object sender, KeyEventArgs e)
        {
            Metodos metodos = new Metodos();

            double pago, total;

            if (txtPAgo.Text == "")
            {
                lblCambio.Text = "0";
            }
            else if (e.KeyCode == Keys.Enter)
            {
                pago = Convert.ToDouble(txtPAgo.Text);
                total = Convert.ToDouble(lblTotal.Text);
                if (pago < total)
                {
                    MessageBox.Show("El pago es insuficiente");
                }
                else
                {
                    double cambio;

                    total = Convert.ToDouble(lblTotal.Text);
                    pago = Convert.ToDouble(txtPAgo.Text);

                    cambio = metodos.Cambio(total, pago);

                    lblCambio.Text = Convert.ToString(cambio);

                    btnFacturar.Enabled = true;
                    btnImprimir.Enabled = true;
                }
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                lblTotal.Text = "0";
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debe ingresar una cantidad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                else
                {

                    Metodos metodos = new Metodos();

                    double cantidad, precio, total, cantidadn, nueva;
                    cantidadn = Convert.ToDouble(txtC.Text);
                    cantidad = Convert.ToDouble(txtCantidad.Text);
                    precio = Convert.ToDouble(lblPrecio.Text);
                    total = metodos.Cambio(cantidad, precio);
                    lblTotal.Text = total.ToString();

                    nueva = metodos.CantidadNueva(cantidadn, cantidad);
                    txtC.Text = Convert.ToString(nueva);
                }
            }
            
        }

        private void RegistroDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtP.Text = RegistroDatos.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
            txtC.Text = RegistroDatos.Rows[e.RowIndex].Cells["CantidadDispo"].Value.ToString();
            txtPreciooo.Text = RegistroDatos.Rows[e.RowIndex].Cells["precioU"].Value.ToString();
            txtProducto.Text = RegistroDatos.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
            lblPrecio.Text = RegistroDatos.Rows[e.RowIndex].Cells["precioU"].Value.ToString();
            txtCDispo.Text= RegistroDatos.Rows[e.RowIndex].Cells["CantidadDispo"].Value.ToString();

            txtCliente.Enabled = true;
            txtApellido.Enabled = true;
            txtCantidad.Enabled = true;
            cboTipoDpago.Enabled = true;
            RegistroDatos2.Enabled = true;
            dateTimePicker1.Visible = true;
        }

        private void cboTipoDpago_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            Metodos metodos = new Metodos();

            double total;

            if (cboTipoDpago.SelectedIndex == 0)
            {
                txtPAgo.Enabled = true;
                txtPAgo.Text = "";
            }
            else
            {
                txtPAgo.Enabled = false;
                total = metodos.Paago(Convert.ToDouble(lblTotal.Text));
                txtPAgo.Text = Convert.ToString(total);
                lblCambio.Text = "0";
                btnFacturar.Enabled = true;
                btnImprimir.Enabled = true;
            }
        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCantidad.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Por favor solo ingrese numeros.");
                txtCantidad.Text = txtCantidad.Text.Remove(txtCantidad.Text.Length - 1);
            }
        }
    }
}

