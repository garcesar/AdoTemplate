using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class BuscarEmpleado : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DataSet datos = new DataSet();

        try
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn); //Conexión a la databse
            SqlDataAdapter da = new SqlDataAdapter("BuscarEmpleado " + txtCedula.Text, cnn); // Para trabajar de forma desconectada
            da.Fill(datos, "Empleado");

            //Determino si hay resultado, preguntando si almenos hay un registro en la tabla
            if(datos.Tables["Empleados"].Rows.Count > 0)
            {
                //Muestro datos empleado
                DataRow _dr = datos.Tables["Empleado"].Rows[0];
                txtCedula.Text = _dr["decula"].ToString();
                txtnombre.Text = _dr["nombre"].ToString();
                txtEdad.Text = _dr["edad"].ToString();
                txtSueldo.Text = _dr["sueldo"].ToString();
                chkCasado.Checked = Convert.ToBoolean(_dr["casado"]);

                //Busco empresa en la cual trabaj
                SqlDataAdapter otroDa = new SqlDataAdapter("BuscarEmpresa" + _dr["trabajaEn"].ToString(), cnn);
                otroDa.Fill(datos, "Empresa");

                if(datos.Tables["Empresa"].Rows.Count > 0)
                {
                    lblEmpresa.Text = datos.Tables["Empresa"].Rows[0]["ruc"].ToString() + " - " + datos.Tables["Empresa"].Rows[0]["nombre"].ToString();
                }
                else
                {
                    lblError.Text = "No existe la empresa";
                }
            }
        }
        catch (SqlException ex)
        {
            lblError.Text = "ERROR SQL: " + ex.Message;
        }
    }
}