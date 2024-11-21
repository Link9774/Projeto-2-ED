public class Pilha<T>
{
    private LinkedList<T> elementos;

    public Pilha()
    {
        elementos = new LinkedList<T>();
    }

    public void Empilhar(T item)
    {
        elementos.Add(item);
    }

    public T Desempilhar()
    {
        if(IsEmpty())
        {
            throw new InvalidOperationException("Pilha está vazia");
        }

        int topoIndex = elementos.Count() - 1;
        T item = elementos.GetAt(topoIndex);
        elementos.RemoveAt(topoIndex);
        return item;
    }
    public T Topo()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Pilha está vazia");
        }
        return elementos.GetAt(elementos.Count() - 1);
    }
    public bool IsEmpty()
    {
        return elementos.Count() == 0;
    }

    public int Tamanho()
    {
        return elementos.Count();
    }

    public void LimparP()
    {
        elementos.Clear();
    }

}