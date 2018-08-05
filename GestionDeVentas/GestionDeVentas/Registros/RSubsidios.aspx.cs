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
    public partial class RSubsidios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.FechaTextBox.Text = string.Format("{0:G}", DateTime.Now);

            if (!Page.IsPostBack)
            {

                LLenarComboVendedor();

            }

            int Id;
            {
                if (IsPostBack == false)
                {

                    if (Request.QueryString["Id"] != null)
                    {
                        Id = Utilidades.TOINT(Request.QueryString["Id"].ToString());

                        if (Id > 0)
                        {
                            Subsidios subsidios = new Subsidios();
                            SubsidiosBLL.Buscar(Id);

                            Utilidades.ShowToastr(this, "Registro no encontrado", "Error", "Danger");
                            Limpiar();
                        }
                        else
                        {
                            IdTextBox.Text = Id.ToString();

                        }

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


        public void Llenar(Subsidios subsidios)
        {
            float Monto = Convert.ToSingle(MontoTextBox.Text);
        }

      
        public void BuscarSubcidios(Entidades.Subsidios s)
        {
            if (SubsidiosBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)) == null)
            {
                Utilidades.ShowToastr(this, "No Existe", "Que Mal", "Error");


            }
            else
            {


                ConceptoTextBox.Text = s.Concepto;
                s.Fecha = Convert.ToDateTime(FechaTextBox.Text);
                MontoTextBox.Text = Convert.ToString(s.Monto);


            }
        }

        public void Limpiar()
        {
            IdTextBox.Text = "";

            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "Debes Llenar el Campo Id  ", "Advertencia", "Warning");
            }
            else
            {
                BuscarSubcidios(SubsidiosBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)));
            }
        }

        protected void LimpiarCampos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ConceptoTextBox.Text == "" || MontoTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "Completar Campos (*)  ", "Advertencia", "Warning");
            }
            else
            {
                Subsidios subsidios = new Subsidios();
                Llenar(subsidios);
                SubsidiosBLL.Guardar(subsidios);
                Utilidades.ShowToastr(this, "Guardado con Exitos", "Exito", "success");
            }
        }

        protected void AnularButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "Debes Llenar el Campo Id  ", "Advertencia", "Warning");
            }
            else
            {
                SubsidiosBLL.Eliminar(Utilidades.TOINT(IdTextBox.Text));
                Utilidades.ShowToastr(this, "Proceso Completado", "Exito", "success");
            }
        }
    }
}