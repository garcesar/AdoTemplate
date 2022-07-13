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

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void Limpio()
    {
        txtcarga.Text = "";
        txtnombre.Text = "";
        txtnumero.Text = "";
        lbAldeMat.Items.Clear();
        LBAlumnos.Items.Clear();
        lbmaterias.Items.Clear();
    }
     
     protected void btnmostrar_Click(object sender, EventArgs e)
    {
        //Creo la conexión
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        //Creo comando para ejecutar el alta
        SqlCommand cmd = new SqlCommand("BuscarMateria", cnn);
        //Aplicamos un CommandType para ejecutar el procedimiento almacenado
        cmd.CommandType = CommandType.StoredProcedure;

        //--Opciones para consultar los datos en la db

        //Opcion 1
        cmd.Parameters.AddWithValue("@id", txtnumero.Text);

        //Opcion 2
        //SqlParameter parametro = new SqlParameter("@id", txtnumero.Text);
        //cmd.Parameters.Add(parametro);

        try
        {
            cnn.Open(); //Se abre la conexión a la db
            SqlDataReader lector = cmd.ExecuteReader();

            if(lector.HasRows)
            {
                lector.Read();
                txtnombre.Text = lector[1].ToString();
                txtcarga.Text = lector[2].ToString();

                lector.Close();
            }
            else
            {
                this.Limpio();
                lblresultado.Text = "No hay datos";
            }
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
            throw;
        }
        finally
        {
            cnn.Close();
        }
    }

    protected void btnagregar_Click(object sender, EventArgs e)
     {
        //Creo la conexión
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        //Creo comando para ejecutar el alta
        SqlCommand cmd = new SqlCommand("Agregar", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        //-- Consulta a la db

        //Opcion 1
        cmd.Parameters.AddWithValue("@idMateria", txtnumero.Text);
        cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
        cmd.Parameters.AddWithValue("@carga", txtcarga.Text);

        SqlParameter retorno = new SqlParameter();
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();

            if (Convert.ToInt32(retorno.Value) == -1)
                lblresultado.Text = "Id Materia Duplicado - No Alta";
            else if (Convert.ToInt32(retorno.Value) == -2)
                lblresultado.Text = "Error en el alta de la materia";
            else
                lblresultado.Text = "Alta con Éxito";

            this.Limpio();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

     protected void btnmodificar_Click(object sender, EventArgs e)
     {
        //Creo la conexión
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        //Creo comando para ejecutar el alta
        SqlCommand cmd = new SqlCommand("Modificar", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        //-- Consulta a la db

        //Opcion 1
        cmd.Parameters.AddWithValue("@idMateria", txtnumero.Text);
        cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
        cmd.Parameters.AddWithValue("@carga", txtcarga.Text);

        SqlParameter retorno = new SqlParameter();
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();

            if (Convert.ToInt32(retorno.Value) == -1)
                lblresultado.Text = "Id Materia no existe - No Modifica";
            else if (Convert.ToInt32(retorno.Value) == -2)
                lblresultado.Text = "Error en la modificación de la materia";
            else
                lblresultado.Text = "Modificación con Éxito";

            this.Limpio();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

     protected void btnEliminar_Click(object sender, EventArgs e)
     {
        //Creo la conexión
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        //Creo comando para ejecutar el alta
        SqlCommand cmd = new SqlCommand("Eliminar", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        //-- Consulta a la db

        //Opcion 1
        cmd.Parameters.AddWithValue("@idMateria", txtnumero.Text);

        SqlParameter retorno = new SqlParameter();
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);

        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();

            if (Convert.ToInt32(retorno.Value) == -1)
                lblresultado.Text = "Id Materia no existe - No Elimina";
            else if (Convert.ToInt32(retorno.Value) == -2)
                lblresultado.Text = "Materia con Alumnos - No Elimina";
            else
                lblresultado.Text = "Eliminación con Éxito";

            this.Limpio();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

     protected void BtnListarAl_Click(object sender, EventArgs e)
     {
        //Creo la conexión
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        //Creo comando para ejecutar el alta
        SqlCommand cmd = new SqlCommand("InscriptosAmateria", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Id", txtnumero.Text);

        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                lbAldeMat.Items.Add(lector["ci"].ToString() + " - " + lector["nombre"].ToString() + " - " + lector["direccion"].ToString());
            }

            lector.Close();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

     protected void btnParamOut_Click(object sender, EventArgs e)
     {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);

        SqlCommand cmd = new SqlCommand("Salida", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@id", txtnumero.Text);

        //Parametro de salida
        SqlParameter sal = new SqlParameter("@nom", SqlDbType.NVarChar, 20);
        sal.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(sal);

        try
        {
            cnn.Open();
            //Devuelve el primer valor de la primer columna de la consulta
            cmd.ExecuteScalar();

            lblresultado.Text = sal.Value.ToString();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
    }

     protected void btnlistarM_Click(object sender, EventArgs e)
     {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);
        SqlCommand cmd = new SqlCommand("SELECT * FROM materias", cnn);

        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                lbmaterias.Items.Add(lector["idmaterias"].ToString() + " " + lector["nombre"].ToString() + " " + lector["cargahoraria"].ToString());
            }
            lector.Close();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
        }
        finally
        {
            cnn.Close();
        }
     }

    protected void btnalumos_Click(object sender, EventArgs e)
     {
        SqlConnection cnn = new SqlConnection(Conexion.Cnn);
        cnn.ConnectionString = Conexion.Cnn;

        SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos", cnn);

        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                lbmaterias.Items.Add(lector["ci"].ToString() + " " + lector["nombre"].ToString());
            }
            lector.Close();
        }
        catch (Exception ex)
        {
            lblresultado.Text = ex.Message;
            throw;
        }
        finally
        {
            cnn.Close();
        }

    }
 
    
}
