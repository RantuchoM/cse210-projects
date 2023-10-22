using System;
using System.Collections.Generic;
using System.Linq;

public class AgendaManager
{
    public List<AnyEvent> _events;
    public List<Ensemble> _ensembles;
    public List<Instrument> _instruments;
    public List<Person> _people;
    public AgendaManager(List<Person> people, List<Instrument> instruments, List <Ensemble> ensembles,List<Concert> concerts)
    {
        _people = people;
        _instruments = instruments;
        _ensembles = ensembles;
        _events = new();
        foreach (Concert concert in concerts)
        {
            _events.Add(concert);
        }

    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create a Concert");
            Console.WriteLine("2. Create a Rehearsal");
            Console.WriteLine("3. See events.");
            Console.WriteLine("4. Save Changes");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Call the method to create a concert
                    CreateConcert();
                    break;
                case "2":
                    // Call the method to create a rehearsal
                    //CreateRehearsal();
                    break;
                case "3":
                    // Call the method to see events
                    SeeEvents();
                    break;
                case "4":
                    //Save to .txt
                    SaveFiles();
                    break;
                case "5":
                    // Exit the loop and the program
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
    public void SaveFiles()
    {
        string filename = "concerts.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Concert concert in _events.OfType<Concert>())
            {
                outputFile.WriteLine(concert.GetString());
            }
        }
    }
    public void SeeEvents()
    {
        Console.WriteLine("\nThese are the events in the agenda: ");
        List<AnyEvent> _sortedEvents = _events.OrderBy(x => x.GetDateTime()).ToList();
        foreach (AnyEvent thisEvent in _sortedEvents)
        {
            Console.WriteLine(thisEvent.GetEventDetails());
        }
    }

    public void CreateConcert()
    {
        while (true)
        {
            Console.WriteLine("Which kind of concert would you like to create?");
            Console.WriteLine("1. Symphonic Concert");
            Console.WriteLine("2. Regional Concert");
            Console.WriteLine("3. Ensemble Concert");
            Console.WriteLine("4. Back");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateSymphonicConcert();
                    break;
                case "2":
                    CreateRegionalConcert();
                    break;
                case "3":
                    CreateEnsembleConcert();
                    break;
                case "4":
                    return; // Exit the CreateConcert method if the user selects "Back"
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
    public (DateTime,string,string) CreateEvent()
    {
        DateTime dateTime = GetValidDateTime();
        Console.WriteLine("Please enter a location: ");
        string location = Console.ReadLine();
        Console.WriteLine("Please enter a conductor: ");
        string conductor = Console.ReadLine();
        return (dateTime,location,conductor);
    }
    public void CreateSymphonicConcert()
    {
        var dataEvent = CreateEvent();
        DateTime dateTime = dataEvent.Item1;
        string location = dataEvent.Item2;
        string conductor = dataEvent.Item3;
        Console.Write("Please insert a description of the Symphonic Concert: ");
        string description = Console.ReadLine();
        Console.Write("Please insert a Title for the Symphonic Concert: ");
        string title = Console.ReadLine();

        SymphonicConcert concert = new(dateTime,location,conductor,description,title);
        _events.Add(concert);

    }

    public void CreateEnsembleConcert() //NOT READY!!!
    {
        var dataEvent = CreateEvent();
        DateTime dateTime = dataEvent.Item1;
        string location = dataEvent.Item2;
        string conductor = dataEvent.Item3;
        Console.Write("Please insert a description of the Ensemble Concert: ");
        string description = Console.ReadLine();
        Console.Write("Please insert a Title for the Ensemble Concert: ");
        string title = Console.ReadLine();
        Ensemble ensemble = null;
         // Display a menu to select a single ensemble
        Console.WriteLine("Available Ensembles:");
        for (int i = 0; i < _ensembles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_ensembles[i].GetName()}");
        }
        bool validChoice = false;

        while (!validChoice)
        {
            Console.Write("Enter the number of the ensemble to add: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _ensembles.Count)
            {
                ensemble = _ensembles[choice - 1]; // Adjust for 0-based indexing
                validChoice = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid ensemble number.");
            }
        }
        EnsembleConcert concert = new(dateTime,location,description,title,ensemble);
        _events.Add(concert);
        
    }

    public void CreateRegionalConcert() //NOT READY!!!
    {
        var dataEvent = CreateEvent();
        DateTime dateTime = dataEvent.Item1;
        string location = dataEvent.Item2;
        string conductor = dataEvent.Item3;
        Console.Write("Please insert a description of the Ensemble Concert: ");
        string description = Console.ReadLine();
        Console.Write("Please insert a Title for the Ensemble Concert: ");
        string title = Console.ReadLine();


        RegionalConcert concert = new(dateTime,location,description,title);
        // Display a menu to select ensembles
        Console.WriteLine("Available Ensembles:");
        for (int i = 0; i < _ensembles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_ensembles[i].GetName()}");
        }

        List<Ensemble> selectedEnsembles = new List<Ensemble>();

        bool addingEnsembles = true;
        while (addingEnsembles)
        {
            Console.Write("Enter the number of the ensemble to add (or '0' to finish): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= _ensembles.Count)
            {
                if (choice == 0)
                {
                    addingEnsembles = false; // Finish adding ensembles
                }
                else
                {
                    concert.AddEnsemble(_ensembles[choice - 1]); // Adjust for 0-based indexing
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid ensemble number.");
            }
        }

    
        _events.Add(concert);

    }
    
    static DateTime GetValidDateTime()
    {
        DateTime combinedDateTime = new();
        bool isValidInput = false;

        while (!isValidInput)
        {
            Console.Write("Enter a date in the 'dd/MM/yyyy' format: ");
            string dateInput = Console.ReadLine();

            Console.Write("Enter a time in the 'hh:mm' format: ");
            string timeInput = Console.ReadLine();

            DateTime date;
            if (DateTime.TryParseExact(dateInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                DateTime time;
                if (DateTime.TryParseExact(timeInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time))
                {
                    // Combine the date and time
                    combinedDateTime = date.Date + time.TimeOfDay;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid time input. Please enter a valid time in the 'hh:mm' format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date input. Please enter a valid date in the 'dd/MM/yyyy' format.");
            }
        }

        Console.WriteLine("Valid combined DateTime: " + combinedDateTime);
        return combinedDateTime;
    }
}