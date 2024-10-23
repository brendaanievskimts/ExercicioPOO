using System.Collections;

class Atleta
{
    private int numero;
    private string nome;
    private string pais;
    private ArrayList medalhas;

    public Atleta(int numero, string nome, string pais)
    {
        this.numero = numero;
        this.nome = nome;
        this.pais = pais;
        medalhas = new ArrayList();
    }

    public int Numero
    {
        get{ return numero; }
        set{this.numero = value; }
    }

    public string Nome
    {
        get{ return nome; }
        set{ this.nome = value; }
    }

    public string Pais
    {
        get{ return pais; }
        set{ this.pais = value;}
    }

    public ArrayList Medalhas
    {
        get{ return medalhas; }
        set { this.medalhas = value; }
    }

    public void adicionaMedalha(Medalha medalha)
    {
        if(!medalhas.Equals(medalha)){
            medalhas.Add(medalha);
        }
    
    }

    public int consultaQuantidadeMedalhas()
    {
        int soma = 0;
        foreach(Medalha m in medalhas){
            soma++;
        }
        return soma;
    }
}
