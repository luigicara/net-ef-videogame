namespace net_ef_videogame
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Prego scegli una delle seguenti opzione premendo il corrispondente tasto sulla tastiera.");
            while (true)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1. Inserisci nuovo videogioco");
                Console.WriteLine("2. Ricerca per ID");
                Console.WriteLine("3. Ricerca per nome");
                Console.WriteLine("4. Ricerca per software-house id");
                Console.WriteLine("5. Elimina videogioco");
                Console.WriteLine("6. Inserisci nuova software-house");
                Console.WriteLine("7. Chiudi app");

                var opzione = Console.ReadKey();

                Console.WriteLine(Environment.NewLine);


                switch (opzione.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Nome:");
                        string name = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Descrizione:");
                        string overview = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Data di rilascio (dd/mm/yyyy):");
                        DateTime releaseDate;
                        while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
                            Console.WriteLine("Inserisci formato Valido! (dd/mm/yyyy)");

                        Console.WriteLine("Software house id:");
                        int softwareHouseId;
                        while (!int.TryParse(Console.ReadLine(), out softwareHouseId))
                            Console.WriteLine("Inserisci un NUMERO!");

                        Videogame game = new Videogame(name, overview, releaseDate, softwareHouseId);

                        Videogame.Add(game);

                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Inserisci id gioco");

                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.WriteLine("Inserisci un NUMERO!");

                        Videogame? result = Videogame.SearchById(id);

                        if(result == null)
                            Console.WriteLine("Nessun Risultato!");
                        else
                            Console.WriteLine(result.ToString());

                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Inserisci nome gioco");

                        string Name = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine(Videogame.ListToString(Videogame.SearchByName(Name)));

                        break;
                    //bonus
                    case ConsoleKey.D4:
                        Console.WriteLine("Inserisci id software-house");

                        int idS;
                        while (!int.TryParse(Console.ReadLine(), out idS))
                            Console.WriteLine("Inserisci un NUMERO!");

                        Console.WriteLine(Videogame.ListToString(Videogame.SearchBySoftwareHouse(idS)));

                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine("Inserisci id gioco da eliminare");

                        int _id;
                        while (!int.TryParse(Console.ReadLine(), out _id))
                            Console.WriteLine("Inserisci un NUMERO!");

                        Videogame.Delete(_id);

                        break;

                    case ConsoleKey.D6:

                        Console.WriteLine("Inserire una Software House.");

                        Console.Write("Inserire il nome: ");

                        string nameS = Console.ReadLine() ?? string.Empty;

                        Console.Write("Inserire il numero della partita Iva: ");

                        string taxId = Console.ReadLine() ?? string.Empty;

                        Console.Write("Inserire la città: ");

                        string city = Console.ReadLine() ?? string.Empty;

                        Console.Write("Inserire la Nazione: ");

                        string country = Console.ReadLine() ?? string.Empty;

                        SoftwareHouse softwareHouse;
                        try
                        {
                            softwareHouse = new SoftwareHouse(nameS, taxId, city, country);
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        SoftwareHouse.Add(softwareHouse);

                        break;

                    case ConsoleKey.D7:

                        Environment.Exit(0);

                        break;

                    default:
                        Console.WriteLine("Premi un numero da 1 a 5!");

                        break;
                }

            }
        }
    }
}