using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conexion
/// </summary>
public class Conexion
{
    private static string _cnn = "Data Source=MASTERW10; Initial Catalog=Universidad; Integrated Security=true";

    public static string Cnn
    {
        get { return _cnn; }
    }   
}