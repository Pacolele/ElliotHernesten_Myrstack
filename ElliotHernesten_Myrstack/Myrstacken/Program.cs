using System;
using System.Collections.Generic;

class Program
{
    private List<Ants> antColony = new List<Ants>();
    static void Main()
    {
        Program p = new Program();
        p.Run();
    }

    void Run()
    {
        Console.WriteLine("Hello! Welcome to a simulated world of ants. \n Enter 'help' for available commands");

        while (true)
        {
            Console.WriteLine("\nPlease, enter your command\n>>>");
            string input = Console.ReadLine().ToLower();
           
            if (input == "exit")
            {
                break;
            }

            else
            {
                InputCentre(input);
            }
        }

    }

    void InputCentre(string input)
    {
        switch (input)
        {
            case "help":
                Help();
                break;

            case "add":
                CreateAnt();
                break;

            case "list":
                ListAnts();
                break;

            case "count":
                Console.WriteLine("\nTotalt amount of ants:");
                Console.WriteLine(antColony.Count);
                break;

            case "exit":
                Environment.Exit(0);
                break;

            case "remove":
                Remove();
                break;

            case "search":
                Search();
                break;

            default:
                Console.Write("type 'help' for a list of commands available");
                break;

        }
    }

    private void Help()
    {
        Console.WriteLine(
            "help - shows available commands\n" +
            "add - Adds a new ant\n" +
            "list - lists all existing ants + name and legs \n" +
            "count - counts up how many ants there are in the stack \n" +
            "remove - removes ant by name or legs \n" +
            "search - search for ant by name or legs \n" +
            "exit - exits the program"
            );
    }
    
    private void Search()
    {
        if (EmptyColony())
            return;

        while (true)
        {
            Console.WriteLine("Search by Name or Legs:\n");
            /*
             * Robin:
             * Kollar endast efter Name eller Legs med inledande versal, d.v.s. det
             * är skiftlägeskänsligt.
             */
            string input = Console.ReadLine();
            if (input == "Name")
            {
                SearchByName();
                break;
            }
            else if (input == "Legs")
            {
                SearchByLegs();
                break;
            }
            else
                Console.WriteLine("Enter 'Name' or 'Legs'.");
            
        }
    }

    /*
     * Robin:
     * Detta gäller båda sök-metoderna: 
     * I foreach-loopen så har du en if-else if sats. Detta leder till att det finns i
     * else if-satsen skrivs ut för varje myra (lätt att testa genom att bara lägga till 
     * 2 myror med 1 ben var och sedan söka efter myror med 2 ben). Vad du skulle vilja 
     * göra är att när du letar efter namn avbryta metoden med en return efter att du hittat 
     * en myra. Det kan trots allt endast finnas en myra med det namnet. Sen efter for-
     * loopen skriva ut att det inte finns några myror med det namnet. Du kan uppnå samma
     * resultat när du söker efter antal ben med hjälp av en bool eller liknande.
     */
    private void SearchByName()
    {
        Console.WriteLine("Please enter a 'ant name' to search for it");
        string antSearchName = Console.ReadLine();

        foreach(Ants a in antColony)
        {
            if(a.Name.ToLower() == antSearchName.ToLower())
            {
                Console.WriteLine($"Found your ant: " + a.Name);
            }
            else if(a.Name != antSearchName)
            {
                Console.WriteLine($"Couldn't find your ant");
            }
        }
    }

    /*
    * Iterar över alla myror i listan antColony. Det lilla 'a' står för alla myror i antColony.
    * Kollar om antal ben på myror är samma ditt input (det du söker efter). Annars får man feedback.
    */
    private void SearchByLegs()
    {
        Console.WriteLine("Please enter amount of 'legs' to search for it:");
        /*
         * Robin:
         * Du utför en parse utan att fånga eventuella fel. Detta leder till att om man försöker 
         * skriva in en symbol som inte är en siffra här så kraschar programmet.
         */
        int antSearchLegs = int.Parse(Console.ReadLine());

        foreach (Ants a in antColony)
        {
            if (a.Legs == antSearchLegs)
            {
                Console.WriteLine($"Found legs: " + a);
            }
            else if (a.Legs != antSearchLegs)
            {
                Console.WriteLine($"Couldn't find any ants with that amount of legs:");
            }
        }
    }

    private void Remove()
    {
        if (EmptyColony())
            return;

        Console.WriteLine("Please enter Ant name to remove\n");
        string antRemoveName = Console.ReadLine();

        foreach (Ants a in antColony)
        {
            if (a.Name.ToString() == antRemoveName.ToString())
            {
                antColony.Remove(a);
                Console.WriteLine($"The ant '{antRemoveName}' has been removed");
                return;
            }
        }
        /*
         * Robin:
         * Hade varit bra med lite feedback här efter loopen ifall ingen myra hittas.
         */
    }

    private void ListAnts()
    {
        for (int i = 0; i < antColony.Count; i++)
        {
            if (antColony[i] != null)
                Console.WriteLine(antColony[i].ToString());
        }
    }
    /*
     * Bool för om namnet inte är unikt. Medans när uniqueName inte är falskt körs while loopen. uniqueName sätts till true för while loopen.
     * Kollar på namnet är längre än tio characters. Sen kollar foreach loopen om namnet inte är unikt, sätter uniqueName till false för att bryta loopen.
    */
    private void CreateAnt()
    {
        bool uniqueName = false;
        string name = "";
        /*
         * Robin:
         * Snygg while-loop! 
         */
        while (!uniqueName)
        {
            uniqueName = true;
            Console.WriteLine("\nEnter ant name\n>>>");
            name = Console.ReadLine();

            if (name.Length <= 10)
            {
                foreach (Ants a in antColony)
                {
                    if (a.Name.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("Please enter a unique name");
                        uniqueName = false;
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Name longer than 10 characters, try again");
                uniqueName = false;
            }
        }
        
        try
        {
            Console.WriteLine("Please enter amount of legs:");
            int legs = int.Parse(Console.ReadLine());

            Ants newAnt = new Ants(name, legs);
            newAnt.Legs = legs;
            antColony.Add(newAnt);
            Console.WriteLine("Name, Legs:\n" + newAnt.Name + ", " + newAnt.Legs);
        }
        catch
        {
            Console.WriteLine("\nTry a writing a number");
        }
        
    }

    private bool EmptyColony()
    {
        if (antColony.Count == 0)
        {
            Console.WriteLine("Ant colony is empty.");
            return true;
        }
        return false;
    }

}

/*
 * Robin:
 * Koden är snyggt upplagd, konsekvent skriven med tydlig, beskrivande namngivning. Det finns
 * dock en del logiska fel som leter till både små och stora problem. Vad jag kan se så har
 * du en tydlig kodningsstil, men vi kan behöva fokusera på att testa koden efter fel lite mer.
 * 
 * Vad jag sett så arbetar du på bra på lektionerna. Jag har inte hört dig prata om din kod 
 * så mycket dock, och vad jag minns så har du inte ställt så många frågor på lektionerna 
 * (i alla fall till mig). Dock så märker jag att du sammarbetar bra med andra i klassen
 * vilket är roligt att se.
 * 
 * Bra jobbat! Fortsätt arbeta på det som jag pekkat ut här så kommer du bli riktigt duktig!
 */