class CircularLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public CircularLinkedList()
    {
        head = null;
        tail = null;
    }

    
    public void RemoveAt(int index)
{
    if (head == null || index < 0) 
    {
        Console.WriteLine("Índice fora do intervalo ou lista vazia.");
        return;
    }
    if (index == 0)
    {
        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.Next;
            tail.Next = head;
        }
        return;
    }

    Node<T> current = head;
    int count = 0;

    do
    {
        if (count == index - 1)
        {
            if (current.Next == tail)
            {
                tail = current;
                tail.Next = head;
            }
            else
            {
                current.Next = current.Next.Next;
            }
            return;
        }

        current = current.Next;
        count++;
    } while (current != head);

    Console.WriteLine("Índice fora do intervalo.");
}
    
    public T GetAt(int index)
{
    if (head == null || index < 0) 
    {
        return default(T);
    }

    Node<T> current = head;
    int count = 0;
    do
    {
        if (count == index)
        {
            return current.Data;
        }
        current = current.Next;
        count++;
    } while (current != head);

    return default(T);
}
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
            tail.Next = head;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head;
        }
    }
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("A lista está vazia.");
            return;
        }

        Node<T> current = head;
        do
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        } while (current != head);
    }
    public void Remove(string data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                tail.Next = head;
            }
            return;
        }

        Node<T> current = head;
        do
        {
            if (current.Next.Data.Equals(data))
            {
                if (current.Next == tail)
                {
                    tail = current;
                    tail.Next = head;
                }
                else
                {
                    current.Next = current.Next.Next;
                }
                return;
            }
            current = current.Next;
        } while (current != head);
    }

    public int Count()
    {
        if (head == null) return 0;

        Node<T> current = head;
        int count = 0;
        do
        {
            count++;
            current = current.Next;
        } while (current != head);

        return count;
    }

    public void InsertAt(int index, T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (index == 0)
        {
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                tail.Next = head;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
                tail.Next = head;
            }
        }
        else
        {
            Node<T> current = head;
            int count = 0;

            do
            {
                if (count == index - 1)
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;

                    if (current == tail)
                    {
                        tail = newNode;
                    }
                    return;
                }
                current = current.Next;
                count++;
            } while (current != head);

            Console.WriteLine("Índice fora do intervalo.");
        }
    }
}