using System.Collections;
using System.ComponentModel;

class Medalheiro
{
    private ArrayList medalhas;

    public Medalheiro()
    {
        medalhas = new ArrayList();
    }

    public bool cadastraMedalha(Medalha m)
    {
        foreach(Medalha medalha in medalhas)
        {
            if(!medalha.Equals(m)){
                medalhas.Add(m);
                return true;
            }
        }
        return false;
    }

    public Medalha consultaMedalha(int codigo)
    {
        if(!medalhas.Equals(null))
        {
            foreach(Medalha medalha in medalhas){
                if(medalha.Codigo.Equals(codigo))
                {
                    return medalha;
                }
            }
        }
        return null;
    } 

    public ArrayList consultaMedalhas(string modalidade)
    {
        ArrayList resultado = new ArrayList();
        if(!medalhas.Equals(null)){
            foreach(Medalha m in medalhas){
                if(m.Modalidade.Contains(modalidade)){
                    resultado.Add(m);
                    return resultado;
                }
                
            }
        }
        return null;
    }

    public ArrayList atletaPorTipoMedalha(int tipo){
            ArrayList resultado = new ArrayList();

            if (!medalhas.Equals(null)) {
                foreach (Medalha m in medalhas) {
                    if(m.Tipo == tipo){
                        foreach (Atleta a in m.Atletas){
                            resultado.Add(a);
                        }
                    }
                }
                return resultado;
            } else{
                return null;
            }
    }

}
