<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RSubsidios.aspx.cs" Inherits="GestionDeVentas.Registros.RSubsidios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="panel panel-primary">
        <div class="panel-heading">Registro de Gastos</div>

        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">

               <%-- Input ID--%>
                <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox ID="IdTextBox" runat="server"  placeholder="0" class="form-control input-sm" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:button runat="server" CssClass="btn btn-info btn-block btn-md" text="Busca" ID="BuscarButton" OnClick="BuscarButton_Click" />
                      <%--  <asp:Button ID="BuscarButton" CssClass="btn btn-info btn-block btn-md" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />--%>
                      
                    </div>
                </div>

               <%-- Input VendedorID--%>
                 <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">Vendedor Id: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <%--<asp:DropDownList ID="VendedorDropDownList" runat="server">
                        </asp:DropDownList>--%>
                        <asp:DropDownList ID="VendedorDropDownList1" runat="server">
                        </asp:DropDownList>
                       <%-- <asp:TextBox ID="VendedorIdTextBox" runat="server"  placeholder="0" class="form-control input-sm" TextMode="Number"></asp:TextBox>--%>
                        
                    </div>
                </div>

              <%--  Fecha--%>
                <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">Fecha: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4"> 
                        <asp:TextBox ID="FechaTextBox" runat="server"  class="form-control input-sm" TextMode="Date"></asp:TextBox>
                    </div>
                    
                </div>

              <%--  Input Concepto--%>

                <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">(*) Concepto: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4"> 
                        <asp:TextBox ID="ConceptoTextBox" runat="server"  class="form-control input-sm"></asp:TextBox></div>
                    
                </div>

              <%--  Input Monto--%>

                <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">(*) Monto: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4"> 
                        <asp:TextBox ID="MontoTextBox" runat="server"  class="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>

            </div>

            <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">
                    <asp:button runat="server" class="btn btn-info" text="Limpia" ID="LimpiarCampos" OnClick="LimpiarCampos_Click" />
                    <asp:button runat="server" class="btn btn-success" text="Guarda" ID="GuardarButton" OnClick="GuardarButton_Click" />
                    <asp:button runat="server" class="btn btn-danger" text="Elimina" ID="AnularButton" OnClick="AnularButton_Click" />

                  <%--  <asp:Button class="btn btn-info" ID="LimpiarCampos" runat="server" CausesValidation="False" Text="Limpiar"  TabIndex="1" OnClick="LimpiarCampos_Click" />
                    <asp:Button class="btn btn-success" ID="GuardarButton" runat="server" CausesValidation="True" Text="Guardar"  TabIndex="2" OnClick="GuardarButton_Click" />
                  
                    <asp:Button class="btn btn-danger" ID="AnularButton" runat="server" CausesValidation="False" Text="Eliminar" TabIndex="4" OnClick="AnularButton_Click" />--%>
                </div>
            </div>
        </div>
        </div>

        </div>

</asp:Content>
