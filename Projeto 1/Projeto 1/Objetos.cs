public class Medico
{
public string Nome { get; set; }
public string Especialidade { get; set; }
public string Disponibilidade { get; set; }

    public Medico(string nome, string especialidade, string disponibilidade)
    {
        Nome = nome;
        Especialidade = especialidade;
        Disponibilidade = disponibilidade;
    }
    public override string ToString()
    {
        return $"Nome: {Nome} | Especialidade: {Especialidade} | Disponibilidade: {Disponibilidade}";
    }
}
public class Paciente
{
    public string Nome { get; set;}
    public int Idade { get; set; }
    public string HistoricoMedico { get; set; }
    public DateTime DataConsulta{ get; set; }

    public Paciente(string nome, int idade, string historicoMedico, DateTime dataConsulta)
    {
        Nome = nome;
        Idade = idade;
        HistoricoMedico = historicoMedico;
        DataConsulta = dataConsulta;
    }
}
public class Mesa
{
    public int NumMesa { get; set; }
    public string NomeCliente { get; set; }
    public string Status { get; set; }
    
    public Mesa(int numMesa, string nomeCliente, string status)     
    {
        NumMesa = numMesa;
        NomeCliente = nomeCliente;
        Status = status;
    }
}
public class Itens
{
    public string NomeItem { get; set; }
    public int Quantidade { get; set; }
    public float Valor{ get; set; }

    public Itens(string nomeItem, int quantidade,float valor)
    {
        NomeItem = nomeItem;
        Quantidade = quantidade;
        Valor = valor;
    }

}
public class Eventos
{
public string NomeEvento { get; set; }
public string LocalEvento { get; set; }
public DateTime DataEvento { get; set; }
public int Capacidade { get; set; }
public Eventos(string nomeEvento,string localEvento,DateTime dataEvento,int capacidade)
{
    NomeEvento = nomeEvento;
    LocalEvento = localEvento;
    DataEvento = dataEvento;
    Capacidade = capacidade;
}
}
public class Participantes
{
public string NomeParticipante { get; set; }
public int NumInscricao { get; set; }
public string EventoPartipando { get; set; }

public Participantes(string nomeParticipante,int numInscricao,string eventoPartipando)
{
    NomeParticipante = nomeParticipante;
    NumInscricao = numInscricao;
    EventoPartipando = eventoPartipando;
}
}
public class AcaoPaciente
{
    public string TipoAcao { get; set; }
    public Paciente Paciente { get; set; }
    public DateTime EstadoAnterior { get; set; }
    public AcaoPaciente(string tipoAcao, Paciente paciente, DateTime estadoAnterior)
    {
        TipoAcao = tipoAcao;
        Paciente = paciente;
        EstadoAnterior = estadoAnterior;
    }
}
public class AcaoPedido
{
    public string TipoAcao { get; set; }
    public Itens Item { get; set; }
    public int Quantidade { get; set; }
    public AcaoPedido(string tipoAcao, Itens item, int quantidade)
    {
        TipoAcao = tipoAcao;
        Item = item;
        Quantidade = quantidade;
    }
}
class AcaoParticipante
{
    public string TipoAcaoP { get; set;}
    public Participantes Participante{ get; set; }

    public AcaoParticipante(string tipoAcaoP, Participantes participante)
    {
        TipoAcaoP = tipoAcaoP;
        Participante = participante;
    }
}
class AcaoEvento
{
    public string TipoAcaoE {get; set;}
    public Eventos Evento {get; set;}
    public AcaoEvento(string tipoAcaoE, Eventos evento)
    {
        TipoAcaoE = tipoAcaoE;
        Evento = evento;
    }
}