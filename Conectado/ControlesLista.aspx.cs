using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class ControlesLista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(Conexion.Cnn);
        SqlCommand comando = new SqlCommand("SELECT * FROM Alumnos", con);
        List<Alumno> colAlumnos = new List<Alumno>();
        try
        {
            con.Open();
            SqlDataReader dr = comando.ExecuteReader(); //Obtenemos el resultado de la consulta
            while (dr.Read()) //Mientras tenga obj para leer agregamos a la lista
            {
                colAlumnos.Add(new Alumno(Convert.ToInt32(dr["ci"]), dr["nombre"].ToString(), dr["direccion"].ToString()));
            }
            Session["lista"] = colAlumnos;

            //Cargo DropDownList
            ddlAlumno.DataSource = colAlumnos;
            ddlAlumno.DataTextField = "Nombre";
            ddlAlumno.DataValueField = "Ci";
            ddlAlumno.DataBind();

            //Cargo DataGrid
            GridView1.DataSource = colAlumnos;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally { con.Close(); }
    }

    protected void ddlAlumno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Session["lista"] != null)
        {
            List<Alumno> colAlumnos = (List<Alumno>)Session["lista"];
            int ci = Convert.ToInt32(ddlAlumno.SelectedValue);
            Alumno al = colAlumnos.ElementAt(ddlAlumno.SelectedIndex);
            lblDatos.Text = ci.ToString() + " - " + al.Direccion;
        }
    }
}