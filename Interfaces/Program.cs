public class Program
{
    public static void Main(string[] args)
    {
        Sinatra sinatra = new Sinatra();
        Console.WriteLine($"Tonight featuring {sinatra.GetName}"); // 1) Use getName

        sinatra.Talk();
        // 2) Uncomment this
        sinatra.Sing();
        
        //har interface på venstre side:
        ISinger sinatra2 = new Sinatra(); // 3) Assign New Sinatra instead of null
        Console.WriteLine($"The singer is {sinatra2.GetName()}");
        sinatra2.Sing();
        //forskel på dynamisk og statisk metodedispatch

        LasVegas lv = new LasVegas();//lav klasse der har event
        //læg ting vi vil have skal ske ind i eventet

        lv.WhenShowStarts += sinatra.Talk;
        lv.WhenShowStarts += sinatra.Sing;

        lv.StartShow();

    }

    interface ISinger
    {
        String GetName();
        void Sing();
    }

    interface ISpeaker
    {
        //interfaces kan ikke have fields
        String GetName(); //hvorfor String med stort
        void Speak();
    }

    class Sinatra : ISinger, ISpeaker // implement the interface
    {
        // Provide the interface implementation
        //Skal name være attribute eller property, laver property her selvom der så er dobbelt
        //private readonly string? name; //? nu er field nullable og read only fordi vi har getter. 
        //Man bør jo bare have en property med getter men Niels skulle bare have nogle metoder i interfacet
        //brug quickfixes ved hover, den gav readonly og ? 
        private readonly string name = "sinatra";

        void ISinger.Sing() //eksplicit metode implementering, findes ikke i Java
        {}

        public string GetName()
        {
            //giver ikke mening at have getName i interface men Niels skulle bare finde på noget
            return name;
        }

        string ISinger.GetName() //vi implementere to interfaces med samme navn på metode,
        //metode specificeres så. kan ikke bruge public og private, det er implicit implementering
        {
            return name;
        }

        public void Sing()
        {
            Console.WriteLine("Sings");
        }

        public void Speak()
        {
            Console.WriteLine("Speaks");
        }

        public void Talk()
        {
            Console.WriteLine("Good evening Las Vegas");
        }
    }

    //delegate for når showet starter
    public delegate void WhenShowStarts(); //delegate er interface med én metode
    
    class LasVegas
    {
        //det er event:
        public event WhenShowStarts WhenShowStarts; //nu subscriber klassen til den delegate

        public void StartShow()
        {
            Console.WriteLine("event triggers: ");
            WhenShowStarts.Invoke(); 
        }
    }
    //en delegate har tre ting: metodebeskrivelse som har delegate keyword (øverst). delegate er en datatype
    //event er datatype og er en variabel som indeholder delegate
    //en metode som kalder eventet, her StartShow(), har eventNavn.Invoke();

}