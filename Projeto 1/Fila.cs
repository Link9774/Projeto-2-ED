class Fila<T>
{
    private LinkedList<T> elementos;

    public Fila()
    {
        elementos = new LinkedList<T>();
    }

    public void Queue(T item)
    {
        elementos.Add(item);
    }
    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Fila está vazia");
        }
        T item = elementos.GetAt(0);
        elementos.RemoveAt(0);
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
        return elementos.Count();
    }
public void Clear()
{
    elementos.Clear();
}

}