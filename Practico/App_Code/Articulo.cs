using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Articulo
{
    int codArt;
    string nombre;
    double precio;

    public int CodArt
    {
        get { return codArt; }
        set { codArt = value; }
    }
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public Articulo(int pcodArt, string pNombre, double pPrecio)
    {
        codArt = pcodArt;
        nombre = pNombre;
        precio = pPrecio;
    }
}