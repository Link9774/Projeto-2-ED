class NodeF<T>
{
    public T Data;
    public NodeF<T> Next;

    public NodeF(T data)
    {
        Data = data;
        Next = null;
    }
}

class PriorityQueue<T>
{
    private NodeF<T> head;
    private readonly Func<T, T, int> _comparer;

    public PriorityQueue(Func<T, T, int> comparer)
    {
        _comparer = comparer;
        head = null;
    }

    public void Enqueue(T data)
    {
        NodeF<T> newNodeF = new NodeF<T>(data);

        if (head == null || _comparer(data, head.Data) < 0)
        {
            newNodeF.Next = head;
            head = newNodeF;
        }
        else
        {
            NodeF<T> current = head;
            while (current.Next != null && _comparer(current.Next.Data, data) <= 0)
            {
                current = current.Next;
            }
            newNodeF.Next = current.Next;
            current.Next = newNodeF;
        }
    }

    public T Dequeue()
    {
        if (head == null) return default(T);

        T data = head.Data;
        head = head.Next;
        return data;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public void Display()
    {
        NodeF<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}