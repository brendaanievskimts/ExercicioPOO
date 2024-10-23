using System.Collections;

class Medalha
{
    private int codigo;
    private int tipo;
    private bool individual;
    private string modalidade;
    private ArrayList atletas;

    public Medalha(int codigo, int tipo, bool individual, string modalidade)
    {
        this.codigo = codigo;
        this.tipo = tipo;
        this.individual = individual;
        this.modalidade = modalidade;
        atletas = new ArrayList();
    }

    public int Codigo
    {
        get
        { return codigo; }
        set { this.codigo = value; }
    }

    public int Tipo
    {
        get{ return tipo; }
        set{ this.tipo = value; }
    }

    public bool Individual
    {
        get{ return individual; }
        set{ this.individual = value; }
    }

    public string Modalidade
    {
        get{ return modalidade; }
        set{ this.modalidade = value; }
    }

    public ArrayList Atletas
    {
        get{ return atletas; }
        set{ this.atletas = value; }
    }


    public void adicionaAtleta(Atleta atleta)
    {
        if(!atletas.Equals(atleta))
        {
            atletas.Add(atleta);
        }

    }
}