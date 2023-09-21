using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new();

    public void AddEntry(){
        Entry _entry = new Entry();
        Console.WriteLine(_entry._promptText);
        _entry._entryText = Console.ReadLine();
        _entries.Add(_entry);
        Console.WriteLine("Note successfully recorded.");
    }
    public void DisplayAll(){
        foreach (Entry _entry in _entries){
            _entry.Display();
        }
    }
    
    public void SaveToFile(string filePath){
        // Create or overwrite the file and write CSV lines
        File.WriteAllText(filePath, "Date,PromptText,EntryText\n"); // Write the header row
        foreach (var entry in _entries)
        {
            string date = CommasToSymbol(entry._date);
            string prompt = CommasToSymbol(entry._promptText);
            string entryT = CommasToSymbol(entry._entryText);
            string csvLine =  $"{date},{prompt},{entryT}";
            File.AppendAllText(filePath, csvLine + "\n"); // Append each CSV line to the file
        }
        Console.WriteLine($"Journal saved successfully at {filePath}");
           }

    public void LoadFromFile(string filePath){
        string[] entries = File.ReadAllLines(filePath);
        for (int i = 1; i < entries.Length; i++) // i=1 is for skipping headers
        {
            string line = entries[i];
            string[] values = line.Split(',');
            string date = values[0];
            string prompt = values[1];
            string entryText = values[2];
            Entry entry = new(){
                _date = SymbolToComma(date),
                _promptText = SymbolToComma(prompt),
                _entryText = SymbolToComma(entryText)
                        };
            _entries.Add(entry);
            


        }
        Console.WriteLine($"{_entries.Count} notes were loaded from {filePath}.");
    }

    public void EditLastEntry(){
        Entry entry = _entries[_entries.Count -1];
        entry.Display();
        Console.Write("Please enter new text: ");
        entry._entryText = Console.ReadLine();
        Console.WriteLine("Your text has been modified.");
    }

    private string CommasToSymbol(string str)
    {
        return str.Replace(",","♪");
    }

    private string SymbolToComma(string str)
    {
        return str.Replace("♪",",");
    }
}