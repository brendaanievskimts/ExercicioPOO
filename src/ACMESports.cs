
using System.Collections;

class ACMESports
{
    private Plantel plantel;
    private Medalheiro medalheiro;
    private bool voltarMenu = true;

    public ACMESports()
    {
        plantel = new Plantel();
        medalheiro = new Medalheiro();
        executar();

    }

    public void executar()
    {   
        while(voltarMenu == true){
        menu();
        int opcao = int.Parse(Console.ReadLine());
        
        switch(opcao)
        {
            case 1:
                cadastrarAtletas();
                break;
            case 2:
                cadastrarMedalha();
                break;
            case 3:
                cadastrarMedalhaEAtletaCorrespondente();
                break;
            case 4:
                dadosAtletaNum();
                break;
            case 5:
                dadosAtletaNome();
                break;
            case 6:
                dadosMedalha();
                break;
            case 7:
                dadosAtletaPais();
                break;
            case 8:
                dadosAtletaTipoMedalha();
                break;
            case 9:
                dadosAtletaModalidade();
                break;
            case 10:
                dadosAtletaMaisMedalhas();
                break;
            case 0:
                System.Console.WriteLine($"Finalizando programa...");
                voltarMenu = false;
                break;
            }
        }
    }

    private void menu()
    {
        System.Console.WriteLine("==== OPCOES ====");
        System.Console.WriteLine("1 - Cadastrar um Atleta");
        System.Console.WriteLine("2 - Cadastrar uma Medalha");
        System.Console.WriteLine("3 - Cadastrar Atleta e Medalha Correspondentes");
        System.Console.WriteLine("4 - Buscar Dados de um Atleta por Numero");
        System.Console.WriteLine("5 - Buscar Dados de um Atleta por Nome");
        System.Console.WriteLine("6 - Buscar Dados de uma Medalha por codigo");
        System.Console.WriteLine("7 - Buscar Atletas por Pais");
        System.Console.WriteLine("8 - Buscar Atletas por Tipo de Medalha");
        System.Console.WriteLine("9 - Buscar Atletas por Modalidade");
        System.Console.WriteLine("10 - Mostrar Atlta com mais Medalhas");
        System.Console.WriteLine("0 - Sair");
    }
    
    private void cadastrarAtletas(){
        int numero;
        string nome;
        string pais;

        System.Console.WriteLine("Informe o numero do atleta: ");
        numero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Informe o nome do atleta: ");
        nome = Console.ReadLine();

        System.Console.WriteLine("Informe o pais do atleta: ");
        pais = Console.ReadLine();

        Atleta atleta = new Atleta(numero, nome, pais);

        if(plantel.consultaAtleta(numero) != null){
            System.Console.WriteLine($"1: Número de atleta já cadastrado. Use outro número para cadastro.");
        }
        else{
            plantel.cadastraAtleta(atleta);
            System.Console.WriteLine($"1: Atleta cadastrado! Dados: {nome}, {numero}, {pais}.");
        }
    }

    private void cadastrarMedalha(){
        int codigo;
        int tipo;
        bool individual;
        string modalidade;

        System.Console.WriteLine("Informe o código da medalha: ");
        codigo = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Informe o tipo da medalha: (TIPO 1 - Bronze; TIPO 2 - Prata; TIPO 3 - Ouro)");
        tipo = int.Parse(Console.ReadLine());

        System.Console.WriteLine("A medalha é individual? True/False");
        individual = bool.Parse(Console.ReadLine());

        System.Console.WriteLine("Informa a modalidade da medalha: ");
        modalidade = Console.ReadLine();

        Medalha medalha = new Medalha(codigo, tipo, individual, modalidade);
        
        if(medalheiro.consultaMedalha(codigo) != null){
            System.Console.WriteLine("2: Codigo já cadastrado em outra medalha.");
        }
        else{
            medalheiro.cadastraMedalha(medalha);
            System.Console.WriteLine($"2: Medalha cadastrada. Dados: {codigo}, {tipo}, é individual? {individual}, {modalidade}.");
        }
    }

    private void cadastrarMedalhaEAtletaCorrespondente()
    {
        int numero;
        int codigo;

        System.Console.WriteLine("Informe o numero do atleta: ");
        numero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Informe o codigo da medalha: ");
        codigo = int.Parse(Console.ReadLine());

        Atleta a = plantel.consultaAtleta(numero);
        Medalha m = medalheiro.consultaMedalha(codigo);

        if(!a.Equals(null))
        {
            a.adicionaMedalha(m);

            if(!m.Equals(null)){
                m.adicionaAtleta(a);
                System.Console.WriteLine($"3: Medalha e atletas correspondentes cadastrados!");
            }
        }
    }

