// Árbol Binario genérico
public class ArbolBinario<T>
{
    public Nodo<T> Raiz { get; set; }

    // Insertar un nuevo nodo en el árbol (ejemplo básico para árbol binario de búsqueda con comparación por string)
    public void Insertar(T dato, Func<T, T, int> comparador)
    {
        Raiz = InsertarRecursivo(Raiz, dato, comparador);
    }

    private Nodo<T> InsertarRecursivo(Nodo<T> nodo, T dato, Func<T, T, int> comparador)
    {
        if (nodo == null) return new Nodo<T>(dato);

        int cmp = comparador(dato, nodo.Dato);
        if (cmp < 0)
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, dato, comparador);
        else if (cmp > 0)
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, dato, comparador);

        return nodo;
    }

    // 1. Obtener hijos de un nodo
    public void ObtenerHijos(Nodo<T> nodo)
    {
        if (nodo != null)
        {
            Console.WriteLine($"Hijos de {nodo.Dato}:");
            if (nodo.Izquierda != null)
                Console.WriteLine($"  Izquierdo: {nodo.Izquierda.Dato}");
            if (nodo.Derecha != null)
                Console.WriteLine($"  Derecho: {nodo.Derecha.Dato}");
            if (nodo.Izquierda == null && nodo.Derecha == null)
                Console.WriteLine("  No tiene hijos");
        }
    }

    // 2. Obtener padre de un nodo
    public Nodo<T> ObtenerPadre(Nodo<T> nodo, T dato, Nodo<T> padre = null)
    {
        if (nodo == null) return null;

        if (nodo.Dato.Equals(dato))
            return padre;

        Nodo<T> encontrado = ObtenerPadre(nodo.Izquierda, dato, nodo);
        if (encontrado == null)
            encontrado = ObtenerPadre(nodo.Derecha, dato, nodo);

        return encontrado;
    }

    // 3. Nodos interiores
    public void MostrarNodosInteriores(Nodo<T> nodo)
    {
        if (nodo != null)
        {
            if (nodo.Izquierda != null || nodo.Derecha != null)
                Console.WriteLine($"Nodo interior: {nodo.Dato}");

            MostrarNodosInteriores(nodo.Izquierda);
            MostrarNodosInteriores(nodo.Derecha);
        }
    }

    // 4. Nodos hoja
    public void MostrarHojas(Nodo<T> nodo)
    {
        if (nodo != null)
        {
            if (nodo.Izquierda == null && nodo.Derecha == null)
                Console.WriteLine($"Hoja: {nodo.Dato}");

            MostrarHojas(nodo.Izquierda);
            MostrarHojas(nodo.Derecha);
        }
    }

    // 5. Grado de un nodo
    public int GradoNodo(Nodo<T> nodo)
    {
        int grado = 0;
        if (nodo.Izquierda != null) grado++;
        if (nodo.Derecha != null) grado++;
        return grado;
    }

    // 6. Nivel de un nodo
    public int NivelDeNodo(Nodo<T> nodo, T dato, int nivelActual = 0)
    {
        if (nodo == null) return -1;
        if (nodo.Dato.Equals(dato)) return nivelActual;

        int nivelIzq = NivelDeNodo(nodo.Izquierda, dato, nivelActual + 1);
        if (nivelIzq != -1) return nivelIzq;

        return NivelDeNodo(nodo.Derecha, dato, nivelActual + 1);
    }

    // 7. Longitud de camino interno
    public int LongitudCaminoInterno(Nodo<T> nodo, int profundidad = 0)
    {
        if (nodo == null) return 0;
        return profundidad + LongitudCaminoInterno(nodo.Izquierda, profundidad + 1) + LongitudCaminoInterno(nodo.Derecha, profundidad + 1);
    }

    // 8. Longitud de camino externo
    public int LongitudCaminoExterno(Nodo<T> nodo, int profundidad = 0)
    {
        if (nodo == null) return profundidad;
        return LongitudCaminoExterno(nodo.Izquierda, profundidad + 1) + LongitudCaminoExterno(nodo.Derecha, profundidad + 1);
    }

    // 12. Eliminar todas las hojas
    public Nodo<T> EliminarHojas(Nodo<T> nodo)
    {
        if (nodo == null) return null;
        if (nodo.Izquierda == null && nodo.Derecha == null) return null;

        nodo.Izquierda = EliminarHojas(nodo.Izquierda);
        nodo.Derecha = EliminarHojas(nodo.Derecha);
        return nodo;
    }

    // 13. Intercambiar subárboles
    public void IntercambiarSubarboles(Nodo<T> nodo)
    {
        if (nodo != null)
        {
            Nodo<T> temp = nodo.Izquierda;
            nodo.Izquierda = nodo.Derecha;
            nodo.Derecha = temp;

            IntercambiarSubarboles(nodo.Izquierda);
            IntercambiarSubarboles(nodo.Derecha);
        }
    }
}