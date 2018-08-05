using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestionDeVentas.BLL;
using GestionDeVentas.Entidades;

namespace GestionDeVentas.Registros
{
    public partial class RVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id;
            this.FechaTextBox.Text = string.Format("{0:G}", DateTime.Now);
            if (!Page.IsPostBack)
            {

                LLenarComboVendedor();


                if (Request.QueryString["Id"] != null)
                {
                    Id = Utilidades.TOINT(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Ventas ventas = new Ventas();
                        VentasBLL.Buscar(Id);

                        Utilidades.ShowToastr(this, "Registro no encontrado", "Error", "Danger");

                    }
                    else
                    {
                        IdTextBox.Text = Id.ToString();

                    }

                }
            }
        }
        public void LLenarComboVendedor()
        {
            VendedorDropDownList1.DataSource = BLL.VendedoresBLL.GetListTodo();
            VendedorDropDownList1.DataTextField = "Nombres";
            VendedorDropDownList1.DataValueField = "VendedorId";
            VendedorDropDownList1.DataBind();

        }
        public void Limpiar()
        {
            IdTextBox.Text = "";
            FechaTextBox.Text = "";
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";


        }


        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void LimpiarCampos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (VendedorDropDownList1.Text == "" || MontoTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "No puede dejar Comision Vacio", "Error", "Danger");
            }
            else
            {


                float total = 0;


                float.TryParse(ConceptoTextBox.Text, out total);
                MontoTextBox.Text = (total * 1.6 / 100).ToString() + "%";

            }
            Ventas ventas = new Ventas();
            VentasBLL.Guardar(ventas);
            Utilidades.ShowToastr(this, "Guardado con Exito", "Exitoso", "success");
        }

        protected void AnularButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "Debes Llenar el campo Id", "Error", "Danger");
            }
            else
            {
                if (VentasBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)) == null)
                {
                    Utilidades.ShowToastr(this, "Registro no encontrado", "Error", "Danger");


                }
                else
                {
                    VentasBLL.Eliminar(Utilidades.TOINT(IdTextBox.Text));
                    Utilidades.ShowToastr(this, "Poceso Exitoso", "Exitoso", "success");
                }

            }
        }
    }
}