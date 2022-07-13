
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlesLista.aspx.cs" Inherits="ControlesLista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlAlumno" runat="server">
            </asp:DropDownList>
            <asp:Label ID="lblDatos" runat="server" Text="lblDatos"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Ci" HeaderText="Cedula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="lblError" runat="server" Text="lblError"></asp:Label>
        </div>
    </form>
</body>
</html>
