using System.Collections;

class DoubleNode<T>
{
    public T Data;
    public DoubleNode<T> Next;
    public DoubleNode<T> Previous;

    public DoubleNode(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}
class DoubleLinkedList<T> : IEnumerable<T>
{ 
    private DoubleNode<T> head;
    private DoubleNode<T> tail;
    public int Count { get; private set; }
    public void Add(T data)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
    }
 public void Remove(T data)
    {
        if (head == null) return;

        DoubleNode<T> current = head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (current == head)
                {
                    head = current.Next;
                    if (head != null) head.Previous = null;
                }
                else if (current == tail)
                {
                    tail = current.Previous;
                    tail.Next = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                }
                break;
            }
            current = current.Next;
        }
    }

public void RemoveAt(int index)
{
    if(head == null) return;

    DoubleNode<T> current = head;
    int count = 0;
     while (current != null)
        {
            if (count == index)
            {
                if (current == head)
                {
                    head = current.Next;
                    if (head != null) head.Previous = null;
                }
                else if (current == tail)
                {
                    tail = current.Previous;
                    if (tail != null) tail.Next = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                }
                return;
            }
            current = current.Next;
            count++;
        }
}
public void Clear()
{
    head = null;
    tail = null;
}

public void DisplayDireita()
{
    DoubleNode<T> current = head;
    while (current != null)
    {
        Console.WriteLine(current.Data);
        current = current.Next;
    }
}
public void DisplayEsquerda()
{
    DoubleNode<T> current = tail;
    while (current != null)
    {
        Console.WriteLine(current.Data);
        current = current.Previous;
    }

}
public int IndexOf(string data)
{
    DoubleNode<T> current = head;
    int index = 0;
    while (current != null)
    {
        if (current.Data.Equals(data))
        
            return index;
                current = current.Next;
                index++;
        }
        return -1;
    }
    public T GetAt(int index)
    {
        DoubleNode<T> current = head;
        int count = 0;
        while(current != null)
        {
            if(count == index)
                return current.Data;
            current = current.Next;
            count++;
        }
        return default(T);
    }   
    
   
    public void ReplaceAt(int index, T newData)
    {
        DoubleNode<T> current = head;
        int count = 0;
        while (current != null)
        {
            if(count == index)
            {
                current.Data = newData;
                return;
            }
            current = current.Next;
            count++;
        }
    }
public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class Enumerator : IEnumerator<T>
    {
        private DoubleNode<T> currentNode;
        private DoubleLinkedList<T> list;

        public Enumerator(DoubleLinkedList<T> list)
        {
            this.list = list;
            currentNode = list.head;
        }

        public T Current
        {
            get
            {
                if (currentNode == null)
                    throw new InvalidOperationException();
                return currentNode.Data;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (currentNode == null) return false;
            currentNode = currentNode.Next;
            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = list.head; 
        }
        public void Dispose()
        {
        }
    }
}
    