    private void dadosAtletaNum() //4
    {   
        System.Console.WriteLine("Informe o numero do atleta: ");
        int numero = int.Parse(Console.ReadLine());

        Atleta a = plantel.consultaAtleta(numero);
        if(a == null)
        {
            System.Console.WriteLine($"4: Nenhum atleta encontrado.");
        } else 
        {
            System.Console.WriteLine($"4: Atleta encontrado! Dados: \nNumero: {a.Numero}, Nome: {a.Nome}, Pais: {a.Pais}, Medalhas: {a.Medalhas}");
        }
    }

    private void dadosAtletaNome() //5
    {
        System.Console.WriteLine("Informe o nome do atleta: ");
        string nome = Console.ReadLine();

        Atleta a = plantel.consultaAtleta(nome);
        if(a == null)
        {
            System.Console.WriteLine($"5: Nenhum atleta encontrado.");
        } else{
             System.Console.WriteLine($"5: Atleta encontrado! Dados: \nNumero: {a.Numero}, Nome: {a.Nome}, Pais: {a.Pais}, Medalhas: {a.Medalhas}");
        }
    }

    private void dadosMedalha() //6
    {   
        System.Console.WriteLine("Informe o codigo da medalha: ");
        int codigo = int.Parse(Console.ReadLine());

        Medalha m = medalheiro.consultaMedalha(codigo);

        if(m == null){
            System.Console.WriteLine($"6: Nenhuma medalha encontrada.");
        } else{
            System.Console.WriteLine($"6: Medalha encontrada. Dados: \nCodigo: {m.Codigo}, Tipo: {m.Tipo}, Individual? {m.Individual}, Modalidade: {m.Modalidade}.");
        }

    }

    private void dadosAtletaPais() //7
    {
        System.Console.WriteLine("Informe o pais do atleta: ");
        string pais = Console.ReadLine();

        ArrayList resultado = new ArrayList();
        Atleta a = plantel.consultaAtleta(pais);

        if(plantel != null){
            if(a.Pais != pais)
            {
                System.Console.WriteLine($"7: Pais nao encontrado.");
            }
            else{
                foreach(Atleta atleta in resultado){
                    System.Console.WriteLine($"7: Resultado: {a.Numero}, {a.Nome}, {a.Pais}.");
                }
            }
        }
    }

    private void dadosAtletaTipoMedalha() //8
    {
        System.Console.WriteLine("Informe o tipo da medalha: ");
        int tipo = int.Parse(Console.ReadLine());
        ArrayList atletas = medalheiro.atletaPorTipoMedalha(tipo);

        if (atletas == null) {
            System.Console.WriteLine($"8: Nenhum atleta encontrado.");
        } else {
            foreach(Atleta atleta in atletas) {
                System.Console.WriteLine($"8: {atleta.Numero}, {atleta.Nome}, {atleta.Pais}");
            }
        }

        

    }

    private void dadosAtletaModalidade() //9
    {
        System.Console.WriteLine("Informe a modalidade do atleta: ");
        string modalidade = Console.ReadLine();

        ArrayList resultado = medalheiro.consultaMedalhas(modalidade);
        if(resultado == null)
        {
            System.Console.WriteLine("Modalidade não encontrada");
        }
        else
        {
            foreach(Medalha m in resultado)
            {
                if(m.Atletas == null)
                {
                    System.Console.WriteLine($"9: {modalidade}, tipo: {m.Tipo}, sem atletas.");
                } else
                {
                    foreach(Atleta a in m.Atletas)
                    {
                        System.Console.WriteLine($"9: {modalidade}, tipo: {m.Tipo}.\nDados do Atleta: {a.Numero}, {a.Nome}, {a.Pais}");
                    }
                }
            }
        }
        
    }

    private void dadosAtletaMaisMedalhas() //10
    {
        Atleta atleta = plantel.atletaComMaisMedalhas();

        if (atleta == null) {
            Console.WriteLine("10: Nenhum atleta com medalha.");
        } else {
            System.Console.WriteLine($"10: {atleta.Numero}, { atleta.Nome}, {atleta.Pais}, {plantel.tipos(atleta)}");
        }
    }    
}