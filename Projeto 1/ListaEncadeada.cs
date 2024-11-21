//Projeto-1
using System.Collections;


class Node<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList<T> : IEnumerable<T>
{
    private Node<T> head;

    public LinkedList()
    {
        head = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }
    public void RemoveAt(int index)
{
    if (head == null) return;

    if (index == 0)
    {
        head = head.Next;
        return;
    }
    Node<T> current = head;
    int count = 0;

    while (current != null && count < index - 1)
    {
        current = current.Next;
        count++;
    }
    if (current == null || current.Next == null)
    {
        Console.WriteLine("Índice fora dos limites.");
        return;
    }
    current.Next = current.Next.Next;
}
   
   public bool Contains(T data)
{
    Node<T> current = head;
    while (current != null)
    {
        if (current.Data.Equals(data))
        {
            return true;
        }
        current = current.Next;
    }
    return false;
}
    public void Remove(T data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            return;
        }

        Node<T> current = head;
        while (current.Next != null && !current.Next.Data.Equals(data))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public void Display()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public int IndexOf(T data)
    {
        Node<T> current = head;
        int index = 0;
        while (current != null)
        {
            if (current.Data.Equals(data)) return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    public T GetAt(int index)
    {
        Node<T> current = head;
        int count = 0;
        while (current != null)
        {
            if (count == index) return current.Data;
            current = current.Next;
            count++;
        }
        return default(T);
    }

    public void Clear()
    {
        head = null;
    }
    
    public int Count(){
    
        Node<T> current = head;
        int count = 0;
        while (current != null){
        
            count++;
            current = current.Next;
        }
        return count;
    }
    public void ReplaceAt(int index, T newData){
        if(head == null)return;
            
        Node<T> current = head;
        int count = 0;

        while (current != null){
            if (count == index){
                current.Data = newData;
                return;
            }
            current = current.Next;
            count++;
        }
    }
public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }    



}