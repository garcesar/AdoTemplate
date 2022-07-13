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

public partial class EjemploDataSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void btnCargar_Click(object sender, EventArgs e)
    {
        SqlConnection conexion = new SqlConnection(Conexion.Cnn); //Conexión a la databse
        SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Cedula,Nombre, Edad FROM Empleados", conexion); //Cargo obj que busca la info en la db
        DataSet DS = new DataSet();
        try
        {
            adaptador.Fill(DS, "Empleados");

            //Cargo la info en la grilla
            gvEmpleado.DataSource = DS.Tables["Empleados"];
            gvEmpleado.DataBind();

            //Mantengo la info en la memoria del servidor
            Session["dataset"] = DS;
        }
        catch (Exception ex)
        {
            lblError.Text = "ERROR SQL: " + ex.Message;
            throw;
        }
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        if(Session["dataset"] != null)
        {
            //Obtengo puntero a la tabla con datos
            DataTable dt = ((DataSet)Session["dataset"]).Tables["Empleados"];

            //Recorro cada registro para dejar la edad en 0
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                dr["edad"] = Convert.ToInt32(dr["edad"]) + 1;
            }

            lblError.Text = "DataSet actualizado";

            //Cargo la info en la grilla
            gvEmpleado.DataSource = dt;
            gvEmpleado.DataBind();
        }
        else
        {
            lblError.Text = "ERROR Actualizar Edades: el dataset no estaba en la Session";
        }

    }

    protected void btnActualizo_Click(object sender, EventArgs e) //Actualizo en la db
    {
        if (Session["dataset"] != null)
        {
            if(!((DataSet)Session["dataset"]).HasChanges())
            {
                lblError.Text = "No se ha modificado ningún dato";
            }
            else
            {
                try
                {
                    DataSet dsCambiado = (DataSet)Session["dataset"];
                    SqlConnection conexion = new SqlConnection(Conexion.Cnn); //Conexión a la databse
                    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Cedula,Nombre, Edad FROM Empleados", conexion); //Cargo obj que busca la info en la db

                    SqlCommandBuilder oConstructorComando = new SqlCommandBuilder(adaptador);
                    adaptador.Update(dsCambiado, "Empleados");
                    dsCambiado.AcceptChanges();

                    lblError.Text = "BD actualizada!";
                }
                catch (Exception ex)
                {
                    lblError.Text = "ERROR SQL: " + ex.Message;
                    throw;
                }
            }
        }
        else
        {
            lblError.Text = "ERROR Actualizar Edades: el dataset no estaba en la Session";
        }
    }
}
