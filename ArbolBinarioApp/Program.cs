namespace ArbolBinarioApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear árbol binario con Empleados
            var arbol = new ArbolBinario<Empleado>();

            // Insertar datos
            arbol.Insertar(new Empleado("Luis", "Gerente"), (a, b) => a.Nombre.CompareTo(b.Nombre));
            arbol.Insertar(new Empleado("Ana", "Analista"), (a, b) => a.Nombre.CompareTo(b.Nombre));
            arbol.Insertar(new Empleado("Carlos", "Técnico"), (a, b) => a.Nombre.CompareTo(b.Nombre));

            // Ejemplo: mostrar hijos de la raíz
            arbol.ObtenerHijos(arbol.Raiz);

            // Ejemplo: mostrar nodos interiores
            arbol.MostrarNodosInteriores(arbol.Raiz);

            // Ejemplo: mostrar nodos hoja
            arbol.MostrarHojas(arbol.Raiz);

            // Ejemplo: eliminar hojas y mostrar árbol resultante
            arbol.Raiz = arbol.EliminarHojas(arbol.Raiz);
            Console.WriteLine("Después de eliminar hojas:");
            arbol.MostrarNodosInteriores(arbol.Raiz);
        }
    }
}
