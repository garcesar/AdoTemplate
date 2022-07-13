<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="height: 151px; width: 306px;" border="1">
            <tr>
                <td class="style1">
                    <asp:Label ID="lblnumero" runat="server" Text="Numero"></asp:Label></td>
                <td style="width: 190px">
                    <asp:TextBox ID="txtnumero" runat="server" BackColor="#00C0C0"></asp:TextBox>
                    </td>
                <td style="width: 413px; text-align: right;">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnmostrar_Click" 
                        Text="Buscar Materia" Width="110px" /><br />
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblnombre" runat="server" Text="Nombre"></asp:Label></td>
                <td style="width: 190px">
                    <asp:TextBox ID="txtnombre" runat="server" BackColor="#00C0C0"></asp:TextBox></td>
                <td style="width: 413px">
                    <asp:Button ID="btnagregar" runat="server" OnClick="btnagregar_Click" 
                        Text="Agregar" Width="110px" />
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblcarga" runat="server" Text="Carga Horaria" Width="95px"></asp:Label></td>
                <td style="width: 190px">
                    <asp:TextBox ID="txtcarga" runat="server" BackColor="#00C0C0"></asp:TextBox></td>
                <td style="width: 413px; text-align: right;">
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnmodificar_Click" 
                        Text="Modificar " Width="110px" style="text-align: right" />
                    </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td style="width: 190px">
                </td>
                <td style="width: 413px; text-align: right;">
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" 
                        Text="Eliminar" Width="110px" style="text-align: right" />
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2" rowspan="3">
                    <asp:ListBox ID="lbAldeMat" runat="server" Height="137px" Width="358px"></asp:ListBox>
                </td>
                <td style="height: 21px; width: 413px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 413px">
                    <asp:Button ID="BtnListarAl" runat="server" OnClick="BtnListarAl_Click" 
                        Text="Listar Alumnos" Width="110px" style="text-align: right" />
                    </td>
            </tr>
            <tr>
                <td style="width: 413px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td style="width: 190px; height: 21px;">
                </td>
                <td style="width: 413px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td colspan="2">
                    <asp:Button ID="btnParamOutPut" runat="server" 
                        Text="Consulta con Parametros de Salida " OnClick="btnParamOut_Click" 
                        Width="231px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblresultado" runat="server" Width="444px"></asp:Label></td>
            </tr>
            </table>
        <br />
        <br />
        <table style="width: 605px" border="1">
            <tr>
                <td style="width: 55px">
                    <asp:Button ID="btnListarMaterias" runat="server" OnClick="btnlistarM_Click" 
                        Text="Listar Materias " Width="180px" /></td>
                <td style="width: 415px; text-align: center">
                    <asp:ListBox ID="lbmaterias" runat="server" Height="137px" Width="358px"></asp:ListBox></td>
            </tr>
            <tr>
                <td style="width: 55px">
                </td>
                <td style="width: 415px">
                </td>
            </tr>
            <tr>
                <td style="width: 55px">
                    <asp:Button ID="BtnListarAlumnos" runat="server" OnClick="btnalumos_Click" 
                        Text="Listar Alumnos " Width="180px" /></td>
                <td style="width: 415px; text-align: center">
                    <asp:ListBox ID="LBAlumnos" runat="server" Height="137px" Width="358px"></asp:ListBox>&nbsp;</td>
            </tr>
            </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;<br />
    
    </div>
    </form>
</body>
</html>
