<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploDataSet.aspx.cs" Inherits="EjemploDataSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Lista de Empleados:<br />
        </strong>
        <br />
        <asp:GridView ID="gvEmpleado" runat="server" Height="133px" Width="382px">
        </asp:GridView>
        <br />
        <asp:Button ID="btnListar" runat="server" Font-Bold="True" OnClick="btnCargar_Click"
            Text="Listar Empleados" Width="200px" />
        <br />
        <br />
        <asp:Button ID="btnActualizar" runat="server" Font-Bold="True" 
            Text="Actualizar Edad Empleados" Width="200px" OnClick="btnBorrar_Click" />
        <br />
        <br />
        <asp:Button ID="btnActualizo" runat="server" Font-Bold="True" 
            Text="ActualizarBD" Width="200px" OnClick="btnActualizo_Click" />&nbsp;<br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
