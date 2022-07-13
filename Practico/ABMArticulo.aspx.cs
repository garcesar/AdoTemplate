using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;



public partial class ABMArticulo : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        
               
    }
    
    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigo.Enabled = true;
    }
    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = true;

        txtCodigo.Enabled = true;   
    }
    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigo.Enabled = true;

        txtCodigo.Text = "";
        txtNombre.Text = "";
        txtPrecio.Text = "";
        lblError.Text = "";
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        SqlCommand cmd = new SqlCommand("BuscoArticulo", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cod", txtCodigo.Text);

        try
        {
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                ActivoBotonesBM();
                reader.Read();
                txtNombre.Text = reader[1].ToString();
                txtPrecio.Text = reader[2].ToString();

                reader.Close();
            }
            else
            {
                ActivoBotonesA();
                lblError.Text = "El Articulo no existe";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally { cnn.Close(); }
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        SqlCommand cmd = new SqlCommand("AltaArticulo", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cod", txtCodigo.Text);
        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
        cmd.Parameters.AddWithValue("@pre", txtPrecio.Text);

        SqlParameter response = new SqlParameter();
        response.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(response);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();            
            lblError.Text = Convert.ToInt32(response.Value) == -1 ? "El Articulo ya existe." : "Alta con Éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally { cnn.Close(); }
    }

    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        SqlCommand cmd = new SqlCommand("BajaArticulo", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cod", txtCodigo.Text);

        SqlParameter response = new SqlParameter();
        response.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(response);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            lblError.Text = Convert.ToInt32(response.Value) == -1 ? "El Articulo no existe." : "Eliminado con Éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally { cnn.Close(); }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        SqlCommand cmd = new SqlCommand("ModArticulo", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cod", txtCodigo.Text);
        cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
        cmd.Parameters.AddWithValue("@pre", txtPrecio.Text);

        SqlParameter response = new SqlParameter();
        response.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(response);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            lblError.Text = Convert.ToInt32(response.Value) == -1 ? "El Articulo no existe." : "Modificación con Éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally{ cnn.Close(); }
    }
}
