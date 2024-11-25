class Fila<T>
{
    private LinkedList<T> elementos;
    private int contador;

    public Fila()
    {
        elementos = new LinkedList<T>();
        contador = 0;
    }

    public void Queue(T item)
    {
        elementos.Add(item);
        contador++;
    }
    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Fila está vazia");
        }
        T item = elementos.GetAt(0);
        elementos.RemoveAt(0);
        contador --;
        return item;
    }
    public T Inicio()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Fila está vazia");
        }
        return elementos.GetAt(0);
    }
    public bool IsEmpty()
    {
        return elementos.Count() == 0;
    }

    public int Size()
    {
        return contador;
    }
public void Clear()
{
    elementos.Clear();
    contador = 0;
}

}
