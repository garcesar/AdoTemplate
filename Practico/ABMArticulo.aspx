<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMArticulo.aspx.cs" Inherits="ABMArticulo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <div class="style1">
        <span class="style2">Alta de Articulos</span><br />
        <br />
           <table border="1">
        <tr>
            <td> Codigo: </td>
            <td><asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" /></td>
        </tr>
        <tr>
            <td> Nombre: </td>
            <td>  <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox> </td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td> Precio: </td>
            <td> <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox> </td>
            <td>  &nbsp; </td>        
        </tr>
        <tr>
            <td><asp:Button ID="btnAgregar" runat="server" Text="Alta" Enabled="False" OnClick="BtnAlta_Click" /></td>
            <td><asp:Button ID="btnEliminar" runat="server" Text="Baja" Enabled="False" OnClick="BtnBaja_Click" /></td>
            <td><asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="False" OnClick="BtnModificar_Click" /></td>
        </tr>
        <tr>
            <td colspan="3">  &nbsp;  </td>
        </tr>
        <tr>
            <td colspan="3"> &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="Red" Width="228px"></asp:Label></td>
        </tr>
        </table>
        <br />
        &nbsp;<br />
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
