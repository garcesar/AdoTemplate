using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class Ventas : System.Web.UI.Page
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

            ddlArticulo.DataSource = colArt;
            ddlArticulo.DataTextField = "Nombre";
            ddlArticulo.DataValueField = "CodArt";
            ddlArticulo.DataBind();


            //Session["codigo"] = "CodArt";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally { con.Close(); }
    }
    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        if(Session["lista"] != null)
        {

            //Obtengo los Art de la session
            //Articulo _Art = (Articulo)Session["lista"];

            //lblError.Text = Convert.ToString(codArt);



            //lblError.Text = unArt.CodArt.ToString();

            //SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            //SqlCommand cmd = new SqlCommand("AltaVenta", cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@codArt", txtCodigo.Text); // Tengo que obtener el cod de la session
            //cmd.Parameters.AddWithValue("@fecha", TxtFecha.Text);
            //cmd.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
            //cmd.Parameters.AddWithValue("@total", txtTotal.Text); // El calculo ? 

            //SqlParameter response = new SqlParameter();
            //response.Direction = ParameterDirection.ReturnValue;
            //cmd.Parameters.Add(response);

            //try
            //{
            //    cnn.Open();
            //    cmd.ExecuteNonQuery();
            //    lblError.Text = Convert.ToInt32(response.Value) == -1 ? "El Articulo ya existe." : "Alta con Éxito.";
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message;
            //}
            //finally { cnn.Close(); }
        }
        else
        {
            lblError.Text = "No hay datos suficientes para realizar el alta.";
        }
    }
}