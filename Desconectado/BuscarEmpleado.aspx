﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuscarEmpleado.aspx.cs" Inherits="BuscarEmpleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            
        }
        .style2
        {
         
            height: 18px;
        }
        .style3
        {
          
            height: 18px;
        }
        .style4
        {
          
            height: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style= "height:; width: 303px;" 151px;" border="1">
            <tr>
                <td class="style2">
                    <asp:Label ID="lblnumero" runat="server" Text="Cedula"></asp:Label></td>
                <td class="style3">
                    <asp:TextBox ID="txtCedula" runat="server" Width="184px"></asp:TextBox>
                    </td>
                <td class="style4">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" 
                        Text="Buscar " Width="106px" /></td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblnombre" runat="server" Text="Nombre"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtnombre" runat="server" Width="229px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    Edad</td>
                <td colspan="2">
                    <asp:TextBox ID="txtEdad" runat="server" Width="77px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1">
                    Sueldo</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSueldo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Casado</td>
                <td colspan="2">
                    <asp:CheckBox ID="chkCasado" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Empresa en que trabaja</td>
                <td colspan="2">
                    <asp:Label ID="lblEmpresa" runat="server" Width="300px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblError" runat="server" Width="595px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
