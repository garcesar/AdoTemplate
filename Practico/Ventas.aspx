<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ventas.aspx.cs" Inherits="Ventas" %>


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
        .auto-style2 {
            width: 411px;
        }
    </style>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <div class="style1">
        <span class="style2">Alta de Ventas</span><br />
        <br />
         <table border="1">
        <tr>
            <td class="auto-style2"> Fecha: <asp:TextBox ID="TxtFecha" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Articulos <asp:DropDownList ID="ddlArticulo" runat="server"> </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Cantidad <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Articulos Vendidos </td>
        </tr>
        <td class="auto-style2">
            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False"  
                Height="197px"  
                style="text-align: center" Width="456px">
                <Columns>
                    <asp:BoundField DataField="CodArt" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                </Columns>
            </asp:GridView>
        </td>
        <tr>
            <td class="auto-style2"> Total: <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox> </td>        
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnAgregar" runat="server" Text="Alta" Enabled="true" OnClick="BtnAlta_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style2"> &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="Red" Width="228px"></asp:Label></td>
        </tr>
        </table>
        <br />
        &nbsp;<br />
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>

