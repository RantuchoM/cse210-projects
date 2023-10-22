using System;
using System.Globalization;

class Program
{
    private static List<Instrument> instruments = new();
    private static List<Person> people = new();
    private static List<Ensemble> ensembles = new();
    private static List<Concert> concerts = new();
    static void Main(string[] args)
    {
       LoadInstruments();
       LoadPeople();
       LoadEnsembles();
       LoadConcerts();
       
       AgendaManager agendaManager = new(people,instruments,ensembles,concerts);
       agendaManager.Run();
       
    }

    static void LoadInstruments()
    {
        string filename = "instruments.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);
        
            foreach (string instrumentData in lines)
            {
                List<string> instrumentSplit = instrumentData.Split("♪").ToList();
                int instrumentId = int.Parse(instrumentSplit[0]);
                string instrumentName = ToTitle(instrumentSplit[1]);
                string instrumentFamily = ToTitle(instrumentSplit[2]);
                Instrument instrument = new(instrumentId,instrumentName,instrumentFamily);
                instruments.Add(instrument);
            }
        
    }
    static void LoadPeople()
    {
        string filename = "people.txt";
              
        string[] lines = System.IO.File.ReadAllLines(filename);
        
            foreach (string personData in lines)
            {
                List<string> personSplit = personData.Split("♪").ToList();
                if(personSplit.Count() == 4)
                {
                    int id = int.Parse(personSplit[0]);
                    string first = ToTitle(personSplit[1]);
                    string last = ToTitle(personSplit[2]);
                    int instrumentId = int.Parse(personSplit[3]);
                    Instrument matchedInstrument = instruments.Find(instrument => instrument.GetInstrumentId() == instrumentId);
                    Person person = new(id,first,last,matchedInstrument);
                    people.Add(person);
                }                 
            }
        
    }
    static string ToTitle(string name)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(name.ToLower());
    }

    static void LoadEnsembles()
    {
        string filename = "ensembles.txt";
               
        string[] lines = System.IO.File.ReadAllLines(filename);
        
            foreach (string ensembleData in lines)
            {
                List<string> ensembleSplit = ensembleData.Split("♪").ToList();
                
                    int id = int.Parse(ensembleSplit[0]);
                    string ensembleName = ensembleSplit[1];
                    string ensembleDescr = ToTitle(ensembleSplit[2]);
                    List<Person> ensemblePeople = new();
                    string peopleId = ensembleSplit[3];
                    string location = ToTitle(ensembleSplit[4]);

                    List<string> peopleSplit = peopleId.Split("♫").ToList();
                    foreach (string thisId in peopleSplit)
                    {
                        Person matchedPerson = people.Find(personId => personId.GetId() == int.Parse(thisId));
                        ensemblePeople.Add(matchedPerson);
                    }
                    
                    
                    Ensemble ensemble = new(id,ensembleName,ensembleDescr,ensemblePeople,location);
                    ensembles.Add(ensemble);
                                      
            }
    }
    static void LoadConcerts()
    {
        string filename = "concerts.txt";
               
        string[] lines = System.IO.File.ReadAllLines(filename);
        
            foreach (string concertData in lines)
            {
                List<string> concertSplit = concertData.Split("♪").ToList();
                
                    int id = int.Parse(concertSplit[0]);
                    DateTime concertDate = ParseDateTime(concertSplit[1]);
                    string location = ToTitle(concertSplit[2]);
                    string conductor = ToTitle(concertSplit[3]);
                    string description = concertSplit[4];
                    string type = concertSplit[5];
                    switch (type)
                    {
                        case "Symphonic":
                            string title = concertSplit[6];
                            SymphonicConcert symphonic = new(id,concertDate,location,conductor,description,title);
                            concerts.Add(symphonic);
                            break;
                        case "Regional":
                            string ensemblesConcert = concertSplit[6];
                            List<string> ensemblesSplit = ensemblesConcert.Split("♫").ToList();
                            List<Ensemble> ensemblesList = new();
                            foreach (string thisId in ensemblesSplit)
                            {
                                Ensemble matchedEnsemble = ensembles.Find(ensembleId => ensembleId.GetId() == int.Parse(thisId));
                                ensemblesList.Add(matchedEnsemble);
                            }
                            RegionalConcert regional= new(id,concertDate,location,conductor,description);
                            foreach(Ensemble ensemble in ensemblesList)
                            {
                                regional.AddEnsemble(ensemble);
                            }
                            concerts.Add(regional);

                            break;
                        case "Ensemble":
                            string idString = concertSplit[6];
                            Ensemble thisEnsemble = ensembles.Find(ensembleId => ensembleId.GetId() == int.Parse(idString));
                            EnsembleConcert ensembleConcert = new(id,concertDate,location,conductor,description,thisEnsemble);
                            concerts.Add(ensembleConcert);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                    
                    
                    
                    
                    
                                      
            }
    }
    static DateTime ParseDateTime(string input)
    {
        string format = "dd/MM/yyyy HH:mm:ss";

        if (DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        else
        {
            // Return DateTime.MinValue to indicate a parsing failure
            return DateTime.MinValue;
        }
    }
    
    
}