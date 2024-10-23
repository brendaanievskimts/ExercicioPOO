using System.Collections;

class Plantel
{
    private ArrayList atletas;

    public Plantel()
    {
        atletas = new ArrayList();

    }

    public bool cadastraAtleta(Atleta a)
    {
        if(atletas.Contains(a)){
            return false;
        }
        atletas.Add(a);
        return true;
    }

    public Atleta consultaAtleta(string nome)
    {
        if(!atletas.Equals(null))
        foreach(Atleta atleta in atletas){
            if(atleta.Nome.Equals(nome)){
                return atleta;
            }
        }
        return null;
    }

    public Atleta consultaAtleta(int numero)
    {
        if(!atletas.Equals(null))
        {
            foreach(Atleta atleta in atletas)
            {
                if(atleta.Numero.Equals(numero)){
                    return atleta;
                }
            }
        }
        return null;
    }
    public Atleta atletaComMaisMedalhas(){
        Atleta aMedalhas = null;

        if(atletas != null) {
            foreach(Atleta a in atletas){
                if(aMedalhas == null || a.consultaQuantidadeMedalhas() >= aMedalhas.consultaQuantidadeMedalhas()){
                    aMedalhas = a;
                }
            }
        }
        return aMedalhas;
    }

    public String tipos(Atleta atleta) {
        int ouro = 0;
        int prata = 0;
        int bronze = 0;
        
        if(atleta == null){     
            return "Ouro:" + ouro + ",Prata:" + prata + ",Bronze:"+ bronze ;   
        } else {
            foreach(Medalha medalha in atleta.Medalhas){
                if(medalha != null ){
                    if(medalha.Tipo == 1){
                        ouro++;
                    }
                    if(medalha.Tipo == 2){
                        prata++;
                    }
                    if (medalha.Tipo == 3){
                        bronze++;
                    }
                }
            }
            return "Ouro:" + ouro + ",Prata:"+ prata + ",Bronze:" + bronze ;
        }
    }

    public String porPais(String pais) {
        int ouro = 0;
        int prata = 0;
        int bronze = 0;
        
        foreach(Atleta at in atletas){
            if(at.Pais == pais){
                foreach(Medalha medalha in at.Medalhas){
                    if(medalha != null ){
                        if(medalha.Tipo == 1){
                            ouro++;
                        }
                        if(medalha.Tipo == 2){
                            prata++;
                        }
                        if (medalha.Tipo == 3){
                            bronze++;
                        }
                    }
                }    
            }
        }
        return pais + ",Ouro:" + ouro + ",Prata:"+ prata + ",Bronze:" + bronze + ".";
    }    
}