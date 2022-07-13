using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Venta
{
    int codigo;
    DateTime fecha;
    double total;
    int cantidad;
    Articulo art;

    public int Codigo
    {
        get { return codigo; }
        set
        {
            if (value > 0)
                codigo = value;
        }
    }

    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }

    public double Total
    {
        get { return total; }
        set
        {
            if (value > 0)
                total = value * cantidad;
        }
    }

    public int Cantidad
    {
        get { return cantidad; }
        set
        {
            if (value > 0)
                cantidad = value;
        }
    }

    public Articulo Articulo
    {
        get { return art; }
        set
        {
            if (value != null)
                art = value;
        }
    }
    public Venta(int pCodigo, DateTime pFecha, int pCantidad, double pTotal, Articulo pArt)
    {
        Codigo = pCodigo;
        Fecha = pFecha;
        Cantidad = pCantidad;
        Total = pTotal;
        Articulo = pArt;
    }
}