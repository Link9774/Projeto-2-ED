 class Program
 {  static Pilha<AcaoParticipante> historicoAcoesP = new Pilha<AcaoParticipante>();
    static Pilha<AcaoEvento> historicoAcoesE = new Pilha<AcaoEvento>();
    static Pilha<AcaoPedido> historicoCardapio = new Pilha<AcaoPedido>();
    static List<Pilha<AcaoPedido>> historicoPedidos = new List<Pilha<AcaoPedido>>();
    static Pilha<AcaoPaciente> historicoAcoes = new Pilha<AcaoPaciente>();
    static string welcome = "Bem vindo ao HealthMax, nosso aplicativo de gestão clínica";
    static LinkedList<Medico> listaMedicos = new LinkedList<Medico>();
    static LinkedList<Paciente> listaPacientes = new LinkedList<Paciente>();
    static LinkedList<Mesa> listaMesas = new LinkedList<Mesa>();
    static DoubleLinkedList<Itens> listaCardapio = new DoubleLinkedList<Itens>();
    static DoubleLinkedList<Itens> listaPedidos = new DoubleLinkedList<Itens>();
    static CircularLinkedList<Participantes> listaParticipantes = new CircularLinkedList<Participantes>(); 
    static LinkedList<Eventos> listaEventos = new LinkedList<Eventos>();
     
     static void InicializarMesas()
     {
        for (int i = 1; i <= 5; i++)
        {
            listaMesas.Add(new Mesa(i,"","Livre"));
        
            historicoPedidos.Add(new Pilha<AcaoPedido>());
        }
     }
    static void InicializarCardapio()
    {
        listaCardapio.Add(new Itens("Café da Manhã", 1 ,10.00f));
        listaCardapio.Add(new Itens("Almoço", 1 ,20.00f));
        listaCardapio.Add(new Itens("Jantar", 1 ,25.00f));
    
        listaCardapio.Add(new Itens("Suco", 1 ,5.00f));
        listaCardapio.Add(new Itens("Água", 1 ,2.00f));
        listaCardapio.Add(new Itens("Refrigerante", 1 ,8.00f));
    }

    static void ExibirLogo()
    {
        Console.WriteLine(@" ＨｅａｌｔｈＭａｘ");
        Console.WriteLine(welcome);
    }

   public static void Menu()
    {
        ExibirLogo();
        Console.Clear();
        Console.WriteLine("Digite 1 para Médicos");
        Console.WriteLine("Digite 2 para Pacientes");
        Console.WriteLine("Digite 3 para Restaurante");
        Console.WriteLine("Digite 4 para Eventos");
        Console.WriteLine("Digite 0 para Sair");

        Console.Write("\nDigite sua opção ");
        string opcaoEscolhida = Console.ReadLine();
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
        switch (opcaoEscolhidaNum)
        {
            case 1:
                RegistroMedicos();
                break;
            case 2:
                RegistroPacientes();
                break;
            case 3:
                MenuRestaurante();
                break;
            case 4:
                MenuEventos();
                break;
            case 5: Dio();
                break;
            case 0:
                Console.WriteLine("Obrigado pela preferencia, até breve");
                break;
            default:
                Console.WriteLine("Opcão invalida, escolha uma opção valida");
                break;
        }
    }
    
    static void RegistroMedicos()
    {
         Console.Clear();
        Console.WriteLine("Digite 1 para registrar um médico");
        Console.WriteLine("Digite 2 para mostrar registro médico");
        Console.WriteLine("Digite 3 para mostrar médicos especificos");
        Console.WriteLine("Digite 4 para remover um médico");
        Console.WriteLine("Digite 0 para voltar ao menu");
        Console.WriteLine("\nDigite sua opção ");
        string opcaoEscolhida = Console.ReadLine();
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNum)
        {
            case 1:
                RegistrarMedicos();
                break;
            case 2:
                MostrarListaDeMedicos();
                break;
            case 3:
                MedicoEspecificos();
                break;
            case 4:          
                RemoverMedico();
                break;
            case 0:
                Menu();
                break;
        }
    }

     static void RegistrarMedicos()
    {
        Console.Clear();
        Console.Write("Digite o nome e o sobrenome do médico: ");

        string nomeDoMedico = Console.ReadLine();
        
        Console.Write("Digite a especialidade do médico: ");
        string especialidade = Console.ReadLine();

        Console.Write("Digite a disponibilidade do médico: ");
        string disponibilidade = Console.ReadLine();

        Medico novoMedico = new Medico(nomeDoMedico, especialidade, disponibilidade);
        
        
        listaMedicos.Add(novoMedico); 
       
        Console.WriteLine($"\nO médico {nomeDoMedico} foi registrado com sucesso");
        Console.WriteLine($"Especialização {especialidade}");
        Console.WriteLine($"Disponibilidade: {disponibilidade}");
        RegistroMedicos();
    }
    static void MostrarListaDeMedicos()
    {
        Console.Clear();
        Console.WriteLine("**************************");
        Console.WriteLine("Exibindo registro médico");
        Console.WriteLine("**************************");

        for (int i = 0; i < listaMedicos.Count(); i++)
        {
            Medico medico = listaMedicos.GetAt(i);
            Console.WriteLine($"Médico: {medico.Nome} | Especialidade: {medico.Especialidade} | Disponibilidade: {medico.Disponibilidade}");
        }

        Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu de médicos");
        Console.ReadKey();
        RegistroMedicos();
    }

    static void RemoverMedico()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do médico que deseja remover");
        string nomeDoMedico = Console.ReadLine();
        
        Medico medicoEncontrado = null;

        for(int i = 0; i < listaMedicos.Count();i++)
        {
            Medico medico = listaMedicos.GetAt(i);
            if(medico.Nome.Equals(nomeDoMedico, StringComparison.OrdinalIgnoreCase))
            {
                medicoEncontrado = medico;
                break;
            }
        }
        if (medicoEncontrado != null)
        {
            listaMedicos.Remove(medicoEncontrado);
            Console.WriteLine($"\nMédico {nomeDoMedico} removido com sucesso");
        }
        else
        {
            Console.WriteLine($"\nMédico {nomeDoMedico} não encontrado");
        }
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu de médicos");
        Console.ReadKey();
        RegistroMedicos();
    }
    static void MedicoEspecificos(){
        Console.Clear();
        Console.WriteLine("Digite a especilização que você procura");
        string especialidade = Console.ReadLine();
    
        bool medicoEncontrado = false;
        for (int i = 0;i < listaMedicos.Count();i++){
            
            Medico medico = listaMedicos.GetAt(i);
            
            if (medico.Especialidade.Equals(especialidade, StringComparison.OrdinalIgnoreCase)){
                 Console.WriteLine($"Médico: {medico.Nome} | Especialidade: {medico.Especialidade} | Disponibilidade: {medico.Disponibilidade}");
                 medicoEncontrado = true;        
            }

        }
        if(!medicoEncontrado){
            Console.WriteLine("Nenhum médico encontrado com essa especialidade.");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu de médicos");
            Console.ReadKey();
            RegistroMedicos();
    }

    static void RegistroPacientes()
    {
        Console.Clear();
        Console.WriteLine("Digite 1 para registrar um paciente");
        Console.WriteLine("Digite 2 para mostrar registro de pacientes");
        Console.WriteLine("Digite 3 para agendar uma consulta");
        Console.WriteLine("Digite 4 para remover um paciente");
        Console.WriteLine("Digite 5 para ver o histórico de ações");
        Console.WriteLine("Digite 6 para desfazer ultima ação");
        Console.WriteLine("Digite 0 para voltar ao menu");
        Console.WriteLine("\nDigite sua opção ");
        string opcaoEscolhida = Console.ReadLine();
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNum){
            case 1: RegistrarPaciente();
                break;
            case 2: RegistroPaciente();
                break;
            case 3: AgendarConsulta();    
                break;
            case 4: RemoverPaciente();
                break;
            case 5: MostrarHistoricoDeAcoes();
                break;
            case 6:DesfazerUltimaAcao();
                break;
            case 0:
                Menu();
                break; 
        }
   static void RegistrarPaciente(){
        Console.Clear();
        Console.WriteLine("Digite o nome e sobrenome do paciente");

        string nomePaciente = Console.ReadLine();
        

        int idadePaciente = 0; 
        bool idadeValida = false;
       
        while(!idadeValida)
        {
        Console.WriteLine("Digite a idade do paciente");    
        string idadePacienteS = Console.ReadLine();
        
            if(int.TryParse(idadePacienteS, out idadePaciente)){
                idadeValida = true;
            }else{
                Console.WriteLine("Digite uma idade valida");
            }
        }
        Console.WriteLine("Digite o historico medico do paciente");        
        string historicoMedico = Console.ReadLine();
        
        bool dataValida = false;
        DateTime dataConsulta = DateTime.MinValue ;

        while (!dataValida)
        {
    
        Console.WriteLine("Digite a data da consulta (dd/MM/yyyy)");        
        string dataConsultaS = Console.ReadLine();

        if (DateTime.TryParseExact(dataConsultaS, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataConsulta)){
        
            dataValida = true;
        }
        else{
            Console.WriteLine("Digite uma data válida no formato dd/MM/yyyy");
        }        
    }
    Paciente novoPaciente = new Paciente(nomePaciente,idadePaciente,historicoMedico,dataConsulta);
    listaPacientes.Add(novoPaciente);
    
    Console.WriteLine($"\nPaciente {nomePaciente} registrado com sucesso");

    RegistroPaciente();

    }
    static void RegistroPaciente(){
        Console.Clear();
        Console.WriteLine("*******************************");
        Console.WriteLine("Exibindo registro de pacientes");
        Console.WriteLine("*******************************");

        for(int i = 0; i < listaPacientes.Count();i++)
        {
            Paciente paciente = listaPacientes.GetAt(i);
            Console.WriteLine($"Paciente: {paciente.Nome} | Idade: {paciente.Idade} | Histórico: {paciente.HistoricoMedico} | Data da última consulta: {paciente.DataConsulta:dd/MM/yyyy}");
        }
        Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu de pacientes");
        Console.ReadKey();
        RegistroPacientes();
    }
    static void AgendarConsulta(){
        Console.Clear();
        Console.WriteLine("Digite o nome do paciente para agendar uma nova consulta:");
        string nomePaciente = Console.ReadLine();
        
        for(int i = 0; i < listaPacientes.Count(); i++)
        {
            Paciente paciente = listaPacientes.GetAt(i);
        
            if(paciente.Nome.Equals(nomePaciente, StringComparison.OrdinalIgnoreCase))
            {
                bool dataValida = false;
                DateTime novaDataConsulta;

                while(!dataValida)
                {
                    Console.WriteLine("Digite a nova data da consulta (dd/MM/yyyy)");
                    string novaDataConsultaS = Console.ReadLine();

                    if(DateTime.TryParseExact(novaDataConsultaS,"dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out novaDataConsulta))
                    {
                        AcaoPaciente acao = new AcaoPaciente("Agendamento", paciente, paciente.DataConsulta);
                        historicoAcoes.Empilhar(acao);
                        
                        paciente.DataConsulta = novaDataConsulta;
                        Console.WriteLine($"A nova data da consulta para {paciente.Nome} foi registrada com sucesso: {paciente.DataConsulta:dd/MM/yyyy}");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu de pacientes");
                        Console.ReadKey();
                        RegistroPacientes();
                        return;
                    }
                    else 
                    {
                        Console.WriteLine("Digite uma data válida no formato dd/MM/yyyy.");
                    }
                }
            }
        }
        Console.WriteLine($"Paciente {nomePaciente} não encontrado.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu de pacientes");
        Console.ReadKey();
        RegistroPacientes();
    }
    static void RemoverPaciente(){
        Console.Clear();
        Console.WriteLine("Digite o nome do paciente que deseja remover");
        string nomePaciente = Console.ReadLine();

        Paciente pacienteARemover = null;
        for (int i = 0; i< listaPacientes.Count(); i++)
        {
            if(listaPacientes.GetAt(i).Nome.Equals(nomePaciente, StringComparison.OrdinalIgnoreCase))
            {
                pacienteARemover = listaPacientes.GetAt(i);
                break;
            }
    }
        if (pacienteARemover != null)
    {
       AcaoPaciente acao = new AcaoPaciente("Remoção", pacienteARemover,pacienteARemover.DataConsulta);
       historicoAcoes.Empilhar(acao);
       
       listaPacientes.Remove(pacienteARemover); 
       Console.WriteLine($"\nPaciente {nomePaciente} removido com sucesso"); 
        }
     else 
        {
        Console.WriteLine($"\nPaciente {nomePaciente} não encontrado");
        }
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu de pacientes");
        Console.ReadKey();
        RegistroPacientes();
    }
    static void DesfazerUltimaAcao()
    {
        if (!historicoAcoes.IsEmpty())
        {
            AcaoPaciente ultimaAcao = historicoAcoes.Desempilhar();
        
            if(ultimaAcao.TipoAcao == "Agendamento")
            {
                Paciente paciente = ultimaAcao.Paciente;
                paciente.DataConsulta = ultimaAcao.EstadoAnterior;
                Console.WriteLine($"Consulta para {paciente.Nome} desfeita. Data anterior: {paciente.DataConsulta:dd/MM/yyyy}");
            }
            else if (ultimaAcao.TipoAcao == "Remoção")
            {
                listaPacientes.Add(ultimaAcao.Paciente);
                Console.WriteLine($"Paciente {ultimaAcao.Paciente.Nome} removido desfeito e restaurado");
            }
        
        }
        else
        {
            Console.WriteLine("Não há ações para desfazer");
        }
     Console.WriteLine("Pressione qualquer tecla para voltar ao menu de pacientes");
    Console.ReadKey();
    RegistroPacientes();
    }

   static void MostrarHistoricoDeAcoes()
{
    Console.Clear();
    Console.WriteLine("*******************************");
    Console.WriteLine("Histórico de Ações Realizadas:");
    Console.WriteLine("*******************************");

    if (historicoAcoes.IsEmpty())
    {
        Console.WriteLine("Nenhuma ação registrada no histórico.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu de pacientes.");
        Console.ReadKey();
        RegistroPacientes(); 
    }
    else
    {
        Pilha<AcaoPaciente> copiaHistorico = new Pilha<AcaoPaciente>();

        while (!historicoAcoes.IsEmpty())
        {
            AcaoPaciente acao = historicoAcoes.Desempilhar();
            copiaHistorico.Empilhar(acao);

            Console.WriteLine($"Ação: {acao.TipoAcao}");
            Console.WriteLine($"Paciente: {acao.Paciente.Nome}");
            if (acao.TipoAcao == "Agendamento" || acao.TipoAcao == "Atualização")
            {
                Console.WriteLine($"Estado Anterior: {acao.EstadoAnterior:dd/MM/yyyy}");
            }
            Console.WriteLine("---------------------------");
        }
        while (!copiaHistorico.IsEmpty())
        {
            historicoAcoes.Empilhar(copiaHistorico.Desempilhar());
        }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu de pacientes.");
    Console.ReadKey();
    RegistroPacientes();
    }
    
}



}
    static void MenuRestaurante()
    {
        Console.Clear();
        Console.WriteLine("Digite 1 para gerenciar mesas");
        Console.WriteLine("Digite 2 para mostrar mesas");
        Console.WriteLine("Digite 3 para mostrar o Cardapio");
        Console.WriteLine("Digite 4 para adicionar item ao cardápio");
        Console.WriteLine("Digite 5 para remover um item");
        Console.WriteLine("Digite 6 para registrar conta");
        Console.WriteLine("Digite 7 para fechar conta");
        Console.WriteLine("Digite 8 para desfazer a última alteração no cardápio");
        Console.WriteLine("Digite 0 para voltar ao menu");
        Console.WriteLine("\nDigite sua opção ");
        string opcaoEscolhida = Console.ReadLine();
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNum){
           case 1: GerenciarMesa();
                break;
            case 2: MostrarMesas();
                break;    
            case 3: MostrarCardapio();
                break;
            case 4: AdicionarItem();
                break;
            case 5: RemoverItem();
                break;
            case 6: RegistrarConta();
                break;
            case 7: FecharConta();
                break;
            case 8: DesfazerAlteracaoCardapio();
                break;
            case 9: DesfazerAlteracaoMesa();
                break;
            case 0: Menu();
                break;
        }
        
  static void GerenciarMesa()
  {
        Console.Clear();
        int numMesa = 0; 
        bool numValido = false;
       
        while(!numValido)
        {
        Console.WriteLine("Digite o número da mesa");    
        string numMesaS = Console.ReadLine();
        
            if(int.TryParse(numMesaS, out numMesa) && numMesa>= 1 && numMesa<=5){
                numValido = true;
            }else{
                Console.WriteLine("Digite um número válido");
            }
        }
    Mesa mesa = listaMesas.GetAt(numMesa - 1);
    
    Console.WriteLine("Digite o nome e sobrenome do cliente");    
         string nomeCliente = Console.ReadLine();
    Console.WriteLine("Digite o status da mesa");   
         string status = Console.ReadLine();
    
    listaMesas.ReplaceAt(numMesa - 1, new Mesa(numMesa,nomeCliente, status));
    
    Console.WriteLine($"\nA mesa {numMesa} foi atualizada com sucesso.");
     Console.WriteLine("Pressione qualquer tecla para voltar ao menu do restaurante");
        Console.ReadKey();
        MenuRestaurante(); 
  
  }
    static void MostrarMesas()
    {
        Console.Clear();
        Console.WriteLine("**************");
        Console.WriteLine("Exibindo Mesas");
        Console.WriteLine("**************");
    
        for(int i = 0; i < listaMesas.Count();i++){
             Mesa mesa = listaMesas.GetAt(i);
            Console.WriteLine($"Mesa: {mesa.NumMesa} | Cliente: {mesa.NomeCliente} | Status: {mesa.Status}");
        }
        Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu do restaurante");
        Console.ReadKey();
        MenuRestaurante();    
    }
    static void AdicionarItem()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do item");
        string nomeItem = Console.ReadLine();
    
        float valor = 0;
        while(true)
        {
            Console.WriteLine("Digite o valor do item");
            if(float.TryParse(Console.ReadLine(), out valor) && valor > 0) break;
            else Console.WriteLine("Valor inválido, digite um número válido");
        }
        
        int quantidade;
        while(true)
        {
        Console.WriteLine("Digite a quantidade do item");
        if(int.TryParse(Console.ReadLine(), out quantidade) && quantidade > 0)break;
        Console.WriteLine("Quantidade inválida, digite um número válido");
        }
        
        Itens novoItem = new Itens(nomeItem, quantidade,valor);
        
        listaCardapio.Add(novoItem);
        
        historicoCardapio.Empilhar(new AcaoPedido("adição",novoItem,1));

        Console.WriteLine($"\nO item {nomeItem} adicionado ao cardápio com sucesso");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        MenuRestaurante();
    }
    static void MostrarCardapio()
    {
       Console.Clear();
       Console.WriteLine("Digite 1 para ver o cardápio do menor para o maior valor");
       Console.WriteLine("Digite 2 para ver o cardápio do maior para o menor valor");
       Console.WriteLine("Digite 0 para voltar ao menu do restaurante");
    
       string opcaoEscolhida = Console.ReadLine();
       int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
       if(opcaoEscolhidaNum == 1 || opcaoEscolhidaNum == 2)
       {
        OrdenarCardapio(opcaoEscolhidaNum == 1);
        
        Console.Clear();
        Console.WriteLine("*************** Cardápio ***************");
        
        for(int i = 0; i < listaCardapio.Count(); i++)
        {
            Itens item = listaCardapio.GetAt(i);
            Console.WriteLine($"Item: {item.NomeItem} | Valor: R$ {item.Valor:F2}");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu do restaurante");
        Console.ReadKey();
        MenuRestaurante();
       } 
       else if (opcaoEscolhidaNum == 0)
       {
        MenuRestaurante();
       }
       else
       {
        Console.WriteLine("Opção inválida");
        MostrarCardapio();
       }

    }
    
    static void RemoverItem()
    {
    Console.Clear();
    Console.WriteLine("Digite o nome do item que deseja remover:");
    string nomeItem = Console.ReadLine();

    Itens itemARemover = null;
    for (int i = 0; i < listaCardapio.Count(); i++)
    {
        Itens item = listaCardapio.GetAt(i);
        if (item.NomeItem.Equals(nomeItem, StringComparison.OrdinalIgnoreCase))
        {
            itemARemover = item;
            break;
        }
    }

    if (itemARemover != null)
    {
        listaCardapio.Remove(itemARemover);
        historicoCardapio.Empilhar(new AcaoPedido("remover", itemARemover,1));
        Console.WriteLine($"Item '{nomeItem}' removido com sucesso!");
    }
    else
    {
        Console.WriteLine($"Item '{nomeItem}' não encontrado.");
    }

    Console.WriteLine("Pressione qualquer tecla para volta ao menu");
    Console.ReadKey();
    MenuRestaurante();
    }
    static void RegistrarConta()
    {
    Console.Clear();
    Console.Write("Digite o número da mesa: ");
    int numMesa;
    while (!int.TryParse(Console.ReadLine(), out numMesa) || numMesa <= 0 || numMesa > listaMesas.Count())
    {
        Console.WriteLine("Número inválido. Tente novamente.");
    }

    Mesa mesa = listaMesas.GetAt(numMesa - 1);
    if (mesa.Status.ToLower() == "livre")
    {
        Console.WriteLine("Esta mesa está livre. Não é possível registrar pedidos.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        MenuRestaurante();
        return;
    }
    Console.Write("Digite o nome do item: ");
    string nomeItem = Console.ReadLine();

    Console.Write("Digite a quantidade: ");
    int quantidade;
    while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
    {
        Console.WriteLine("Quantidade inválida. Tente novamente.");
    }

    float valor = 0;
    bool itemEncontrado = false;
    for (int i = 0; i < listaCardapio.Count(); i++)
    {
        Itens itemCardapio = listaCardapio.GetAt(i);
        if (itemCardapio.NomeItem.Equals(nomeItem, StringComparison.OrdinalIgnoreCase))
        {
            valor = itemCardapio.Valor;
            itemEncontrado = true;
            break;
        }
    }

    if (!itemEncontrado)
    {
        Console.WriteLine("Item não encontrado no cardápio.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        MenuRestaurante();
        return;
    }

    Itens novoPedido = new Itens(nomeItem, quantidade,valor);
    listaPedidos.Add(novoPedido);
    historicoPedidos[numMesa - 1].Empilhar(new AcaoPedido("adicionar", novoPedido, quantidade));

    Console.WriteLine($"\nO pedido do item '{nomeItem}' foi registrado com sucesso.");
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu do restaurante.");
    Console.ReadKey();
    MenuRestaurante();
    }
    
    static void FecharConta()
    {
    Console.Clear();
    Console.Write("Digite o número da mesa que deseja fechar a conta: ");
    int numMesa;
    while (!int.TryParse(Console.ReadLine(), out numMesa) || numMesa <= 0 || numMesa > listaMesas.Count())
    {
        Console.WriteLine("Número inválido.");
    }

    Mesa mesa = listaMesas.GetAt(numMesa - 1);
    if (mesa.Status.ToLower() == "livre")
    {
        Console.WriteLine("Esta mesa está livre.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        MenuRestaurante();
        return;
    }

    double valorTotal = 0;
    bool encontrouItens = false;

    for (int i = 0; i < listaPedidos.Count(); i++)
    {
        Itens item = listaPedidos.GetAt(i);
        if (item != null && item.Quantidade > 0)
        {
            valorTotal += item.Quantidade * item.Valor;
            encontrouItens = true;
            Console.WriteLine($"Item: {item.NomeItem} | Quantidade: {item.Quantidade} | Valor Unitário: R$ {item.Valor}");
        }
    }

    Console.WriteLine($"Valor total da conta para a mesa {numMesa}: R$ {valorTotal:F2}");

    if (!encontrouItens)
    {
        Console.WriteLine($"Nenhum item encontrado para a mesa {numMesa}.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        MenuRestaurante();
        return;
    }

    Console.WriteLine("\nPressione qualquer tecla para fechar a conta e liberar a mesa");
    Console.ReadKey();

      bool descontoAplicado = false;
    foreach (var medico in listaMedicos)
    {
        if (medico.Nome.Equals(mesa.NomeCliente, StringComparison.OrdinalIgnoreCase))
        {
            double desconto = valorTotal * 0.1;
            valorTotal -= desconto;
            Console.WriteLine($"Desconto aplicado: R$ {desconto:F2}");
            descontoAplicado = true;
            break; 
        }
    }



    mesa.Status = "livre";
    mesa.NomeCliente = "";

    for (int i = listaPedidos.Count() - 1; i >= 0; i--)
    {
        listaPedidos.RemoveAt(i);
    }

    Console.WriteLine($"Conta da mesa {numMesa} fechada e mesa liberada com sucesso.");
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();

    MenuRestaurante();
    }  
    static void DesfazerAlteracaoCardapio()
    {
        Console.Clear();
        if (historicoCardapio.IsEmpty())
        {
        Console.WriteLine("Não há alterações no cardápio para desfazer");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        MenuRestaurante();
        return;
        }
        AcaoPedido ultimaAcao = historicoCardapio.Desempilhar();
        
        if(ultimaAcao.TipoAcao == "adição")
        {
            listaCardapio.Remove(ultimaAcao.Item);
            Console.WriteLine($"Ação desfeita '{ultimaAcao.Item.NomeItem}' removido do cardápio");
        }
        
        else if(ultimaAcao.TipoAcao == "remover")
        {
            listaCardapio.Add(ultimaAcao.Item);
            Console.WriteLine($"Ação desfeita: Item '{ultimaAcao.Item.NomeItem}' adicionado novamente ao cardápio");
        }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu de restaurente");
    Console.ReadKey();
    MenuRestaurante();
    }
static void DesfazerAlteracaoMesa()
{
    Console.Clear();
    Console.Write("Digite o número da mesa para desfazer a última alteração: ");
    int numMesa;

    while (!int.TryParse(Console.ReadLine(), out numMesa) || numMesa <= 0 || numMesa > listaMesas.Count())
    {
        Console.WriteLine("Número inválido, tente um número válido");
    }

    if (historicoPedidos[numMesa - 1].IsEmpty())
    {
        Console.WriteLine("Não há alterações para desfazer nesta mesa");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        MenuRestaurante();
        return;
    }
    AcaoPedido ultimaAcao = historicoPedidos[numMesa - 1].Desempilhar();

    if (ultimaAcao.TipoAcao == "adicionar")
    {
        listaPedidos.Remove(ultimaAcao.Item);
        Console.WriteLine($"Ação desfeita: Item '{ultimaAcao.Item.NomeItem}' removido");
    }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu do restaurente");
    Console.ReadKey();
    MenuRestaurante();
}



}
   static void MenuEventos()
   {
        Console.Clear();
        Console.WriteLine("Digite 1 para registrar um evento");
        Console.WriteLine("Digite 2 para inscrever participante");
        Console.WriteLine("Digite 3 para mostrar eventos");
        Console.WriteLine("Digite 4 para mostrar participantes");
        Console.WriteLine("Digite 5 para cancelar inscrição");
        Console.WriteLine("Digite 6 para desfazer ações em eventos");
        Console.WriteLine("Digite 7 para cancelar evento");
        Console.WriteLine("Digite 0 para voltar ao menu");
        Console.WriteLine("\nDigite sua opção ");
        string opcaoEscolhida = Console.ReadLine();
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
   
    switch (opcaoEscolhidaNum){
            case 1: RegistrarEvento();
                break;
            case 2: RegistrarParticipante();
                break;
            case 3: MonstrarEventos();    
                break;
            case 4: MostrarParticipantes();
                break;
            case 5: RemoverParticipante();
               break;
            case 6: DesfazerAlteracaoE();
                break;
            case 7: CancelarEvento();    
                break;
            case 0:
                Menu();
                break; 
        }
    
   
    static void RegistrarEvento()
    {
     Console.Clear();
     Console.WriteLine("Digite o nome do evento");
     string nomeEvento = Console.ReadLine();
     Console.WriteLine("Digite o local do evento");
     string localEvento = Console.ReadLine();
     Console.WriteLine("Digite a data do evento (formato dd/MM/yyyy):");
    DateTime dataEvento;
    while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEvento))
    {
        Console.WriteLine("Data inválida. Digite no formato dd/MM/yyyy:");
    }

     Console.Write("Digite a capacidade do evento");
     int capacidade;
     while (!int.TryParse(Console.ReadLine(), out capacidade) || capacidade <= 0)
     {
        Console.WriteLine("Capacidade inválida");
     }
    
     Eventos eventos = new Eventos(nomeEvento,localEvento,dataEvento, capacidade);
     listaEventos.Add(eventos);
     historicoAcoesE.Empilhar(new AcaoEvento("registrarEvento", eventos));
     
     Console.WriteLine("Evento registrado com sucesso");
     Console.WriteLine("Pressione qualquer tecla para voltar.");
     Console.ReadKey();
     MenuEventos();
    }
   static void RegistrarParticipante()
    {
    Console.Clear();
    Console.Write("Digite o nome do participante: ");
    string nomeParticipante = Console.ReadLine();
    Console.Write("Digite o número de inscrição: ");
    int numInscricao;
    while (!int.TryParse(Console.ReadLine(), out numInscricao) || numInscricao <= 0)
    {
        Console.WriteLine("Número de inscrição inválido. Digite um número maior que zero.");
    }
    Console.Write("Digite o nome do evento para inscrição: ");
    string eventoParticipando = Console.ReadLine();

    Eventos eventoEncontrado = null;
    for (int i = 0; i < listaEventos.Count(); i++)
    {
        Eventos evento = listaEventos.GetAt(i);
        if (evento.NomeEvento.Equals(eventoParticipando, StringComparison.OrdinalIgnoreCase))
        {
            eventoEncontrado = evento;
            break;
        }
    }

    if (eventoEncontrado == null)
    {
        Console.WriteLine("Evento não encontrado, pressione qualquer tecla para voltar");
        Console.ReadKey();
        MenuEventos();
        return;
    }

    Participantes participante = new Participantes(nomeParticipante, numInscricao, eventoParticipando);
    listaParticipantes.Add(participante);
    historicoAcoesP.Empilhar(new AcaoParticipante("adicionarParticipante", participante));

    Console.WriteLine("Participante registrado com sucesso");
    Console.WriteLine("Pressione qualquer tecla para voltar");
    Console.ReadKey();
    MenuEventos();
    }    
   static void MonstrarEventos()
   {
    Console.Clear();
    Console.WriteLine("****************");
    Console.WriteLine("Lista de Eventos");
    Console.WriteLine("****************");   
    for (int i = 0;i < listaEventos.Count();i++)
    {
        Eventos eventos = listaEventos.GetAt(i);
        Console.WriteLine($"Evento: {eventos.NomeEvento} | Local: {eventos.LocalEvento} | Data: {eventos.DataEvento} | Capacidade: {eventos.Capacidade}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    MenuEventos();
   }
   static void MostrarParticipantes()
{
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("Lista de Participantes");
    Console.WriteLine("**********************");    
    for(int i = 0; i < listaParticipantes.Count(); i++)
    {
        Participantes participante = listaParticipantes.GetAt(i);
        Console.WriteLine($"Nome: {participante.NomeParticipante} | Nº Inscrição: {participante.NumInscricao} | Evento: {participante.EventoPartipando}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar");
    Console.ReadKey();
    MenuEventos();

}
   
   static void RemoverParticipante()
{
    Console.Clear();
    Console.WriteLine("Digite o número de inscrição do participante para remover");
    int numInscricao;
    while(!int.TryParse(Console.ReadLine(), out numInscricao) || numInscricao <= 0)
    {
        Console.WriteLine("Número de inscrição inválido");
    }
    bool participanteRemovido = false;
    for (int i = 0; i < listaParticipantes.Count(); i++)
    {
        Participantes participante = listaParticipantes.GetAt(i);
        if (participante.NumInscricao == numInscricao)
        {
            historicoAcoesP.Empilhar(new AcaoParticipante("removerParticipante",participante));
            listaParticipantes.RemoveAt(i);
            participanteRemovido = true;
            break;
        }
    }
    if(participanteRemovido)
    {
        Console.WriteLine("Participante removido com sucesso");
    }
    else
    {
        Console.WriteLine("Participante não encontrado");
    }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    MenuEventos();
}
   static void CancelarEvento()
{
   Console.Clear();
    Console.Write("Digite o nome do evento a ser cancelado");
    string nomeEvento = Console.ReadLine();

    bool eventoCancelado = false;

    for (int i = 0; i < listaEventos.Count(); i++)
    {
        Eventos evento = listaEventos.GetAt(i);
        if (evento.NomeEvento.Equals(nomeEvento, StringComparison.OrdinalIgnoreCase))
        {
            listaEventos.RemoveAt(i); 
            eventoCancelado = true;

            for (int j = listaParticipantes.Count() - 1; j >= 0; j--)
            {
                Participantes participantes = listaParticipantes.GetAt(j);
                if (participantes.EventoPartipando.Equals(nomeEvento, StringComparison.OrdinalIgnoreCase))
                {
                    listaParticipantes.RemoveAt(j); 
                }
            }
            historicoAcoesE.Empilhar(new AcaoEvento("cancelarEvento",evento ));
            break;
        }
    }
    if (eventoCancelado)
    {   
        Console.WriteLine("Evento cancelado com sucesso");
    }
    else
    {
        Console.WriteLine("Evento não encontrado");
    }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    MenuEventos();
 }
    static void DesfazerAlteracaoE()
    {
        Console.Clear();
        if (historicoAcoesE.IsEmpty())
        {
        Console.WriteLine("Não há alterações no cardápio para desfazer");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        MenuRestaurante();
        return;
        }
        AcaoEvento ultimaAcao = historicoAcoesE.Desempilhar();
        
        if(ultimaAcao.TipoAcaoE == "registrarEvento")
        {
            listaEventos.Remove(ultimaAcao.Evento);
            Console.WriteLine($"Ação desfeita '{ultimaAcao.Evento.NomeEvento}' removido");
        }
        
        else if(ultimaAcao.TipoAcaoE == "cancelarEvento")
        {
            listaEventos.Add(ultimaAcao.Evento);
            Console.WriteLine($"Ação desfeita: Item '{ultimaAcao.Evento.NomeEvento}' adicionado novamente");
        }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu eventos");
    Console.ReadKey();
    MenuEventos();
    }

   
}
   static void Dio(){
    Console.WriteLine(@"
██╗░░██╗░█████╗░███╗░░██╗░█████╗░  ██████╗░██╗░█████╗░  ██████╗░░█████╗░██╗██╗██╗
██║░██╔╝██╔══██╗████╗░██║██╔══██╗  ██╔══██╗██║██╔══██╗  ██╔══██╗██╔══██╗██║██║██║
█████═╝░██║░░██║██╔██╗██║██║░░██║  ██║░░██║██║██║░░██║  ██║░░██║███████║██║██║██║
██╔═██╗░██║░░██║██║╚████║██║░░██║  ██║░░██║██║██║░░██║  ██║░░██║██╔══██║╚═╝╚═╝╚═╝
██║░╚██╗╚█████╔╝██║░╚███║╚█████╔╝  ██████╔╝██║╚█████╔╝  ██████╔╝██║░░██║██╗██╗██╗
╚═╝░░╚═╝░╚════╝░╚═╝░░╚══╝░╚════╝░  ╚═════╝░╚═╝░╚════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝╚═╝╚═╝");    
   }
    
    static void OrdenarCardapio(bool crescente)
    {
        for(int i = 0; i < listaCardapio.Count()- 1;i++)
        {
            for(int j = 0; j < listaCardapio.Count()- i - 1;j++)
            {
                Itens itemAtual = listaCardapio.GetAt(j);
                Itens proximoItem = listaCardapio.GetAt(j + 1);
            
                bool precisaTrocar = crescente ? itemAtual.Valor > proximoItem.Valor : itemAtual.Valor < proximoItem.Valor;

                if(precisaTrocar)
                {
                    listaCardapio.ReplaceAt(j, proximoItem);
                    listaCardapio.ReplaceAt(j + 1, itemAtual);
                }
            }
        }
    }
    
    static void Main(string[] args)
    {
        ExibirLogo();
        InicializarCardapio();
        InicializarMesas();
        Menu();
    }
 
 }