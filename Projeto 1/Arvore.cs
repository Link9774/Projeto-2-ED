class No<T> where T : IComparable<T>
{
    public T Valor;
    public No<T> Esquerda;
    public No<T> Direita;

    public No(T valor)
    {
        Valor = valor;
        Esquerda = null;
        Direita = null;
    }
}
class Arvore<T> where T : IComparable<T>
{
    private No<T> raiz;
    public Arvore()
    {
        raiz = null;
    }
    public void Inserir(T valor)
    {
        raiz = InserirRecursivo(raiz, valor);
    }
    private No<T> InserirRecursivo(No<T> no, T valor)
    {
        if(no == null)
        {
            return new No<T>(valor);
        }         
    
        if(valor.CompareTo(no.Valor) < 0)
        {
            no.Esquerda = InserirRecursivo(no.Esquerda, valor);
        }
        else if (valor.CompareTo(no.Valor) > 0)
        {
            no.Direita = InserirRecursivo(no.Direita, valor);
        }
        return no;
    }

    public bool Buscar(T valor)
    {
        return BuscarRecursivo(raiz,valor) != null;
    }

    private No<T> BuscarRecursivo(No<T> no, T valor)
    {
        if (no == null || no.Valor.Equals(valor))
        {
            return no;
        }
        if(valor.CompareTo(no.Valor) < 0)
        {
            return BuscarRecursivo(no.Esquerda,valor);
        }
        return BuscarRecursivo(no.Esquerda, valor);
    }
    public void Remover(T valor)
    {
        raiz = RemoverRecursivo(raiz, valor);
    }

    private No<T> RemoverRecursivo(No<T> no, T valor)
    {
        if(no == null)
        {
            return null;
        }
    if (valor.CompareTo(no.Valor) < 0)
    {
        no.Esquerda = RemoverRecursivo(no.Esquerda,valor);
    }
    else if (valor.CompareTo(no.Valor) > 0)
    {
        no.Direita = RemoverRecursivo(no.Direita,valor);
    }
    else
    {
        if(no.Esquerda == null && no.Direita == null)
        {
            return null;
        }
    
        if(no.Esquerda == null)
        {
            return no.Direita;
        }
        if (no.Direita == null)
        {
            return no.Esquerda;
        }
    
    no.Valor = MinimoValor(no.Direita);
    no.Direita = RemoverRecursivo(no.Direita, no.Valor);
    }
    return no;
    }

    private T MinimoValor(No<T> no)
    {
        T minimo = no.Valor;
        while(no.Esquerda != null)
        {
            minimo = no.Esquerda.Valor;
            no = no.Esquerda;
        }
        return minimo;
    }

    public void EmOrdem()
    {
        EmOrdemRecursivo(raiz);
        Console.WriteLine();
    }

    private void EmOrdemRecursivo(No<T> no)
    {
        if(no != null)
        {
            EmOrdemRecursivo(no.Esquerda);
            Console.WriteLine(no.Valor + " ");
            EmOrdemRecursivo(no.Direita);
        }
    }
}