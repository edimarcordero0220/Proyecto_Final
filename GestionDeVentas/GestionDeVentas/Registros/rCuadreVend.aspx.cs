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
    public partial class rCuadreVend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (!Page.IsPostBack)
            {
                LLenarComboVendedor();

            }
        }
        public void LLenarComboVendedor()
        {
            VendedorDropDownList1.DataSource = BLL.VendedoresBLL.GetListTodo();
            VendedorDropDownList1.DataTextField = "Nombres";
            VendedorDropDownList1.DataValueField = "VendedorId";
            VendedorDropDownList1.DataBind();

        }

        public void LlenarClase(CuadresVendedores cv)
        {

            cv.Fecha = Convert.ToDateTime(FechaTextBox.Text);

            cv.Concepto = ConceptoTextBox.Text;
            cv.Monto = Utilidades.TOINT(MontoTextBox.Text);


        }
        public void Limpiar()
        {
            IdTextBox.Text = "";

            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "";

        }
        public void BuscarCuadre(Entidades.CuadresVendedores cv)
        {
            if (CuadreVendedorBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)) == null)
            {
                Utilidades.ShowToastr(this, "No Existe", "Que Mal", "Error");


            }
            else
            {

                ConceptoTextBox.Text = cv.Concepto;
                cv.Fecha = Convert.ToDateTime(FechaTextBox.Text);
                MontoTextBox.Text = Convert.ToString(cv.Monto);


            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "Debes llenar el campo Id", "Ojo", "Error");
            }
            else
            {
                BuscarCuadre(CuadreVendedorBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)));
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ConceptoTextBox.Text == "" || MontoTextBox.Text == "")
            {
                
                Utilidades.ShowToastr(this, "Debes Llenar Todos los Campos", "ojo", "Error");
            }
            else
            {
                Entidades.CuadresVendedores cv = new Entidades.CuadresVendedores();
                LlenarClase(cv);
                CuadreVendedorBLL.Insertar(cv);
                
                Utilidades.ShowToastr(this, "Proceso Completado", "Exito", "success");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Utilidades.ShowToastr(this, "Debes llenar el campo Id", "Ojo", "Error");
            }
            else
            {
                if (CuadreVendedorBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)) == null)
                {
                    Utilidades.ShowToastr(this, "No Existe", "Que Mal", "Error");
                }
                else
                {
                    CuadreVendedorBLL.Eliminar(Utilidades.TOINT(IdTextBox.Text));
                    Utilidades.ShowToastr(this, "Proceso Completado", "Exito", "success");
                    Limpiar();
                }

            }
        }
    }
}