using System;
using System.Collections.Generic;

// Nodo genérico con un dato abstracto (en este ejemplo, Empleado)
public class Nodo<T>
{
    public T Dato { get; set; }
    public Nodo<T> Izquierda { get; set; }
    public Nodo<T> Derecha { get; set; }

    public Nodo(T dato)
    {
        Dato = dato;
        Izquierda = null;
        Derecha = null;
    }
}

// Clase ejemplo para el tipo de dato abstracto: Empleado
public class Empleado
{
    public string Nombre { get; set; }
    public string Cargo { get; set; }

    public Empleado(string nombre, string cargo)
    {
        Nombre = nombre;
        Cargo = cargo;
    }

    public override string ToString() => $"{Nombre} ({Cargo})";
}