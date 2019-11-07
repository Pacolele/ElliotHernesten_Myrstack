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