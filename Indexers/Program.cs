public class IndexersExample
{
    public static void Main[string[] args]
    {
        Leagues leagues = new Leagues();
        Leagues l = leagues.get("superligaen");
        l = leagues["superligaen"];
    }
}

class Leagues
{
    private Dictionary<string, League> theLeagues = new Dictionary<string, League>();

    public League this[string name] //indexer her. gør det samme som en getter. dog kortere at bruge [] men 
    //bruges sjældent. her er name key til noget i League dictionary hvor value så returneres
    //fordel her er at Leage dict er enkapsuleret i vores egen klasse Leagues så den ikke er exposed
    //så vi bruger Indexer til at gøre at man får value ud af array på samme måde som man ville gøre
    //direkte på array'en men her gøres det så gennem vores egen klasse
    //man kunne også bruge Indekser til matematiske beregniner, fordel at syntaxen [] er kortere
    //så man kan kalde Indekseren med navn[5], så er 5 input som der beregnes på og der returneres resultat
    {
        get
        {
            return theLeagues[name];
        }
    }
    public League get(string name)
    {
        return theLeagues[name];
    }
}

class League
{
    //laves fordi objekter af den er attribut og collection i Leagues klassen
}