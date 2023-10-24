using System;
using System.Collections.Generic;
using System.Linq;

public class AgendaManager
{
    private List<AnyEvent> _events;
    private List<Ensemble> _ensembles;
    private List<Instrument> _instruments;
    private List<Person> _people;

    public AgendaManager(List<Person> people, List<Instrument> instruments, List<Ensemble> ensembles, List<Rehearsal> rehearsals, List<Concert> concerts)
    {
        _people = people;
        _instruments = instruments;
        _ensembles = ensembles;
        _events = new();
        foreach (Rehearsal rehearsal in rehearsals)
        {
            _events.Add(rehearsal);
        }
        foreach (Concert concert in concerts)
        {
            _events.Add(concert);
        }
    }

    public void Run()
    {
        bool firstTime = true;
        while (true)
        {   
            if(!firstTime)
            {
                Console.WriteLine("Press <Enter> to go back to the Menu");
                Console.ReadLine();
                
            }
            firstTime = false;
            Console.Clear();
            Console.WriteLine("*****************************************************");
            Console.WriteLine($"                       MENU ");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Create a Concert");
            Console.WriteLine("2. Create a Rehearsal");
            Console.WriteLine("3. See events");
            Console.WriteLine("4. See events by Concert");
            Console.WriteLine("5. Show ensemble information");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateConcert();
                    break;
                case "2":
                    CreateRehearsal();
                    break;
                case "3":
                    SeeEvents();
                    break;
                case "4":
                    SeeEventsByConcert();
                    break;
                case "5":
                    ShowEnsembleInfo();
                    break;
                case "6":
                    SaveFiles();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
    public void HandleAnyEvent(List<AnyEvent> events)
    {
        Console.WriteLine("Do you want to modify or delete an event? (y/n)");
        string choice = Console.ReadLine().ToLower();

        if (choice == "y")
        {
            Console.Write("Enter the index of the event to modify or delete: ");
            if (int.TryParse(Console.ReadLine(), out int eventIndex) && eventIndex >= 1 && eventIndex <= events.Count)
            {
                AnyEvent selectedEvent = events[eventIndex - 1];

                Console.WriteLine("Do you want to (M)odify or (D)elete the event? (M/D)");
                string modifyOrDelete = Console.ReadLine().ToLower();

                if (modifyOrDelete == "m")
                {
                    ModifyEvent(selectedEvent);
                }
                else if (modifyOrDelete == "d")
                {
                    _events.Remove(selectedEvent);

                    if (selectedEvent is Concert concert)
                    {
                        // Delete associated rehearsals
                        List<Rehearsal> concertRehearsals = concert.GetRehearsals();
                        foreach (Rehearsal rehearsal in concertRehearsals)
                        {
                            _events.Remove(rehearsal);
                        }
                    }

                    Console.WriteLine("Event deleted.");
                }
                else
                {
                    Console.WriteLine("Invalid action. Please enter 'M' to modify or 'D' to delete.");
                }
            }
            else
            {
                Console.WriteLine("Invalid event index.");
            }
        }
        else if (choice != "n")
        {
            Console.WriteLine("Invalid choice. Please enter 'y' to modify or delete, or 'n' to cancel.");
        }
    }



    public void SeeEvents()
    {
        Console.WriteLine("\nThese are the events in the agenda: ");
        List<AnyEvent> sortedEvents = _events.OrderBy(x => x.GetDateTime()).ToList();
        for (int i = 0; i < sortedEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedEvents[i].GetEventDetails()}");
        }

        HandleAnyEvent(sortedEvents);
    }

    public void SeeEventsByConcert()
    {
        Concert concert = ChooseConcert("Please choose a concert: ");
        List<AnyEvent> concertEvents = new List<AnyEvent>(concert.GetRehearsals());
        concertEvents.Add(concert);
        concertEvents = concertEvents.OrderBy(x => x.GetDateTime()).ToList();

        for (int i = 0; i < concertEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {concertEvents[i].GetEventDetails()}");
        }

        HandleAnyEvent(concertEvents);
    }


    public void ModifyEvent(AnyEvent eventToModify)
    {
        Console.WriteLine("Choose a property to modify: (1) Date, (2) Location, (3) Conductor");
        if (int.TryParse(Console.ReadLine(), out int propertyChoice))
        {
            Console.Write("Enter the new value: ");
            
            switch (propertyChoice)
            {
                case 1:
                    eventToModify.SetTime(GetValidDateTime());
                    break;
                case 2:
                    eventToModify.SetLocation(Console.ReadLine());
                    break;
                case 3:
                    eventToModify.SetConductor(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid property choice.");
                    break;
            }
        }
    }

    public void CreateRehearsal()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("      Create a Rehearsal ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Which kind of rehearsal would you like to create?");
            Console.WriteLine("1. Ensemble Rehearsal");
            Console.WriteLine("2. Regional Rehearsal");
            Console.WriteLine("3. Back");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Concert concert = ChooseConcert("To which concert do you like to add a Rehearsal?");
                    var dataEvent = CreateEvent();
                    DateTime dateTime = dataEvent.Item1;
                    string location = dataEvent.Item2;
                    string conductor = dataEvent.Item3;
                    Console.WriteLine("Please write any observations if there are, or just type Enter");
                    string observations = Console.ReadLine();
                    Console.WriteLine("Please choose an Ensemble: ");
                    Ensemble ensemble = ChooseEnsemble();
                    EnsembleRehearsal ensembleRehearsal = new(dateTime, location, conductor, observations, ensemble);
                    _events.Add(ensembleRehearsal);
                    concert.AddRehearsal(ensembleRehearsal);
                    break;
                case "2":
                    Concert concertR = ChooseConcert("To which concert do you like to add a Rehearsal?");
                    var dataEventR = CreateEvent();
                    DateTime dateTimeR = dataEventR.Item1;
                    string locationR = dataEventR.Item2;
                    string conductorR = dataEventR.Item3;
                    Console.WriteLine("Please write any observations if there are, or just type Enter");
                    string observationsR = Console.ReadLine();
                    List<Ensemble> rehearsalEnsembles = new();
                    string answer = "";
                    while (answer.ToLower() != "no")
                    {
                        Console.WriteLine("Please choose an Ensemble: ");
                        Ensemble ensembleR = ChooseEnsemble();
                        rehearsalEnsembles.Add(ensembleR);
                        Console.WriteLine("Do you want to add another ensemble: ");
                        answer = Console.ReadLine();
                    }
                    GeneralRehearsal generalRehearsal = new(dateTimeR, locationR, conductorR, observationsR, rehearsalEnsembles);
                    _events.Add(generalRehearsal);
                    concertR.AddRehearsal(generalRehearsal);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    public void CreateConcert()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("     Create a Concert ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
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
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
    public void ShowEnsembleInfo()
    {
        Ensemble ensemble = ChooseEnsemble();
        Console.WriteLine($"\nThis is the Ensemble information");
        Console.WriteLine($"{ensemble.GetName()} - Located at {ensemble.GetLocation()}\n{ensemble.GetDescription()}");
        Console.WriteLine($"Its members are: ");
        foreach(Person person in ensemble.GetPeople())
        {
            Console.WriteLine($"   {person.GetFullName()}");
        }
    }
    public (DateTime, string, string) CreateEvent()
    {
        DateTime dateTime = GetValidDateTime();
        Console.WriteLine("Please enter a location: ");
        string location = Console.ReadLine();
        Console.WriteLine("Please enter a conductor: ");
        string conductor = Console.ReadLine();
        return (dateTime, location, conductor);
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
        SymphonicConcert concert = new(dateTime, location, conductor, description, title);
        _events.Add(concert);
    }

    public void CreateEnsembleConcert()
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
        ensemble = ChooseEnsemble();
        EnsembleConcert concert = new(dateTime, location, description, title, ensemble);
        _events.Add(concert);
    }

    public void CreateRegionalConcert()
    {
        var dataEvent = CreateEvent();
        DateTime dateTime = dataEvent.Item1;
        string location = dataEvent.Item2;
        string conductor = dataEvent.Item3;
        Console.Write("Please insert a description of the Ensemble Concert: ");
        string description = Console.ReadLine();
        Console.Write("Please insert a Title for the Ensemble Concert: ");
        string title = Console.ReadLine();
        RegionalConcert concert = new(dateTime, location, description, title);
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
                    addingEnsembles = false;
                }
                else
                {
                    concert.AddEnsemble(_ensembles[choice - 1]);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid ensemble number.");
            }
        }
        _events.Add(concert);
    }

    public DateTime GetValidDateTime()
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
        string rehearsalsFilename = "rehearsals.txt";
        using (StreamWriter outputFile = new StreamWriter(rehearsalsFilename))
        {
            foreach (Rehearsal rehearsal in _events.OfType<Rehearsal>())
            {
                outputFile.WriteLine(rehearsal.GetRehearsalString());
            }
        }
    }

    public Concert ChooseConcert(string prompt)
    {
        List<Concert> concerts = _events.OfType<Concert>().ToList();
        Console.WriteLine(prompt);
        for (int i = 0; i < concerts.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {concerts[i].GetEventDetails()}");
        }
        Console.WriteLine();
        int index = int.Parse(Console.ReadLine()) - 1;
        Concert concert = concerts[index];
        return concert;
    }

    public Ensemble ChooseEnsemble()
    {
        Ensemble ensemble = null;
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
                ensemble = _ensembles[choice - 1];
                validChoice = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid ensemble number.");
            }
        }
        return ensemble;
    }
}
