using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

public partial class ListarEmpdeEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!IsPostBack)
            {
                SqlConnection conexion = new SqlConnection(Conexion.Cnn); //Conexión a la databse
                SqlDataAdapter oAdaptador = new SqlDataAdapter("ListarEmpresas", conexion); // Para trabajar de forma desconectada

                DataSet ds = new DataSet();
                oAdaptador.Fill(ds, "Empresas");

                //Cargo la lista con datos
                cbEmpresa.DataSource = ds.Tables["Empresas"];

                //Determino que dato se muestra y cual dato asociado se devuelve
                cbEmpresa.DataTextField = "Nombre";
                cbEmpresa.DataValueField = "Ruc";
                cbEmpresa.DataBind();
            }
        }
        catch (SqlException ex)
        {
            lblError.Text = "ERROR SQL: " + ex.Message;
        }
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        SqlConnection conexion = new SqlConnection(Conexion.Cnn); //Conexión a la databse

        try
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("EmpleadosPorRuc " + cbEmpresa.SelectedValue, conexion);
            DataSet ds = new DataSet();

            adaptador.Fill(ds, "Empleados");

            gvEmpleado.DataSource = ds.Tables["Empleados"];
            gvEmpleado.DataBind();
        }
        catch (SqlException ex)
        {
            lblError.Text = "ERROR SQL: " + ex.Message;
        }
    }
}
