using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class ListarArticulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(Conexion.Cnn);
        SqlCommand comando = new SqlCommand("SELECT * FROM Articulos", con);
        List<Articulo> colArt = new List<Articulo>();
        try
        {
            con.Open();
            SqlDataReader dr = comando.ExecuteReader(); 
            while (dr.Read()) 
            {
                colArt.Add(new Articulo(Convert.ToInt32(dr["CodArt"]), dr["NomArt"].ToString(), Convert.ToDouble(dr["PreArt"])));
            }
            Session["lista"] = colArt;

            gvListado.DataSource = colArt;
            gvListado.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally { con.Close(); }
    }

}
