using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestionDeVentas.BLL;
using GestionDeVentas.Entidades;

namespace GestionDeVentas.Consultas
{
    public partial class cDetalleVendedor : System.Web.UI.Page
    {
        public static List<CuadresVendedorDetalles> Listas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listas = BLL.DetalleCuadreBLL.GetListTodo();

                ConsultaClienteGridView.DataSource = Listas;
                ConsultaClienteGridView.DataBind();
            }
        }
        private void BuscarSelecCombo()
        {
            Listas = null;

            if (FiltrarDropDownList.SelectedIndex == 0)
            {
                Listas = BLL.DetalleCuadreBLL.GetListTodo();

            }
            else if (FiltrarDropDownList.SelectedIndex == 1)
            {
                if (BuscarTextBox.Text == "")
                {
                    base.Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe de Insertar la descripcion');</script>");
                }
                else
                {
                    int Busqueda = Utilidades.TOINT(BuscarTextBox.Text);
                    Listas = BLL.DetalleCuadreBLL.GetList(p => p.CuadreId == Busqueda);
                    ConsultaClienteGridView.DataSource = Listas;
                    ConsultaClienteGridView.DataBind();
                }
            }
            else if (FiltrarDropDownList.SelectedIndex == 2)
            {
                if (BuscarTextBox.Text == "")
                {
                    base.Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe de Insertar la descripcion');</script>");
                }
                else
                {
                    int Busqueda = Utilidades.TOINT(BuscarTextBox.Text);
                    Listas = BLL.DetalleCuadreBLL.GetList(p => p.Id == Busqueda);
                    ConsultaClienteGridView.DataSource = Listas;
                    ConsultaClienteGridView.DataBind();
                }
            }
          
            ConsultaClienteGridView.DataSource = Listas;
            ConsultaClienteGridView.DataBind();
        }
        private bool ValidarBuscar()
        {
            if (BLL.DetalleCuadreBLL.Buscar(String(BuscarTextBox.Text)) == null)
            {
                base.Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No Existe');</script>");
                return false;

            }

            return true;


        }

        public int String(string texto)
        {
            int numero = 0;
            int.TryParse(texto, out numero);
            return numero;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            if (BuscarTextBox.Text == "")
            {
                base.Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe de Insertar la descripcion');</script>");
            }
            else
            {
                BuscarSelecCombo();
                ValidarBuscar();
            }
        }
    }
}