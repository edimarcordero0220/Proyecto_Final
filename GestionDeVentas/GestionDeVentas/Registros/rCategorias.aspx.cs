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
    public partial class rCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id;
            if (IsPostBack == false)
            {

                if (Request.QueryString["Id"] != null)
                {
                    Id = Utilidades.TOINT(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Categorias c = new Categorias();
                        CategoriasBLL.Buscar(Id);

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
        public void LlenarClase(Categorias c)
        {
            c.Nombre = ConceptoTextBox.Text;
            c.MaximoVentaDefault = Utilidades.TOINT(MontoTextBox.Text);
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
                BuscarCategorias(CategoriasBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)));
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
                Entidades.Categorias c = new Entidades.Categorias();
                LlenarClase(c);
                CategoriasBLL.Insertar(c);
                Utilidades.ShowToastr(this, "Proceso Completado", "Exito", "success");
                Limpiar();
            }
        }
        public void BuscarCategorias(Entidades.Categorias c)
        {
            if (CategoriasBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)) == null)
            {
                Utilidades.ShowToastr(this, "No Existe", "Que Mal", "Error");


            }
            else
            {

                ConceptoTextBox.Text = c.Nombre;

                MontoTextBox.Text = Convert.ToString(c.MaximoVentaDefault);


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
                if (CategoriasBLL.Buscar(Utilidades.TOINT(IdTextBox.Text)) == null)
                {
                    Utilidades.ShowToastr(this, "No Existe", "Que Mal", "Error");

                }
                else
                {
                    CategoriasBLL.Eliminar(Utilidades.TOINT(IdTextBox.Text));
                    Utilidades.ShowToastr(this, "Proceso Completado", "Exito", "success");
                }

            }
        }
    }
}