using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Alumno
{
    int ci;
    string nombre;
    string direccion;

    public int Ci
    {
        get { return ci; }
        set { ci = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    
    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }

    public Alumno(int pCi, string pNombre, string PDireccion)
    {
        Ci = pCi;
        Nombre = pNombre;
        Direccion = PDireccion;
    }
}