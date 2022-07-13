using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Conexion
{
    private static string _cnn = "Data Source=MASTERW10; Initial Catalog=Empresa; Integrated Security=true";

    public static string Cnn
    {
        get { return _cnn; }
    }
}